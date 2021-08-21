///TODO: Needs to be owned to a player

using System;

namespace MTG.Backend
{

    public abstract partial class TurnProcessor
    {

        private TurnPhase[] m_phases;

        private int m_currentPhaseIndex = -1;

        public TurnPhase CurrentPhase =>
            m_phases != null && m_currentPhaseIndex >= 0 && m_currentPhaseIndex < m_phases.Length
                ? m_phases[m_currentPhaseIndex]
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

        public TurnProcessor()
        {
            m_phases = ImplementTurnPhases();
            foreach (TurnPhase phase in m_phases)
            {
                phase.SetDependency(this);
                DependencyVerifying.VerifyDependencies(phase);
            }
        }

        public static implicit operator bool(TurnProcessor turnProcessor) => turnProcessor != null;

        protected abstract TurnPhase[] ImplementTurnPhases();

        public void StartTurn()
        {
            IsActive = true;
            m_currentPhaseIndex = 0;
            StartTurnImplemented();
            CurrentPhase.Enter();
        }

        public void EndTurn()
        {
            CurrentPhase?.Exit();
            m_currentPhaseIndex = -1;
            IsActive = false;
            EndImplemented();
            StartNextTurn();
        }

        protected abstract void StartTurnImplemented();
        protected abstract void EndImplemented();

        protected void StartNextTurn()
        {
            if (m_owningRoundProcessor == null)
                throw new NullReferenceException();

            m_owningRoundProcessor.StartNextTurn();
        }
        
        public virtual void StartNextPhase()
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

    public abstract partial class TurnProcessor : IPlayerRuntimeDependency, IPlayerRuntimeOwnable
    {

        private PlayerRuntime m_owningPlayer;
        
        public PlayerRuntime OwningPlayer => m_owningPlayer;

        public void SetDependency(PlayerRuntime playerRuntime) => m_owningPlayer = playerRuntime;
        
        public PlayerRuntime PlayerRuntimeDependency => OwningPlayer;

    }
    
    public abstract partial class TurnProcessor : IRoundProcessorDependency, IRoundProcessorOwnable
    {

        protected RoundProcessor m_owningRoundProcessor;

        public RoundProcessor OwningRoundProcessor => m_owningRoundProcessor;

        public void SetDependency(RoundProcessor roundProcessor) => m_owningRoundProcessor = roundProcessor;

        public RoundProcessor RoundProcessorDependency => m_owningRoundProcessor;

    }
    
    public abstract partial class TurnProcessor : ISingleActiveInstance
    {
        
        public static TurnProcessor ActiveInstance { get; private set; }
        
        public void SetAsSingleActiveInstance()
        {
            if (ActiveInstance)
                throw new AlreadySingleActiveInstance();

            ActiveInstance = this;
        }
        
    }
    
}
