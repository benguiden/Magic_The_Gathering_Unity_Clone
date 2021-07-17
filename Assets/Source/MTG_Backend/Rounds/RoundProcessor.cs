using System.Collections.Generic;
using System.Linq;

namespace MTG
{

    namespace Backend
    {

        public abstract partial class RoundProcessor
        {

            private TurnProcessor[] m_turns;

            private int m_currentTurnIndex = -1;
            
            public TurnProcessor CurrentTurn =>
                m_turns != null && m_currentTurnIndex >= 0 && m_currentTurnIndex < m_turns.Length
                    ? m_turns[m_currentTurnIndex]
                    : null;

        }

        public abstract partial class RoundProcessor : ITurnProcessorsDependencies
        {
            public void SetDependency(IEnumerable<TurnProcessor> turnProcessors) => m_turns = turnProcessors.ToArray();

            public IEnumerable<TurnProcessor> TurnProcessorsDependency => m_turns.AsEnumerable();
        }
        
    }

}
