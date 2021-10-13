using System;
using UnityEngine;

namespace MTG.FrontendLite
{
    public static class WidgetPrefabs
    {

        private static WidgetPrefabsDataAsset WidgetPrefabsDataAsset => DataAssetSettings.WidgetPrefabsDataAsset
            ? DataAssetSettings.WidgetPrefabsDataAsset
            : throw new NotImplementedException();
        
        public static GameObject CardPrefab => WidgetPrefabsDataAsset.CardPrefab;
     
        
        #region Mana Cost Prefabs
        
        public static GameObject ManaCostGenericPrefab => WidgetPrefabsDataAsset.ManaCostGenericPrefab;
        public static GameObject ManaCostBlackPrefab => WidgetPrefabsDataAsset.ManaCostBlackPrefab;
        public static GameObject ManaCostBluePrefab => WidgetPrefabsDataAsset.ManaCostBluePrefab;
        public static GameObject ManaCostGreenPrefab => WidgetPrefabsDataAsset.ManaCostGreenPrefab;
        public static GameObject ManaCostRedPrefab => WidgetPrefabsDataAsset.ManaCostRedPrefab;
        public static GameObject ManaCostWhitePrefab => WidgetPrefabsDataAsset.ManaCostWhitePrefab;
        public static float ManaCostWidgetOffset => WidgetPrefabsDataAsset.ManaCostWidgetOffset;
        
        #endregion
        
    }
}
