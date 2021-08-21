/// TODO: Convert UI from IMGui to UIElements 

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Graphs;
using UnityEngine;

namespace MTG.Backend.Editor
{

    public class ActiveProcessors_EditorWindow : EditorWindow
    {

        private const string WINDOW_NAME = "TEMP Active Processors";
        private static Color FoldoutActiveTextColour = new Color(1f, 1f, 0.9f); 
        private static Color FoldoutUnactiveTextColour = new Color(0.75f, 0.6f, 0.6f); 
        
        private static ActiveProcessors_EditorWindow temp;

        private Dictionary<IDebuggableProcessor, bool> m_foldouts = new Dictionary<IDebuggableProcessor, bool>();

        private GUIStyle m_foldoutStyle;
        
        [MenuItem("Window/TEMP Active Processors")]
        public static void TempShowWindow()
        {
            temp = GetWindow<ActiveProcessors_EditorWindow>();
            temp.name = WINDOW_NAME;
            temp.Focus();
        }

        private void CreateGUI()
        {

            rootVisualElement.visible = false;

        }

        private void OnBecameVisible()
        {
            EditorApplication.update += Repaint;
        }
        
        private void OnBecameInvisible()
        {
            EditorApplication.update -= Repaint;
        }

        private void Awake()
        {
            autoRepaintOnSceneChange = false;
            m_foldoutStyle = new GUIStyle(EditorStyles.foldout);
        }

        private void OnGUI()
        {
            if (!Application.isPlaying)
            {
                DrawNotPlayingMessage();
                return;
            }

            if (!MatchProcessor.ActiveInstance)
            {
                DrawNoActiveMatchProcessorMessage();
                return;
            }

            DrawCollapseButton();
            
            DrawSelectableProcessorFoldout(MatchProcessor.ActiveInstance);

            if (TurnPhase.ActiveInstance)
                DrawNextStepButton();
        }

        private void DrawCollapseButton()
        {
            if (GUILayout.Button("Collapse"))
            {
                if (m_foldouts.Values.Any(foldout => foldout))
                {
                    foreach (IDebuggableProcessor foldoutKey in m_foldouts.Keys.ToList())
                    {
                        m_foldouts[foldoutKey] = false;
                    }
                }
                else
                {
                    foreach (IDebuggableProcessor foldoutKey in m_foldouts.Keys.ToList())
                    {
                        m_foldouts[foldoutKey] = true;
                    }
                }
            }
        }
        
        private void DrawNotPlayingMessage()
        {
            GUILayout.Label("Not in play mode...");
        }
        
        private void DrawNoActiveMatchProcessorMessage()
        {
            GUILayout.Label("No active match processor...");
        }

        private void DrawSelectableProcessorFoldout(IDebuggableProcessor processor)
        {
            bool foldout = false;
            if (!m_foldouts.ContainsKey(processor))
                m_foldouts.Add(processor, false);
            else
                foldout = m_foldouts[processor];

            m_foldoutStyle.onNormal.textColor = processor.DebuggingIsActive ? FoldoutActiveTextColour : FoldoutUnactiveTextColour;
            m_foldoutStyle.normal.textColor = processor.DebuggingIsActive ? FoldoutActiveTextColour : FoldoutUnactiveTextColour;
            
            foldout = EditorGUILayout.Foldout(foldout, processor.DebuggingHeaderString, m_foldoutStyle);
            m_foldouts[processor] = foldout;
            
            if (foldout)
            {
                EditorGUI.indentLevel++;
                
                var children = processor.GetDebuggableChildren();

                foreach (IDebuggableProcessor child in children)
                {
                    DrawSelectableProcessorFoldout(child);
                }
                
                EditorGUI.indentLevel--;
            }
        }

        private void DrawNextStepButton()
        {
            if (GUILayout.Button("▶|"))
                TurnPhase.ActiveInstance.ExecuteNextStep();
        }
        
        
    }

}
