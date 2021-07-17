namespace MTG
{

    namespace Backend
    {

        public interface ICardRuntimeCollectionDependency : IDependency
        {

            void SetDependency(CardRuntimeCollection cardRuntimeCollection);
            
            [Dependency]
            CardRuntimeCollection CardRuntimeCollectionDependency { get; }

        }
        
    }

}
