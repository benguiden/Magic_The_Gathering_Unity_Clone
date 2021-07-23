using System;
using Newtonsoft.Json;
using UnityEngine;

namespace MTG.Backend
{

    [Serializable]
    [JsonConverter(typeof(CardData_IO.Json.CardDataConverter))]
    public abstract class CardData :  ICardAttribute_DisplayName, ICardAttribute_Guid
    {
        
        [JsonProperty(Order = CardData_IO.Json.CARD_TYPE_JSON_ORDER, PropertyName = CardData_IO.Json.CARD_TYPE_JSON_NAME)]
        public abstract CardType CardType { get; }

        [SerializeField]
        [CardAttributeDefaultValue(typeof(ICardAttribute_DisplayName))]
        [JsonProperty(Order = CardData_IO.Json.DISPLAY_NAME_JSON_ORDER, PropertyName = CardData_IO.Json.DISPLAY_NAME_JSON_NAME)]
        protected string m_displayName;
        
        public string DisplayName => m_displayName;

        [SerializeField]
        [CardAttributeDefaultValue(typeof(ICardAttribute_Guid))]
        [JsonProperty(Order = CardData_IO.Json.GUID_JSON_ORDER, PropertyName = CardData_IO.Json.GUID_JSON_NAME)]
        protected Guid m_guid;
        
        public Guid Guid => m_guid;
        
    }

}
