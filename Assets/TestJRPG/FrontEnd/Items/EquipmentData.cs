using UnityEngine;

namespace frontend
{
    [CreateAssetMenu(menuName = "Data/Equipment")]
    public class EquipmentData: ItemData
    {
        [field: SerializeField] public PropertiesCollection.Category Category { get; private set; }
        [field: SerializeField] public float Value { private set; get; }
        [field: SerializeField] public global::Equipment.Types Types { private set; get; }

        public override Item GenerateItem()
        {
            return new Equipment(Category, Value, Types){Name = DisplayName, _Sprite = Sprite, };
        }
    }
}