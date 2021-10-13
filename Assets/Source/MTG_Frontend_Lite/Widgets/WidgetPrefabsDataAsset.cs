using UnityEngine;

namespace MTG.FrontendLite
{
    
    [CreateAssetMenu(fileName = "WidgetPrefabs", menuName = "MTG Frontend Lite/Data/Widget Prefabs", order = 0)]
    public class WidgetPrefabsDataAsset : ScriptableObject
    {

        [SerializeField]
        private GameObject m_cardPrefab;

        public GameObject CardPrefab => m_cardPrefab;

        #region Mana Cost Prefabs
        
        [Header("Mana Cost Prefabs")]
        
        [SerializeField]
        private GameObject m_manaCostGenericPrefab;

        public GameObject ManaCostGenericPrefab => m_manaCostGenericPrefab;
        
        [SerializeField]
        private GameObject m_manaCostBlackPrefab;

        public GameObject ManaCostBlackPrefab => m_manaCostBlackPrefab;
        
        [SerializeField]
        private GameObject m_manaCostBluePrefab;

        public GameObject ManaCostBluePrefab => m_manaCostBluePrefab;
        
        [SerializeField]
        private GameObject m_manaCostGreenPrefab;

        public GameObject ManaCostGreenPrefab => m_manaCostGreenPrefab;
        
        [SerializeField]
        private GameObject m_manaCostRedPrefab;

        public GameObject ManaCostRedPrefab => m_manaCostRedPrefab;
        
        [SerializeField]
        private GameObject m_manaCostWhitePrefab;

        public GameObject ManaCostWhitePrefab => m_manaCostWhitePrefab;

        [SerializeField]
        private float m_manaCostWidgetOffset;

        public float ManaCostWidgetOffset => m_manaCostWidgetOffset;

        #endregion

    }
    
}
