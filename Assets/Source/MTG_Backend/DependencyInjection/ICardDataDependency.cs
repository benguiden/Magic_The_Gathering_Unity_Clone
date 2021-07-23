namespace MTG.Backend
{

    public interface ICardDataDependency : IDependency
    {

        void SetDependency(CardData cardData);

        [Dependency] CardData CardDataDependency { get; }

    }

}
