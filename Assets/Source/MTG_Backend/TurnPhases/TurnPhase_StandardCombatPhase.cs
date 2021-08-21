using MTG.Backend.TurnPhases.PhaseSteps;

namespace MTG.Backend.TurnPhases
{

    public class TurnPhase_StandardCombatPhase : TurnPhase
    {

        protected override PhaseStep[] ImplementPhaseSteps()
        {
            return new PhaseStep[]
            {
                new PhaseStep_CombatBeginning(),
                new PhaseStep_CombatDeclareAttackers(),
                new PhaseStep_CombatDeclareBlockers(),
                new PhaseStep_CombatDamage(),
                new PhaseStep_CombatEnding()
            };
        }

        protected override void EnterImplemented() { }

        protected override void ExitImplemented() { }

    }

}
