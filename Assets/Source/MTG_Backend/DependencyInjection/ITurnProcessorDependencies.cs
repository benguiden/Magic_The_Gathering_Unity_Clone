namespace MTG
{

    namespace Backend
    {

        public interface ITurnProcessorDependencies : IDependency
        {

            void SetDependency(TurnProcessor turnProcessor);
            
            [Dependency]
            TurnProcessor TurnProcessorDependency { get; }

        }
        
    }

}
