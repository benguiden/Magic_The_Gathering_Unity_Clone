namespace MTG.Backend
{

    public interface ITurnProcessorDependency : IDependency
    {

        void SetDependency(TurnProcessor turnProcessor);

        [Dependency] TurnProcessor TurnProcessorDependency { get; }

    }

}
