using UnityEngine;

namespace frontend
{
    [CreateAssetMenu(menuName = "Data/Potion")]
    public class PotionData: ItemData
    {
        [field: SerializeField] public float Value { private set; get; }
        [field: SerializeField] public PropertiesCollection.Category Category { get; private set; }

        public override Item GenerateItem()
        {
            return new Potion(DisplayName, Category, Value) { _Sprite = Sprite };
        }
    }
}