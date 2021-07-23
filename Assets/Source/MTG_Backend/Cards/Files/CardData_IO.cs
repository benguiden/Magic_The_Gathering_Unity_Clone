using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace MTG.Backend
{
    
    public static class CardData_IO
    {

        public const string CARD_DATA_FILE_EXTENSION = "card";

        public static class Json
        {

            public const int CARD_TYPE_JSON_ORDER           = 1;
            public const int GUID_JSON_ORDER                = 2;
            public const int DISPLAY_NAME_JSON_ORDER        = 3;
            public const int MANA_COST_JSON_ORDER           = 4;
            public const int POWER_JSON_ORDER               = 5;
            public const int TOUGHNESS_JSON_ORDER           = 6;
            
            public const string CARD_TYPE_JSON_NAME         = "type";
            public const string GUID_JSON_NAME              = "guid";
            public const string DISPLAY_NAME_JSON_NAME      = "display_name";
            public const string MANA_COST_JSON_NAME         = "mana_cost";
            public const string POWER_JSON_NAME             = "power";
            public const string TOUGHNESS_JSON_NAME         = "toughness";

            private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.None};
            
            public static CardData LoadCardDataFromFile(string filePath)
            {
                
                try
                {
                    string fileString = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<CardData>(fileString, SerializerSettings);
                }
                catch (Exception exception)
                {
                    Debug.LogException(exception);
                    return default;
                }
            }

            public static bool SaveCardDataToFile(CardData cardData, string filePath)
            {
                try
                {
                    string fileString = JsonConvert.SerializeObject(cardData, Formatting.Indented, SerializerSettings);
                    File.WriteAllText(filePath, fileString);
                }
                catch (Exception exception)
                {
                    Debug.LogException(exception);
                    return false;
                }

                return true;
            }

            private class CardDataContractResolver : DefaultContractResolver
            {
                protected override JsonConverter ResolveContractConverter(Type objectType)
                {
                    if (typeof(CardData).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                        return null;
                    return base.ResolveContractConverter(objectType);
                }
            }
            
            public class CardDataConverter : JsonConverter
            {
                
                private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings() { ContractResolver = new CardDataContractResolver() };
                
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    JObject jsonObject = JObject.Load(reader);
                    JToken cardTypeToken = jsonObject[CARD_TYPE_JSON_NAME];
                    int cardTypeInt = (cardTypeToken ?? (int) CardType.Invalid).Value<int>();
                    
                    switch ((CardType) cardTypeInt)
                    {
                        case CardType.Invalid:
                            throw new Exception();
                        case CardType.Creature:
                            return JsonConvert.DeserializeObject<CardData_Creature>(jsonObject.ToString(), SerializerSettings);
                        default:
                            throw new NotImplementedException();
                    }
                }

                public override bool CanWrite => false;

                public override bool CanConvert(Type objectType) => false;

                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
                
            }

        }

    }

}
