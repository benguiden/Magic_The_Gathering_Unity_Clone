using MTG.Core;

namespace MTG.FrontendLite
{
    
    public class DataAssetSettings : SystemSettings<DataAssetSettings, DataAssetSettingsDataAsset>
    {

        protected override string SettingsDataAssetSubDir => "MTG_Frontend_Lite";
        protected override string SettingsDataAssetFileName => "DataAssetSettings";

        public static WidgetPrefabsDataAsset WidgetPrefabsDataAsset => GlobalDataAssetInstance.WidgetPrefabsDataAsset;

    }
    
}
