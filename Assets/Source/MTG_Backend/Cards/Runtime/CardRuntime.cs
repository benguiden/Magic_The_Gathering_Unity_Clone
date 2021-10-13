using System;

namespace MTG.Backend
{

    public abstract partial class CardRuntime
    {

        protected CardData m_cardData;
        public CardData CardData => m_cardData;
        
        #region Tapping
        
        public abstract bool IsTapable { get; }
        public abstract bool IsTapped { get; protected set; }
        
        public void Tap(bool assertIsUntapped = true)
        {
            if (!IsTapable)
                throw new NotImplementedException();
            
            if (!IsTapped)
                IsTapped = true;
            else if (assertIsUntapped)
                throw new NotImplementedException();
        }

        public void Untap(bool assertIsTapped = true)
        {
            if (!IsTapable)
                throw new NotImplementedException();
            
            if (IsTapped)
                IsTapped = false;
            else if (assertIsTapped)
                throw new NotImplementedException();
        }
        
        #endregion

    }

    public abstract partial class CardRuntime : ICardDataDependency
    {

        public virtual void SetDependency(CardData cardData) => m_cardData = cardData;

        public CardData CardDataDependency => m_cardData;

    }

}
