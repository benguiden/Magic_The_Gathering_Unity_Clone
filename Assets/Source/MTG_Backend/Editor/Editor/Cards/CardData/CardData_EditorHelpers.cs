using System;
using System.Linq;
using System.Reflection;

namespace MTG.Backend.Editor
{
    
    public static class CardData_EditorHelpers
    {
        
        /// <summary>
        /// Sets all card attribute fields with the CardAttributeDefaultValue attribute to their default values based on their card attribute type.  
        /// </summary>
        public static void SetCardDataDefaultValues(this CardData cardData)
        {
            if (cardData == null)
                throw new ArgumentNullException(nameof(cardData));
            
            Type cardAttributesClassType = cardData.GetType();
            
            var fieldsWithDefault = cardAttributesClassType
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttributes(typeof(CardAttributeDefaultValue), true).Length > 0);

            foreach (FieldInfo fieldWithDefault in fieldsWithDefault)
            {
                var defaultAttributes = fieldWithDefault.GetCustomAttributes(typeof(CardAttributeDefaultValue), true) as CardAttributeDefaultValue[];
                if (defaultAttributes.Length != 1)
                    throw new Exception();

                fieldWithDefault.SetValue(cardData, defaultAttributes[0].DefaultValue);
            }
        }
        
    }
    
}
