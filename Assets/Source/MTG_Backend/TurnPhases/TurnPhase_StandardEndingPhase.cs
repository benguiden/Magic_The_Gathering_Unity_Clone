using MTG.Backend.TurnPhases.PhaseSteps;

namespace MTG.Backend.TurnPhases
{

    public class TurnPhase_StandardEndingPhase : TurnPhase
    {

        protected override PhaseStep[] ImplementPhaseSteps()
        {
            return new PhaseStep[]
            {
                new PhaseStep_Ending(),
                new PhaseStep_Cleanup()
            };
        }

        protected override void EnterImplemented() { }

        protected override void ExitImplemented() { }

    }

}
