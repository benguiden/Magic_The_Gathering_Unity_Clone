using System;
using Newtonsoft.Json;
using UnityEngine;

namespace MTG.Backend
{

    [Serializable]
    public class CardData_Creature : CardData, ICardAttribute_ManaCost, ICardAttribute_Power, ICardAttribute_Toughness
    {

        public override CardType CardType => CardType.Creature;

        [SerializeField]
        [CardAttributeDefaultValue(typeof(ICardAttribute_ManaCost))]
        [JsonProperty(Order = CardData_IO.Json.MANA_COST_JSON_ORDER, PropertyName = CardData_IO.Json.MANA_COST_JSON_NAME)]
        private ManaCost m_manaCost;
        
        public ManaCost ManaCost => m_manaCost;
        
        [SerializeField] 
        [CardAttributeDefaultValue(typeof(ICardAttribute_Power))]
        [JsonProperty(Order = CardData_IO.Json.POWER_JSON_ORDER, PropertyName = CardData_IO.Json.POWER_JSON_NAME)]
        private CardPower m_power;
        
        public CardPower Power => m_power;
        
        [SerializeField]
        [CardAttributeDefaultValue(typeof(ICardAttribute_Toughness))]
        [JsonProperty(Order = CardData_IO.Json.TOUGHNESS_JSON_ORDER, PropertyName = CardData_IO.Json.TOUGHNESS_JSON_NAME)]
        private CardToughness m_toughness;
        
        public CardToughness Toughness => m_toughness;
        
    }

}
