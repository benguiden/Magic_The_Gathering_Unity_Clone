namespace MTG.Backend
{
    public enum CardType
    {
        Invalid = 0,
        Land = 1,
        Creature = 2,
    }

    public static class CardTypeExtensions
    {

        private const int MAX_VALID_TYPE_INDEX = 2;

        public static bool IsValid(this CardType cardType) => (int) cardType > 0 && (int) cardType <= MAX_VALID_TYPE_INDEX;

    }
    

}