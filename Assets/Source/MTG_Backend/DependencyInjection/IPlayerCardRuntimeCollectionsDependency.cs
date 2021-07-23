namespace MTG.Backend
{

    public interface IPlayerCardRuntimeCollectionsDependency : IDependency
    {

        void SetDependency(PlayerCardRuntimeCollections playerCardRuntimeCollections);

        [Dependency] PlayerCardRuntimeCollections PlayerCardRuntimeCollectionsDependency { get; }

    }

}
