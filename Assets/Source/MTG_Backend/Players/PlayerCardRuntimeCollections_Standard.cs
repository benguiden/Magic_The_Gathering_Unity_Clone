namespace MTG.Backend
{

    public partial class PlayerCardRuntimeCollections_Standard : PlayerCardRuntimeCollections
    {

        private CardRuntimeCollection m_drawableDeck;
        public CardRuntimeCollection DrawableDeck => m_drawableDeck;

        private CardRuntimeCollection m_hand;
        public CardRuntimeCollection Hand => m_hand;

        private CardRuntimeCollection m_battlefield;
        public CardRuntimeCollection Battlefield => m_battlefield;

        private CardRuntimeCollection m_graveyard;
        public CardRuntimeCollection Graveyard => m_graveyard;

        private CardRuntimeCollection m_exiled;
        public CardRuntimeCollection Exiled => m_exiled;

        public void DrawCard(CardRuntime card)
        {
            DrawableDeck.TransferCard(card, Hand);
        }

        public void PlayCard(CardRuntime card)
        {
            Hand.TransferCard(card, Battlefield);
        }

    }

    public partial class PlayerCardRuntimeCollections_Standard : PlayerCardRuntimeCollections
    {

        public override void SetDependency(CardRuntimeCollection cardRuntimeCollection) => m_drawableDeck = cardRuntimeCollection;

        public override CardRuntimeCollection CardRuntimeCollectionDependency => m_drawableDeck;

    }

}
