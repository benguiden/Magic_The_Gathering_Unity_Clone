using System;

namespace MTG
{
    namespace Backend
    {

        public enum CardType
        {
            Creature,
            Land
        }
        
        public abstract class CardData
        {

            public Guid Id;
            public string Name;
            public abstract CardType CardType { get; }

        }
        
    }

}
