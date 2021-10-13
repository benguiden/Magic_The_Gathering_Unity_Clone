using System;
using System.Collections.Generic;
using log4net.Appender;
using MTG.Backend;
using UnityEngine;

namespace MTG.FrontendLite
{
    public class ManaCost_Widget : MonoBehaviour
    {

        [ContextMenu("Test")]
        private void Test()
        {
            GenerateUI(new ManaCost(5, 1, 2, 0, 1, 1));
        }

        public void GenerateUI(ManaCost manaCost)
        {
            var instantiatedManaCostGameObjects = new Dictionary<ManaColour, GameObject[]>
            {
                {ManaColour.Generic, InstantiateManaCostColourGameObjects(ManaColour.Generic, manaCost.GenericCost)},
                {ManaColour.Black, InstantiateManaCostColourGameObjects(ManaColour.Black, manaCost.BlackCost)},
                {ManaColour.Blue, InstantiateManaCostColourGameObjects(ManaColour.Blue, manaCost.BlueCost)},
                {ManaColour.Green, InstantiateManaCostColourGameObjects(ManaColour.Green, manaCost.GreenCost)},
                {ManaColour.Red, InstantiateManaCostColourGameObjects(ManaColour.Red, manaCost.RedCost)},
                {ManaColour.White, InstantiateManaCostColourGameObjects(ManaColour.White, manaCost.WhiteCost)}
            };

            float widgetOffset = WidgetPrefabs.ManaCostWidgetOffset;
            float currentWidgetOffset = 0f;

            for (int i = (int) ManaColour.White; i >= (int) ManaColour.Generic; i--)
            {
                var currentColour = (ManaColour) i;
                for (int j = 0; j < instantiatedManaCostGameObjects[currentColour].Length; j++)
                {
                    GameObject currentManaCostGameObject = (instantiatedManaCostGameObjects[currentColour][j]);
                    var currentManaCostTransform = currentManaCostGameObject.GetComponent<RectTransform>();
                    currentManaCostTransform.SetParent(transform);
                    currentManaCostTransform.anchoredPosition = new Vector2(currentWidgetOffset, 0f);
                    currentWidgetOffset += widgetOffset;
                }
            }
        }

        private static GameObject[] InstantiateManaCostColourGameObjects(ManaColour manaColour, int amount)
        {
            GameObject[] gameObjectsToInstantiate;

            if (manaColour == ManaColour.Generic)
            {
                gameObjectsToInstantiate = new GameObject[1];
                gameObjectsToInstantiate[0] = InstantiateManaCostColourGameObject(manaColour);
                
                var textComponent = gameObjectsToInstantiate[0].GetComponentInChildren<TMPro.TextMeshProUGUI>();
                if (!textComponent)
                    throw new NotImplementedException();

                textComponent.text = amount.ToString();
            }
            else
            {
                gameObjectsToInstantiate = new GameObject[amount];
                
                for (int i = 0; i < amount; i++)
                {
                    gameObjectsToInstantiate[i] = InstantiateManaCostColourGameObject(manaColour);
                }    
            }

            return gameObjectsToInstantiate;
        }

        private static GameObject InstantiateManaCostColourGameObject(ManaColour manaColour)
        {
            GameObject gameObjectToInstantiate = manaColour switch
            {
                ManaColour.Generic => WidgetPrefabs.ManaCostGenericPrefab,
                ManaColour.Black => WidgetPrefabs.ManaCostBlackPrefab,
                ManaColour.Blue => WidgetPrefabs.ManaCostBluePrefab,
                ManaColour.Green => WidgetPrefabs.ManaCostGreenPrefab,
                ManaColour.Red => WidgetPrefabs.ManaCostRedPrefab,
                ManaColour.White => WidgetPrefabs.ManaCostWhitePrefab,
                _ => null
            };

            if (!gameObjectToInstantiate)
                throw new NotImplementedException();

            return Instantiate(gameObjectToInstantiate);
        }
        
    }
}
