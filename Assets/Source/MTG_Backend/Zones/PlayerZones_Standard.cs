namespace MTG.Backend
{

    public class PlayerZones_Standard : PlayerZones
    {

        private Zone m_library;
        public Zone Library => m_library;

        private Zone m_hand;
        public Zone Hand => m_hand;

        private Zone_Battlefield m_battlefield;
        public Zone_Battlefield Battlefield => m_battlefield;

        private Zone m_graveyard;
        public Zone Graveyard => m_graveyard;

        private Zone m_stack;
        public Zone Stack => m_stack;
        
        private Zone m_exile;
        public Zone Exile => m_exile;
        
        private Zone m_command;
        public Zone Command => m_command;
        
        private Zone m_ante;
        public Zone Ante => m_ante;

        public void DrawCard(CardRuntime card)
        {
            Library.ContainedCards.TransferCard(card, Hand.ContainedCards);
        }

        public void PlayCard(CardRuntime card)
        {
            Hand.ContainedCards.TransferCard(card, Battlefield.ContainedCards);
        }

    }

}
