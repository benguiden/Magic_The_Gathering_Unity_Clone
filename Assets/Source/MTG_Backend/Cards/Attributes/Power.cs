///TODO: Create exception for invalid card data

using System;
using Newtonsoft.Json;

namespace MTG.Backend
{

    public interface ICardAttribute_Power : ICardAttribute
    {
        
        [JsonIgnore]
        public CardPower Power { get; }
        
    }
    
    [Serializable]
    public struct CardPower
    {

        [JsonProperty]
        private int m_powerValue;

        [JsonIgnore]
        public int Value
        {
            get => m_powerValue;
            set
            {
                if (value < 0)
                    throw new Exception();

                m_powerValue = value;
            }
        }

        public CardPower(int powerValue)
        {
            m_powerValue = 0;
            Value = powerValue;
        }

        public static implicit operator CardPower(int powerValue) => new CardPower(powerValue);
        public static implicit operator int(CardPower power) => power.Value;

        public override string ToString() => m_powerValue.ToString();

    }

}
