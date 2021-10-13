using MTG.Core;
using UnityEngine;

namespace MTG.FrontendLite
{
    
    public class DataAssetSettingsDataAsset : SystemSettingsDataAsset
    {
        
        [SerializeField]
        private WidgetPrefabsDataAsset m_widgetPrefabsDataAsset;
        
        public WidgetPrefabsDataAsset WidgetPrefabsDataAsset => m_widgetPrefabsDataAsset;
        
    }
    
}