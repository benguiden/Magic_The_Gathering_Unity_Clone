namespace MTG.Backend
{

    public interface IRoundProcessorOwnable
    {

        public RoundProcessor OwningRoundProcessor { get; }

    }

}
