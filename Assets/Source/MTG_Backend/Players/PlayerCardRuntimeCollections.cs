namespace MTG
{

    namespace Backend
    {

        public abstract class PlayerCardRuntimeCollections : ICardRuntimeCollectionDependency
        {

            public abstract void SetDependency(CardRuntimeCollection cardRuntimeCollection);

            public abstract CardRuntimeCollection CardRuntimeCollectionDependency { get; }
            
        }

    }

}
