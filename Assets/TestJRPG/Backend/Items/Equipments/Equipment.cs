public class Equipment : Item, IEquippable
{
    public enum Types
    {
        Weapon,
        Armor
    }

    public float Damage {get; private set;}
    public PropertiesCollection.Category Category;
    public Types EquipmentType;
    public Equipment(PropertiesCollection.Category category, float damage, Types equipmentType):base()
    {
        EquipmentType = equipmentType;
        Damage = damage;
        Category = category;
    }

    public void Equip(PropertiesCollection collection)
    {
        collection.Add(PropertiesCollection.Category.AttackDamage, Damage);
    }

    public void UnEquip(PropertiesCollection collection)
    {
        collection.Add(PropertiesCollection.Category.AttackDamage, -Damage);
    }
}