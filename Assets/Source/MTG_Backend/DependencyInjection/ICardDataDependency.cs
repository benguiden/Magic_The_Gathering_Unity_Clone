namespace MTG
{

    namespace Backend
    {

        public interface ICardDataDependency : IDependency
        {

            void SetDependency(CardData cardData);
            
            [Dependency]
            CardData CardDataDependency { get; }

        }
        
    }

}
