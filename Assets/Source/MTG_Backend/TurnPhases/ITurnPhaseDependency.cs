namespace MTG.Backend
{

    public interface ITurnPhaseDependency : IDependency
    {

        void SetDependency(TurnPhase turnPhase);

        [Dependency] TurnPhase TurnPhaseDependency { get; }

    }

}
