namespace MTG.Backend
{

    public interface IMatchProcessorDependency : IDependency
    {

        void SetDependency(MatchProcessor matchProcessor);

        [Dependency] MatchProcessor MatchProcessorDependency { get; }

    }

}
