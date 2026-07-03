public class Potion : Item, IUseable
{
    public float Amount;
    protected PropertiesCollection.Category _targetStatus = PropertiesCollection.Category.Health;
    
    public Potion(string name, PropertiesCollection.Category category,float amount)
    {
        Amount = amount;
        Name = name;
        _targetStatus = category;
    }

    public void Use(Actor target)
    {
        target.GetReaction<ReactionHeal>().Execute(new AbilityContext(target, target, _targetStatus, Amount));
    }
}