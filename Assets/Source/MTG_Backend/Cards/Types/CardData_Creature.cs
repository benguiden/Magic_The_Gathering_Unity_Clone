using UnityEngine;

namespace MTG
{
    namespace Backend
    {

        public class CardData_Creature : CardData, ICardPowerToughness, ICardManaCost
        {

            public override CardType CardType => CardType.Creature;
            
            [SerializeField] private CreaturePower m_power;
            public CreaturePower Power => m_power;
            
            [SerializeField] private CreatureToughness m_toughness;
            public CreatureToughness Toughness => m_toughness;
            
            [SerializeField] private ManaCost m_manaCost;
            public ManaCost ManaCost => m_manaCost;
            
        }

    }

}
