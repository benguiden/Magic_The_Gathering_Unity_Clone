///TODO: Create exception for invalid card data

using System;
using Newtonsoft.Json;

namespace MTG.Backend
{

    public interface ICardAttribute_Toughness : ICardAttribute
    {
        
        [JsonIgnore]
        public CardToughness Toughness { get; }
        
    }

    [Serializable]
    public struct CardToughness
    {

        [JsonProperty]
        private int m_toughnessValue;

        [JsonIgnore]
        public int Value
        {
            get => m_toughnessValue;
            set
            {
                if (value < 0)
                    throw new Exception();

                m_toughnessValue = value;
            }
        }

        public CardToughness(int toughnessValue)
        {
            m_toughnessValue = 0;
            Value = toughnessValue;
        }

        public static implicit operator CardToughness(int toughnessValue) => new CardToughness(toughnessValue);
        public static implicit operator int(CardToughness toughness) => toughness.Value;

        public override string ToString() => m_toughnessValue.ToString();
        
    }

}
