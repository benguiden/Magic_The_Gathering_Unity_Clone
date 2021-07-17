///TODO: Needs to be owned to a player

namespace MTG
{

    namespace Backend
    {

        public abstract partial class TurnProcessor : IPlayerRuntimeOwnable
        {

            private PlayerRuntime m_owningPlayer;
            public PlayerRuntime OwningPlayer => m_owningPlayer; 
            
            private TurnPhase[] m_phases;

            private int m_currentPhaseIndex = -1;

            public TurnPhase CurrentPhase =>
                m_phases != null && m_currentPhaseIndex >= 0 && m_currentPhaseIndex < m_phases.Length
                    ? m_phases[m_currentPhaseIndex]
                    : null;

            public bool IsActive { get; private set; } = false;

            public TurnProcessor()
            {
                m_phases = ImplementTurnPhases();
            }

            protected abstract TurnPhase[] ImplementTurnPhases();

            public virtual TurnProcessor Copy(PlayerRuntime owningPlayer)
            {
                return new TurnProcessor_Standard()
                {
                    m_owningPlayer = owningPlayer,
                    m_phases = CopyPhases()
                };
            }
            
            protected TurnPhase[] CopyPhases()
            {
                var copiedPhases = new TurnPhase[m_phases.Length];
                for (int i = 0; i < copiedPhases.Length; i++)
                {
                    copiedPhases[i] = m_phases[i].Copy(this);
                }
                
                return copiedPhases;
            }


            public void StartTurn()
            {
                IsActive = true;
                StartTurnImplemented();
            }

            public void EndTurn()
            {
                CurrentPhase?.Exit();
                m_currentPhaseIndex = -1;
                IsActive = false;
                EndImplemented();
            }

            protected abstract void StartTurnImplemented();
            protected abstract void EndImplemented();
            
            public virtual void NextPhase()
            {
                if (!IsActive)
                    return;
                
                CurrentPhase.Exit();
                
                m_currentPhaseIndex++;
                if (m_currentPhaseIndex >= m_phases.Length)
                {
                    EndTurn();
                    return;
                }
                
                CurrentPhase.Enter();
            }
            
        }

        public abstract partial class TurnProcessor : IPlayerRuntimeDependency
        {
            
            public void SetDependency(PlayerRuntime playerRuntime) => m_owningPlayer = playerRuntime;

            public PlayerRuntime PlayerRuntimeDependency => OwningPlayer;
            
        } 

    }

}