namespace MTG.Backend
{

    public interface ITurnProcessorOwnable
    {

        public TurnProcessor OwningTurnProcessor { get; }

    }

}

