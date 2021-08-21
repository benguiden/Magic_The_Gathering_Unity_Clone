using System;
using System.Collections.Generic;
using System.Linq;

namespace MTG.Backend
{

    public abstract partial class RoundProcessor
    {

        public int RoundNumber { get; private set; }
        
        private TurnProcessor[] m_turns;

        private int m_currentTurnIndex = -1;

        public TurnProcessor CurrentTurn =>
            m_turns != null && m_currentTurnIndex >= 0 && m_currentTurnIndex < m_turns.Length
                ? m_turns[m_currentTurnIndex]
                : null;

        public bool IsActive
        {
            get => ActiveInstance == this;
            private set
            {
                if (value && !IsActive)
                    SetAsSingleActiveInstance();
                else if (!value && IsActive)
                    ActiveInstance = null;
            }
        }
        
        public static implicit operator bool(RoundProcessor roundProcessor) => roundProcessor != null;

        public void StartFirstRound()
        {
            if (RoundNumber != 0)
                throw new NotImplementedException();

            m_currentTurnIndex = 0;
            
            StartNextRound();
        }
        
        protected void StartNextRound()
        {
            if (ActiveInstance != this)
                SetAsSingleActiveInstance();

            RoundNumber++;

            if (m_turns.Length == 0)
                throw new NotImplementedException();
            
            m_currentTurnIndex = 0;

            m_turns[0].StartTurn();
        }

        public void StartNextTurn()
        {
            if (!IsActive)
                return;

            m_currentTurnIndex++;

            if (m_currentTurnIndex >= m_turns.Length)
            {
                StartNextRound();
                return;
            }
            
            CurrentTurn.StartTurn();
        }

    }

    public abstract partial class RoundProcessor : ITurnProcessorsDependency
    {
        
        public void SetDependency(IEnumerable<TurnProcessor> turnProcessors) => m_turns = turnProcessors.ToArray();

        public IEnumerable<TurnProcessor> TurnProcessorsDependency => m_turns.AsEnumerable();
        
    }

    public abstract partial class RoundProcessor : IMatchProcessorDependency, IMatchProcessorOwnable
    {
        
        protected MatchProcessor m_owningMatchProcessor;

        public MatchProcessor OwningMatchProcessor => m_owningMatchProcessor;

        public void SetDependency(MatchProcessor matchProcessor) => m_owningMatchProcessor = matchProcessor;

        public MatchProcessor MatchProcessorDependency => m_owningMatchProcessor;
        
    }
        
    public abstract partial class RoundProcessor : ISingleActiveInstance
    {

        public static RoundProcessor ActiveInstance { get; private set; }
        
        public void SetAsSingleActiveInstance()
        {
            if (ActiveInstance)
                throw new AlreadySingleActiveInstance();

            ActiveInstance = this;
        }
        
    }

}
