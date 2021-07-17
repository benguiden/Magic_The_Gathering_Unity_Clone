using System;

namespace MTG
{

    namespace Backend
    {

        public abstract partial class TurnPhase
        {

            private readonly TurnProcessor m_owningTurnProcessor;
            
            private PhaseStep[] m_steps;
            
            private int m_currentStepIndex = -1;
            
            public PhaseStep CurrentStep =>
                m_steps != null && m_currentStepIndex >= 0 && m_currentStepIndex < m_steps.Length
                    ? m_steps[m_currentStepIndex]
                    : null;
            
            public bool IsActive { get; private set; } = false;

            public TurnPhase(TurnProcessor turnTurnProcessor)
            {
                m_owningTurnProcessor = turnTurnProcessor;
                m_steps = ImplementPhaseSteps();
            }

            protected abstract PhaseStep[] ImplementPhaseSteps();

            public abstract TurnPhase Copy(TurnProcessor turnTurnProcessor);
            
            public void Enter()
            {
                IsActive = true;
                EnterImplemented();
            }
            
            public void Exit()
            {
                IsActive = false;
                ExitImplemented();
            }

            protected abstract void EnterImplemented();
            protected abstract void ExitImplemented();

            protected void NextPhase()
            {
                if (m_owningTurnProcessor == null)
                    throw new NullReferenceException();
                
                m_owningTurnProcessor.NextPhase();
            }
            
            public void ExecuteNextStep()
            {
                if (!IsActive)
                    return;
                
                CurrentStep.Execute();
                
                m_currentStepIndex++;
                
                if (m_currentStepIndex >= m_steps.Length)
                {
                    NextPhase();
                }
            }

        }

    }

}