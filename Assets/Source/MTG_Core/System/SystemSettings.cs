using System.IO;
using UnityEngine;

namespace MTG.Core
{
    
    public abstract partial class SystemSettings<T, U> where T : SystemSettings<T, U>, new() where U : SystemSettingsDataAsset
    {

        protected const string SETTINGS_DATA_ASSET_DIR = "Resources/Settings";
        protected const string SETTINGS_DATA_ASSET_FILE_EXTENSION = ".asset";
        
        protected abstract string SettingsDataAssetSubDir { get; }
        protected abstract string SettingsDataAssetFileName { get; }

        public string SettingsDataAssetUnityPath =>
            Path.Combine(SETTINGS_DATA_ASSET_DIR, SettingsDataAssetSubDir, SettingsDataAssetFileName) +
            SETTINGS_DATA_ASSET_FILE_EXTENSION;

        private static T _globalInstance;
        protected static T GlobalInstance => _globalInstance ??= new T();
        
        private static U _globalDataAssetInstance;
        protected static U GlobalDataAssetInstance
        {
            get
            {
                if (!_globalDataAssetInstance)
                    LoadGlobalDataAssetInstance();

                return _globalDataAssetInstance;
            }
        }

#if !UNITY_EDITOR
        private static void LoadGlobalDataAssetInstance()
        {
            m_globalDataAssetInstance = Resources.Load<U>(GlobalInstance.SettingsDataAssetUnityPath);
            if (!m_globalDataAssetInstance)
                throw new NotImplementedException();
        }
#endif
        
    }

    public abstract class SystemSettingsDataAsset : ScriptableObject { }

}
