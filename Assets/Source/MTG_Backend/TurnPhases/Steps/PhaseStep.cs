namespace MTG.Backend
{

    public abstract partial class PhaseStep
    {
        
        public abstract void Execute();

    }

    public abstract partial class PhaseStep : ITurnPhaseDependency, ITurnPhaseOwnable
    {

        protected TurnPhase m_owningTurnPhase;

        public TurnPhase OwningTurnPhase => m_owningTurnPhase;

        public void SetDependency(TurnPhase turnPhase) => m_owningTurnPhase = turnPhase;

        public TurnPhase TurnPhaseDependency => m_owningTurnPhase;
        
    }
    
    public abstract partial class PhaseStep : IPlayerRuntimeOwnable
    {

        public PlayerRuntime OwningPlayer => m_owningTurnPhase.OwningPlayer;

    }
    
    public abstract partial class PhaseStep : ISingleActiveInstance
    {
        
        public static PhaseStep ActiveInstance { get; private set; }
        
        public void SetAsSingleActiveInstance()
        {
            if (ActiveInstance)
                throw new AlreadySingleActiveInstance();

            ActiveInstance = this;
        }

        public static void TempClearSingleInstance() /// Todo: Remove temp function and change into enter and exit
        {
            ActiveInstance = null;
        }
        
    }
    
    public abstract partial class PhaseStep
    {

        public static implicit operator bool(PhaseStep phaseStep) => phaseStep != null;

    }
    
}
