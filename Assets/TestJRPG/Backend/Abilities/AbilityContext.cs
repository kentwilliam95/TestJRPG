public class AbilityContext
{
    public Actor ActorOrigin { get; private set; }
    public Actor ActorTarget { get; private set; }
    public float Value {get; private set;}
    public PropertiesCollection.Category Category {get; private set;}
    public AbilityContext(Actor origin, Actor target, PropertiesCollection.Category category, float value)
    {
        ActorOrigin = origin;
        ActorTarget = target;
        Value = value;
        Category = category;
    }
}