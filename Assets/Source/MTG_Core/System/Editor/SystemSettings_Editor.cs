using System;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace MTG.Core
{
    
    public abstract partial class SystemSettings<T, U>
    {
        
        private static void LoadGlobalDataAssetInstance()
        {
            _globalDataAssetInstance = AssetDatabase.LoadAssetAtPath<U>(GlobalInstance.SettingsDataAssetUnityPath);
            if (_globalDataAssetInstance == null)
                CreateGlobalDataAsset();

            if (_globalDataAssetInstance == null)
                throw new NotImplementedException();
        }

        private static void CreateGlobalDataAsset()
        {
            string dataAssetFullPath = Path.Combine(GlobalInstance.SettingsDataAssetUnityPath);
            string dataAssetLocalDirectory = Path.GetDirectoryName(dataAssetFullPath);
            string dataAssetFullDirectory = Path.Combine(Application.dataPath,
                dataAssetLocalDirectory ?? throw new NotImplementedException());
            
            if (!Directory.Exists(dataAssetFullDirectory))
                Directory.CreateDirectory(dataAssetFullDirectory);
        
            _globalDataAssetInstance = ScriptableObject.CreateInstance<U>();
            AssetDatabase.CreateAsset(_globalDataAssetInstance, Path.Combine("Assets/", dataAssetFullPath));
            AssetDatabase.SaveAssets();
        }
        
    }
    
}
