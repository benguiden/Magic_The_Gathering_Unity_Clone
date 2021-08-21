///TODO: Needs refactoring -> Maybe make a runtime card collection abstract class

using System;
using System.Collections.Generic;

namespace MTG.Backend
{

    public partial class CardRuntimeCollection
    {

        private List<CardRuntime> m_containedCards;
        public CardRuntime[] ContainedCards => m_containedCards.ToArray();

        public CardRuntimeCollection(CardRuntime[] containedCards)
        {
            m_containedCards = new List<CardRuntime>(containedCards);
        }

        public static implicit operator CardRuntimeCollection(CardRuntime[] containedCards) => new CardRuntimeCollection(containedCards);

        public bool Contains(CardRuntime cardRuntime) => m_containedCards.Contains(cardRuntime);

        public void TransferCard(CardRuntime card, CardRuntimeCollection otherRuntimeCollection)
        {
            if (otherRuntimeCollection == this)
                throw new Exception();

            if (!m_containedCards.Contains(card))
                throw new Exception();

            if (otherRuntimeCollection.Contains(card))
                throw new Exception();

            m_containedCards.Remove(card);
            otherRuntimeCollection.m_containedCards.Add(card);
        }

    }

    public partial class CardRuntimeCollection : IPlayerRuntimeDependency
    {

        public void SetDependency(PlayerRuntime playerRuntime) => m_ownerPlayer = playerRuntime;

        public PlayerRuntime PlayerRuntimeDependency => m_ownerPlayer;

    }
    
    public partial class CardRuntimeCollection : IPlayerRuntimeOwnable
    {

        private PlayerRuntime m_ownerPlayer;
        
        public PlayerRuntime OwningPlayer => m_ownerPlayer;

    }

}
