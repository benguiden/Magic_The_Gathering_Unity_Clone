using System;

namespace MTG.Backend
{

    public abstract partial class TurnPhase
    {

        private PhaseStep[] m_steps;

        private int m_currentStepIndex = -1;

        public PhaseStep CurrentStep =>
            m_steps != null && m_currentStepIndex >= 0 && m_currentStepIndex < m_steps.Length
                ? m_steps[m_currentStepIndex]
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

        public TurnPhase()
        {
            m_steps = ImplementPhaseSteps();
            foreach (PhaseStep step in m_steps)
            {
                step.SetDependency(this);
                DependencyVerifying.VerifyDependencies(step);
            }
        }

        public static implicit operator bool(TurnPhase turnPhase) => turnPhase != null;
        
        protected abstract PhaseStep[] ImplementPhaseSteps();

        public void Enter()
        {
            IsActive = true;
            m_currentStepIndex = 0;
            EnterImplemented();
            if (CurrentStep)
                CurrentStep.SetAsSingleActiveInstance();
            //CurrentStep.Execute();
        }

        public void Exit()
        {
            PhaseStep.TempClearSingleInstance();
            m_currentStepIndex = -1;
            IsActive = false;
            ExitImplemented();
        }

        protected abstract void EnterImplemented();
        protected abstract void ExitImplemented();

        protected void StartNextPhase()
        {
            if (m_owningTurnProcessor == null)
                throw new NullReferenceException();

            m_owningTurnProcessor.StartNextPhase();
        }

        public void ExecuteNextStep()
        {
            if (!IsActive)
                return;

            PhaseStep.TempClearSingleInstance();

            m_currentStepIndex++;

            if (m_currentStepIndex >= m_steps.Length)
            {
                StartNextPhase();
            }

            if (CurrentStep)
                CurrentStep.SetAsSingleActiveInstance();
            //CurrentStep.Execute();
        }

    }
    
    public abstract partial class TurnPhase : ITurnProcessorDependency, ITurnProcessorOwnable
    {
        
        protected TurnProcessor m_owningTurnProcessor;
        
        public TurnProcessor OwningTurnProcessor => m_owningTurnProcessor;

        public void SetDependency(TurnProcessor turnProcessor) => m_owningTurnProcessor = turnProcessor;

        public TurnProcessor TurnProcessorDependency => m_owningTurnProcessor;

    }

    public abstract partial class TurnPhase : IPlayerRuntimeOwnable
    {

        public PlayerRuntime OwningPlayer => m_owningTurnProcessor.OwningPlayer;

    }
    
    public abstract partial class TurnPhase : ISingleActiveInstance
    {
        
        public static TurnPhase ActiveInstance { get; private set; }
        
        public void SetAsSingleActiveInstance()
        {
            if (ActiveInstance)
                throw new AlreadySingleActiveInstance();

            ActiveInstance = this;
        }
        
    }

}