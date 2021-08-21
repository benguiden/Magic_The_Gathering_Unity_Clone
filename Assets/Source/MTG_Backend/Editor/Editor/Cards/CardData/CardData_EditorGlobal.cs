using UnityEditor;
using UnityEngine;

namespace MTG.Backend.Editor
{
    
    [InitializeOnLoad]
    public class CardData_EditorGlobal
    {

        private static bool m_editorSelectionChanged = false;
        private static CardData_ScriptableObjectWrapper m_wrapper = null;
        
        static CardData_EditorGlobal()
        {
            Selection.selectionChanged += EditorSelectionChanged;
            EditorApplication.update += EditorUpdate;
        }
        
        ~CardData_EditorGlobal()
        {
            Selection.selectionChanged -= EditorSelectionChanged;
            EditorApplication.update -= EditorUpdate;
        }

        private static void EditorSelectionChanged()
        {
            m_editorSelectionChanged = true;
        }

        private static void EditorUpdate()
        {
            if (!m_editorSelectionChanged)
                return;

            m_editorSelectionChanged = false;

            if (Selection.activeObject == m_wrapper)
                return;
            
            string selectedFilePath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            
            if (!selectedFilePath.ToLower().EndsWith(".card"))
                return;
            
            if (m_wrapper == null)
            {
                m_wrapper = ScriptableObject.CreateInstance<CardData_ScriptableObjectWrapper>();
                m_wrapper.hideFlags = HideFlags.None;
            }

            m_wrapper.LoadDataAtPath(selectedFilePath);
            Selection.activeObject = m_wrapper;
 
            var inspectors = Resources.FindObjectsOfTypeAll<CardData_EditorInspector>();
            foreach (CardData_EditorInspector inspector in inspectors)
            {
                inspector.Repaint();
            }

        }
    }
    
}
