namespace MTG
{
    
    namespace Backend
    {

        public abstract partial class PlayerRuntime
        {

            private PlayerLife m_life;
            private PlayerLife Life => m_life;

            private TurnProcessor m_turnProcessor;
            public TurnProcessor TurnProcessor => m_turnProcessor;

            protected PlayerCardRuntimeCollections m_cardCollections;
            public PlayerCardRuntimeCollections CardCollections => m_cardCollections;
            
        }

        public abstract partial class PlayerRuntime : ITurnProcessorDependencies
        {
            
            public void SetDependency(TurnProcessor turnProcessor) => m_turnProcessor = turnProcessor;

            public TurnProcessor TurnProcessorDependency => m_turnProcessor;
            
        }

        public abstract partial class PlayerRuntime : IPlayerCardRuntimeCollectionsDependency
        {

            public virtual void SetDependency(PlayerCardRuntimeCollections playerCardRuntimeCollections) => m_cardCollections = playerCardRuntimeCollections;

            public PlayerCardRuntimeCollections PlayerCardRuntimeCollectionsDependency => m_cardCollections;

        }
        
    }
    
}
