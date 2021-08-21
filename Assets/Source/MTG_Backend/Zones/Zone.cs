namespace MTG.Backend
{
    
    public abstract partial class Zone
    {

        protected CardRuntimeCollection m_containedCards;
        public CardRuntimeCollection ContainedCards => m_containedCards;

        public abstract bool IsPublic { get; }
        public abstract bool IsShared { get; }
        public abstract bool IsOrdered { get; }

    }
    
    public abstract partial class Zone : ICardRuntimeCollectionDependency
    {

        public void SetDependency(CardRuntimeCollection cardRuntimeCollection) => m_containedCards = cardRuntimeCollection;

        public CardRuntimeCollection CardRuntimeCollectionDependency => m_containedCards;

    }
    
}
