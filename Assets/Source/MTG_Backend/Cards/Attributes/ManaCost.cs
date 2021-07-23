///TODO: Create exception for invalid card data

using System;
using Newtonsoft.Json;

namespace MTG.Backend
{

    public interface ICardAttribute_ManaCost : ICardAttribute
    {
        
        [JsonIgnore]
        public ManaCost ManaCost { get; }
        
    }
    
    public enum ManaColour
    {
        Generic,
        Black,
        Blue,
        Green,
        Red,
        White
    }

    [Serializable]
    public struct ManaCost
    {
        /// 00     00000     00000     00000     00000     00000     00000
        /// --     white      red      green      blue     black    generic

        private const int SIZE_BITS = 0x1F;

        private const int GENERIC_BITS      = 0x1F;
        private const int BLACK_BITS        = 0x3E0;
        private const int BLUE_BITS         = 0x7C00;
        private const int GREEN_BITS        = 0xF8000;
        private const int RED_BITS          = 0x1F00000;
        private const int WHITE_BITS        = 0x3E000000;

        private const int GENERIC_BIT_SHIFTS = 0;
        private const int BLACK_BIT_SHIFTS = 5;
        private const int BLUE_BIT_SHIFTS = 10;
        private const int GREEN_BIT_SHIFTS = 15;
        private const int RED_BIT_SHIFTS = 20;
        private const int WHITE_BIT_SHIFTS = 25;

        [JsonProperty]
        private int m_unionCostValue;

        public ManaCost(int genericCost)
        {
            m_unionCostValue = 0;
            GenericCost = genericCost;
        }

        public ManaCost(int genericCost, int blackCost, int blueCost, int greenCost, int redCost, int whiteCost)
        {
            m_unionCostValue = 0;
            GenericCost = genericCost;
            BlackCost = blackCost;
            BlueCost = blueCost;
            GreenCost = greenCost;
            RedCost = redCost;
            WhiteCost = whiteCost;
        }
        
        [JsonIgnore]
        public int GenericCost
        {
            get => (m_unionCostValue & GENERIC_BITS) >> GENERIC_BIT_SHIFTS;
            set => m_unionCostValue = value & GENERIC_BITS;
        }

        [JsonIgnore]
        public int BlackCost
        {
            get => (m_unionCostValue & BLACK_BITS) >> BLACK_BIT_SHIFTS;
            set => m_unionCostValue =
                (m_unionCostValue & ~BLACK_BITS) | ((value & SIZE_BITS) << BLACK_BIT_SHIFTS);
        }

        [JsonIgnore]
        public int BlueCost
        {
            get => (m_unionCostValue & BLUE_BITS) >> BLUE_BIT_SHIFTS;
            set => m_unionCostValue =
                (m_unionCostValue & ~BLUE_BITS) | ((value & SIZE_BITS) << BLUE_BIT_SHIFTS);
        }

        [JsonIgnore]
        public int GreenCost
        {
            get => (m_unionCostValue & GREEN_BITS) >> GREEN_BIT_SHIFTS;
            set => m_unionCostValue =
                (m_unionCostValue & ~GREEN_BITS) | ((value & SIZE_BITS) << GREEN_BIT_SHIFTS);
        }

        [JsonIgnore]
        public int RedCost
        {
            get => (m_unionCostValue & RED_BITS) >> RED_BIT_SHIFTS;
            set => m_unionCostValue =
                (m_unionCostValue & ~RED_BITS) | ((value & SIZE_BITS) << RED_BIT_SHIFTS);
        }

        [JsonIgnore]
        public int WhiteCost
        {
            get => (m_unionCostValue & WHITE_BITS) >> WHITE_BIT_SHIFTS;
            set => m_unionCostValue =
                (m_unionCostValue & ~WHITE_BITS) | ((value & SIZE_BITS) << WHITE_BIT_SHIFTS);
        }

        [JsonIgnore]
        public int ConvertedCost => GenericCost + BlackCost + BlueCost + GreenCost + RedCost + WhiteCost;

        public int GetCost(ManaColour manaColour)
        {
            return manaColour switch
            {
                ManaColour.Generic => GenericCost,
                ManaColour.Black => BlackCost,
                ManaColour.Blue => BlueCost,
                ManaColour.Green => GreenCost,
                ManaColour.Red => RedCost,
                ManaColour.White => WhiteCost,
                _ => throw new ArgumentOutOfRangeException(nameof(manaColour), manaColour, null)
            };
        }

        public void SetCost(ManaColour manaColour, int cost)
        {
            switch (manaColour)
            {
                case ManaColour.Generic:
                    GenericCost = cost;
                    break;
                case ManaColour.Black:
                    BlackCost = cost;
                    break;
                case ManaColour.Blue:
                    BlueCost = cost;
                    break;
                case ManaColour.Green:
                    GreenCost = cost;
                    break;
                case ManaColour.Red:
                    RedCost = cost;
                    break;
                case ManaColour.White:
                    WhiteCost = cost;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(manaColour), manaColour, null);
            }
        }

        public override string ToString() => $"(Converted: {ConvertedCost}, Generic: {GenericCost}, Black: {BlackCost}, Blue: {BlueCost}, Green: {GreenCost}, Red: {RedCost}, White: {WhiteCost})";

    }

}
