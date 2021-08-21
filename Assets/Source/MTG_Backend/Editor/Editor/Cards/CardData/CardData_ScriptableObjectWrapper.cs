using UnityEngine;

namespace MTG.Backend.Editor
{
    
    public class CardData_ScriptableObjectWrapper : ScriptableObject
    {

        public string FilePath { get; private set; }
        
        public CardData Data { get; private set; }

        public void LoadDataAtPath(string filePath)
        {
            FilePath = filePath;
            Data = CardData_IO.Json.LoadCardDataFromFile(filePath);
        }

    }
    
}
