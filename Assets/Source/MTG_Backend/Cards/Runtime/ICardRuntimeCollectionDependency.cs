namespace MTG.Backend
{

    public interface ICardRuntimeCollectionDependency : IDependency
    {

        void SetDependency(CardRuntimeCollection cardRuntimeCollection);

        [Dependency] CardRuntimeCollection CardRuntimeCollectionDependency { get; }

    }

}
