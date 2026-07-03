using System.Collections.Generic;
using UnityEngine;

namespace Frontend
{
    [CreateAssetMenu(menuName = "Data/ActorData")]
    public class ActorData : ScriptableObject
    {
        [System.Serializable]
        public struct StatusData
        {
            public PropertiesCollection.Category Category;
            public float Value;
        }

        public List<StatusData> Status;

        public PropertiesCollection GenerateCollection()
        {
            PropertiesCollection collection = new PropertiesCollection();
            foreach (var stat in Status)
            {
                collection.Register(stat.Category, new Range(stat.Value));
            }
            
            return collection;
        }
    }
}