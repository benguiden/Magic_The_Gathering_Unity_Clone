namespace MTG.Backend
{

    public interface IPlayerRuntimeDependency : IDependency
    {

        void SetDependency(PlayerRuntime playerRuntime);

        [Dependency] PlayerRuntime PlayerRuntimeDependency { get; }

    }

}
