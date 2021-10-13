using UnityEditor;
using UnityEngine;

namespace MTG.Core.Editor
{
    
    [FileExtensionEditorInspectorAssociation("card")]
    public class Temp_CardFileExtension_EditorInspector : CustomFileExtensions_EditorInspectorTemplate
    {
        protected override void OnInspectorGUI_Implemented(Object target)
        {
            GUI.enabled = true;
            string targetFilePath = AssetDatabase.GetAssetPath(target);
            GUILayout.Label($"This card file is selected: {targetFilePath}");

            GUILayout.Button("Open in Card Editor");
        }
    }
    
}
