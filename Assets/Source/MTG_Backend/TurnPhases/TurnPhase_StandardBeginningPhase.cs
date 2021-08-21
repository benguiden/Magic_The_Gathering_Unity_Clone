using MTG.Backend.TurnPhases.PhaseSteps;

namespace MTG.Backend.TurnPhases
{

    public class TurnPhase_StandardBeginningPhase : TurnPhase
    {

        protected override PhaseStep[] ImplementPhaseSteps()
        {
            return new PhaseStep[]
            {
                new PhaseStep_Untap(),
                new PhaseStep_Upkeep(),
                new PhaseStep_Draw()
            };
        }

        protected override void EnterImplemented() { }

        protected override void ExitImplemented() { }

    }

}
