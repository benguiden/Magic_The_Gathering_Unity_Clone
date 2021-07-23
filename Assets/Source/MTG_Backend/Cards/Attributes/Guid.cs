using Newtonsoft.Json;

namespace MTG.Backend
{

    public interface ICardAttribute_Guid : ICardAttribute
    {

        [JsonIgnore]
        public System.Guid Guid { get; }

    }

}
