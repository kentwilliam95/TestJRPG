using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    [field: SerializeField] public string DisplayName { get; set; }
    [field: SerializeField] public Sprite Sprite { get; set; }

    public virtual Item GenerateItem()
    {
        return null;
    }
}
