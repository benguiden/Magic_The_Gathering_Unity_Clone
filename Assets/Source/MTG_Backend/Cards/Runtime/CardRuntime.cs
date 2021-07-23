namespace MTG.Backend
{

    public abstract partial class CardRuntime
    {

        protected CardData m_cardData;
        public CardData CardData => m_cardData;

    }

    public abstract partial class CardRuntime : ICardPileOwnable
    {

        private CardRuntimeCollection m_owningCardRuntimeCollection;

        public CardRuntimeCollection OwningCardRuntimeCollection => m_owningCardRuntimeCollection;

    }

    public abstract partial class CardRuntime : ICardRuntimeCollectionDependency
    {

        public void SetDependency(CardRuntimeCollection cardRuntimeCollection) => m_owningCardRuntimeCollection = cardRuntimeCollection;

        public CardRuntimeCollection CardRuntimeCollectionDependency => m_owningCardRuntimeCollection;

    }

    public abstract partial class CardRuntime : ICardDataDependency
    {

        public virtual void SetDependency(CardData cardData) => m_cardData = cardData;

        public CardData CardDataDependency => m_cardData;

    }

}
