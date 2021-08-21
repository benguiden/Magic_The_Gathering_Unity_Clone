using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace MTG.Backend.Editor
{
    
    public class CardBuilder_EditorWindow : EditorWindow
    {

        private const string WINDOW_NAME = "TEMP Card Builder";
        
        private Button m_createCardFileButton;
        private Button m_loadCardFileButton;

        private static CardBuilder_EditorWindow temp;
        
        [MenuItem("Window/TEMP Card Editor")]
        public static void TempShowWindow()
        {
            temp = GetWindow<CardBuilder_EditorWindow>();
            temp.name = WINDOW_NAME;
            temp.Focus();
        }

        
        private void CreateGUI()
        {
            m_createCardFileButton = new Button(CreateAndLoadCardFileDialogue)
            {
                text = "Create Card Data File"
            };
            
            m_loadCardFileButton = new Button(LoadCardFileDialogue)
            {
                text = "Load Card Data File"
            };

            rootVisualElement.Add(m_createCardFileButton);
            rootVisualElement.Add(m_loadCardFileButton);
        }

        private void CreateAndLoadCardFileDialogue()
        {
            LoadCardFile(SaveCardFileDialogue());
        }
        
        private void LoadCardFileDialogue()
        {
            string loadingPath = EditorUtility.OpenFilePanel("Load Card Data File", Application.dataPath, CardData_IO.CARD_DATA_FILE_EXTENSION);
            LoadCardFile(loadingPath);
        }

        private void LoadCardFile(string loadingPath)
        {
            if (loadingPath.Length == 0 || !loadingPath.EndsWith("." + CardData_IO.CARD_DATA_FILE_EXTENSION))
                throw new NotImplementedException();

            CardData cardData = CardData_IO.Json.LoadCardDataFromFile(loadingPath);
        }

        private static string SaveCardFileDialogue()
        {
            string savingPath = EditorUtility.SaveFilePanel("Create Card Data File", Application.dataPath, "NewCard", CardData_IO.CARD_DATA_FILE_EXTENSION);
            if (savingPath.Length == 0 || !savingPath.EndsWith("." + CardData_IO.CARD_DATA_FILE_EXTENSION))
                return null;

            CardData cardData = new CardData_Creature();
            cardData.SetCardDataDefaultValues();
            
            CardData_IO.Json.SaveCardDataToFile(cardData, savingPath);

            return savingPath;
        }
        
    }
    
}


