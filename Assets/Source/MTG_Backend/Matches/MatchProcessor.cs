using System;

namespace MTG.Backend
{

    public abstract partial class MatchProcessor
    {

        //Handle win/lose conditions
        //Iterate match states (setup, playing)
        //Iterate round processors
        //Wait for frontend delays

        private RoundProcessor m_roundProcessor;

        public virtual void StartMatch()
        {
            SetAsSingleActiveInstance();
            m_roundProcessor.StartFirstRound();
        }

    }

    public abstract partial class MatchProcessor : IRoundProcessorDependency
    {

        public void SetDependency(RoundProcessor roundProcessor) => m_roundProcessor = roundProcessor;

        public RoundProcessor RoundProcessorDependency => m_roundProcessor;

    }
    
    public abstract partial class MatchProcessor : ISingleActiveInstance
    {

        public static MatchProcessor ActiveInstance { get; private set; }
        
        public void SetAsSingleActiveInstance()
        {
            if (ActiveInstance)
                throw new AlreadySingleActiveInstance();

            ActiveInstance = this;
        }
        
    }
    
    public abstract partial class MatchProcessor
    {

        public static implicit operator bool(MatchProcessor matchProcessor) => matchProcessor != null;

    }

}