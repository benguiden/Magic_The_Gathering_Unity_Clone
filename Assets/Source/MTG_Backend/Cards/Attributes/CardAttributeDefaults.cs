using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MTG.Backend
{

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class CardAttributeDefaultValue : Attribute
    {

        public Type AttributeType { get; }
        
        public CardAttributeDefaultValue(Type attributeType)
        {
            AttributeType = attributeType;
        }

        public object DefaultValue
        {
            get
            {
                if (!AttributeType.GetTypeInfo().ImplementedInterfaces.Contains(typeof(ICardAttribute)))
                    throw new Exception();

                if (!DefaultValueFromTypeDict.ContainsKey(AttributeType))
                    throw new Exception();

                return DefaultValueFromTypeDict[AttributeType]();
            }
        }
        
        private static readonly Dictionary<Type, Func<object>> DefaultValueFromTypeDict = new Dictionary<Type, Func<object>>
        {
            { typeof(ICardAttribute_DisplayName),   () => "NewCard" },                  //System.Guid
            { typeof(ICardAttribute_Guid),          () => Guid.NewGuid() },             //System.Guid
            { typeof(ICardAttribute_ManaCost),      () => new ManaCost(3, 1, 0, 0, 1, 0) },            //ManaCost
            { typeof(ICardAttribute_Power),         () => new CardPower(1) },           //CardPower
            { typeof(ICardAttribute_Toughness),     () => new CardToughness(1) },       //CardToughness
        };
        
    }
    
}