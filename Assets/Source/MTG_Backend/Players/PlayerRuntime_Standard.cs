using System;

namespace MTG.Backend
{

    public class PlayerRuntime_Standard : PlayerRuntime
    {

        public PlayerCardRuntimeCollections CardCollectionsStandard => m_cardCollections as PlayerCardRuntimeCollections_Standard;

        public override void SetDependency(PlayerCardRuntimeCollections playerCardRuntimeCollections)
        {
            if (!(playerCardRuntimeCollections is PlayerCardRuntimeCollections_Standard))
                throw new Exception();

            m_cardCollections = playerCardRuntimeCollections;
        }

    }

}
