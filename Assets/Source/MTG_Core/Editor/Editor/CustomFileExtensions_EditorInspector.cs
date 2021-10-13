/*
 * Utility for displaying an inspector for custom file extensions, the main class has a dictionary for each file type along with a class that overrides OnInspectorGUI
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace MTG.Core.Editor
{

    [CustomEditor(typeof(DefaultAsset))]
    public sealed class CustomFileExtensions_EditorInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (!target)
                return;

            string targetFilePath = AssetDatabase.GetAssetPath(target);
            string fileExtension = Path.GetExtension(targetFilePath);
            
            if (fileExtension.Length < 2)
                return;
            
            fileExtension = fileExtension.Remove(0, 1);

            if (CustomFileExtensions_EditorInspectorInitializer.Instances.ContainsKey(fileExtension))
                CustomFileExtensions_EditorInspectorInitializer.Instances[fileExtension].OnInspectorGUI(target);
            else
                base.OnInspectorGUI();
        }
    }

    [InitializeOnLoad]
    public sealed class CustomFileExtensions_EditorInspectorInitializer
    {

        public static Dictionary<string, CustomFileExtensions_EditorInspectorTemplate> Instances;
        
        static CustomFileExtensions_EditorInspectorInitializer()
        {
            Instances = new Dictionary<string, CustomFileExtensions_EditorInspectorTemplate>();
            
            Type templateType = typeof(CustomFileExtensions_EditorInspectorTemplate);
            
            var derivedTypes = templateType.Assembly.GetTypes().Where(t => t.BaseType == templateType);

            foreach (Type derivedType in derivedTypes)
            {
                var associationAttributes = derivedType.GetCustomAttributes<FileExtensionEditorInspectorAssociation>(true).ToArray();

                if (associationAttributes.Length != 1)
                    throw new NotImplementedException();

                FileExtensionEditorInspectorAssociation associationAttribute = associationAttributes[0];
                string associatedFileExtension = associationAttribute.FileExtension;

                if (Instances.ContainsKey(associatedFileExtension))
                    throw new NotImplementedException();

                ConstructorInfo derivedTypeConstructor = derivedType.GetConstructor(Type.EmptyTypes);

                if (derivedTypeConstructor == null)
                    throw new NotImplementedException();

                object derivedTypeInstanceGeneric = derivedTypeConstructor.Invoke(new object[0]);

                if (derivedTypeInstanceGeneric is CustomFileExtensions_EditorInspectorTemplate derivedTypeInstance)
                    Instances.Add(associatedFileExtension, derivedTypeInstance);
                else
                    throw new NotImplementedException();
            }
        }
        
    }
    
}
