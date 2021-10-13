using MTG.Backend;
using UnityEngine;

namespace MTG.FrontendLite
{
    
    public class Card_Widget : MonoBehaviour
    {

        [Header("Child Widgets")]
        
        [SerializeField]
        private ManaCost_Widget m_manaCostWidget;
        public ManaCost_Widget ManaCostWidget => m_manaCostWidget;
        
        private CardRuntime m_backendCardRuntime;

        //Implement init function for this class and mana cost widget class that is called from init here, init here is where you check if the card data has a mana cost
        //The mana cost widget shouldn't contain information about the card data it should just have a public function saying to generate UI for a particular mana cost
        
        private void Initialized()
        {
            if (m_backendCardRuntime.CardData.HasManaCost(out ManaCost manaCost))
            {
                ManaCostWidget.GenerateUI(manaCost);
            }
        }
        
    }
    
}
