using System;

namespace MTG.Backend
{

    public abstract class CardRuntime_Creature : CardRuntime
    {

        public CardData_Creature CreatureCardData => m_cardData as CardData_Creature;

        public override void SetDependency(CardData cardData)
        {
            if (!(cardData is CardData_Creature))
                throw new Exception();

            m_cardData = cardData;
        }
    }

}
