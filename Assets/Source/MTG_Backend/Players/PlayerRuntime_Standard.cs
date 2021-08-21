using System;

namespace MTG.Backend
{

    public class PlayerRuntime_Standard : PlayerRuntime
    {

        public PlayerZones CardCollectionsStandard => m_zones as PlayerZones_Standard;

        public override void SetDependency(PlayerZones playerZones)
        {
            if (!(playerZones is PlayerZones_Standard))
                throw new Exception();

            m_zones = playerZones;
        }

    }

}
