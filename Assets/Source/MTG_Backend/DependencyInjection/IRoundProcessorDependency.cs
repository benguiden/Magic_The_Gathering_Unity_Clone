namespace MTG
{

    namespace Backend
    {

        public interface IRoundProcessorDependency : IDependency
        {

            void SetDependency(RoundProcessor roundProcessor);
            
            [Dependency]
            RoundProcessor RoundProcessorDependency { get; }

        }
        
    }

}
