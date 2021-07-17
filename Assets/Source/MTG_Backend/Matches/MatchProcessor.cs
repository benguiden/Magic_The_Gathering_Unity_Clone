namespace MTG
{
    
    namespace Backend
    {
        
        public abstract partial class MatchProcessor
        {
            
            //Handle win/lose conditions
            //Iterate match states (setup, playing)
            //Iterate round processors
            //Wait for frontend delays

            private RoundProcessor m_roundProcessor;

        }

        public abstract partial class MatchProcessor : IRoundProcessorDependency
        {

            public void SetDependency(RoundProcessor roundProcessor) => m_roundProcessor = roundProcessor;

            public RoundProcessor RoundProcessorDependency => m_roundProcessor;

        }

    }

}