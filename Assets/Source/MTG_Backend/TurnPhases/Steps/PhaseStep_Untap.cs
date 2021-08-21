namespace MTG.Backend.TurnPhases.PhaseSteps
{

    /// <remarks>
    /// • All permanents with phasing controlled by the active player phase out, and all phased-out permanents that were controlled by the active player simultaneously phase in.
    /// • The active player determines which permanents controlled by that player untap, then untaps all those permanents simultaneously. (The player will untap all permanents they control unless a card effect prevents this.)
    /// </remarks>
    public class PhaseStep_Untap : PhaseStep
    {

        public override void Execute()
        {

            foreach (CardRuntime Card in (OwningPlayer.Zones as PlayerZones_Standard).Battlefield.ContainedCards.ContainedCards)
            {
                if (Card.IsTapable && Card.IsTapped)
                    Card.Untap();
            }
            
        }
        
    }

}
