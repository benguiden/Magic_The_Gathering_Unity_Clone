namespace MTG.Backend
{

    public interface IPlayerZonesDependency : IDependency
    {

        void SetDependency(PlayerZones playerZones);

        [Dependency] PlayerZones PlayerZonesDependency { get; }

    }

}
