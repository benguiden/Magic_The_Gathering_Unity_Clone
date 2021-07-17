using MTG.Backend.TurnPhases.PhaseSteps;

namespace MTG
{

    namespace Backend
    {

        namespace TurnPhases
        {

            public class TurnPhase_StandardBeginningPhase : TurnPhase
            {
                
                public TurnPhase_StandardBeginningPhase(TurnProcessor turnTurnProcessor) : base(turnTurnProcessor)
                {
                }

                protected override PhaseStep[] ImplementPhaseSteps()
                {
                    return new PhaseStep[]
                    {
                        new PhaseStep_Untap(),
                        new PhaseStep_Upkeep(),
                        new PhaseStep_Draw()
                    };
                }

                public override TurnPhase Copy(TurnProcessor turnTurnProcessor) =>
                    new TurnPhase_StandardBeginningPhase(turnTurnProcessor);

                protected override void EnterImplemented() { }

                protected override void ExitImplemented() { }
                
            }

        }

    }

}
