using Newtonsoft.Json;

namespace MTG.Backend
{

    public interface ICardAttribute_DisplayName : ICardAttribute
    {

        [JsonIgnore]
        public string DisplayName { get; }

    }

}