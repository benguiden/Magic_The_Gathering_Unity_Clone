namespace MTG.Backend
{

    public abstract partial class PlayerRuntime
    {

        private PlayerLife m_life;
        private PlayerLife Life => m_life;

        private TurnProcessor m_turnProcessor;
        public TurnProcessor TurnProcessor => m_turnProcessor;

        protected PlayerZones m_zones;
        public PlayerZones Zones => m_zones;

    }

    public abstract partial class PlayerRuntime : ITurnProcessorDependency
    {

        public void SetDependency(TurnProcessor turnProcessor) => m_turnProcessor = turnProcessor;

        public TurnProcessor TurnProcessorDependency => m_turnProcessor;

    }

    public abstract partial class PlayerRuntime : IPlayerZonesDependency
    {

        public virtual void SetDependency(PlayerZones playerZones) => m_zones = playerZones;

        public PlayerZones PlayerZonesDependency => m_zones;

    }

}
