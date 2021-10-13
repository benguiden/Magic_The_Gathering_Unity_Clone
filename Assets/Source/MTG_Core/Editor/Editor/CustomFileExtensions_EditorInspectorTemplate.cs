using System;
using UnityEngine;

namespace MTG.Core.Editor
{

    public abstract class CustomFileExtensions_EditorInspectorTemplate
    {
        
        protected abstract void OnInspectorGUI_Implemented(UnityEngine.Object target);

        public void OnInspectorGUI(UnityEngine.Object target)
        {
            bool guiEnabled = GUI.enabled;
            if (!guiEnabled)
                GUI.enabled = true;
            
            OnInspectorGUI_Implemented(target);
            
            if (!guiEnabled)
                GUI.enabled = false;
        }
        
    }

    public sealed class FileExtensionEditorInspectorAssociation : Attribute
    {

        public string FileExtension { get; }
        
        public FileExtensionEditorInspectorAssociation(string fileExtension)
        {
            if (string.IsNullOrEmpty(fileExtension))
                throw new NotImplementedException();

            if (fileExtension.Contains("."))
                throw new NotImplementedException();
            
            FileExtension = fileExtension;
        }
        
    }
    
}
