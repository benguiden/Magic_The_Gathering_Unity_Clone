using MTG.Backend.TurnPhases;

namespace MTG.Backend
{

    public class TurnProcessor_Standard : TurnProcessor
    {

        protected override TurnPhase[] ImplementTurnPhases()
        {
            return new TurnPhase[]
            {
                new TurnPhase_StandardBeginningPhase(),
                new TurnPhase_StandardMainPhase(),
                new TurnPhase_StandardCombatPhase(),
                new TurnPhase_StandardMainPhase(),
                new TurnPhase_StandardEndingPhase()
            };
        }

        protected override void StartTurnImplemented() { }

        protected override void EndImplemented() { }

    }

}
