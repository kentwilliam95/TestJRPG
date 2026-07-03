using UnityEngine;

public class ReactionHit : Ability
{
    public override void Execute(AbilityContext context)
    {
        var damage = context.Value;
        damage = Mathf.Max(damage - context.ActorTarget.Status.Getvalue(PropertiesCollection.Category.Defend).Value, 0);
        context.ActorTarget.Status.Add(context.Category, damage);
        OnExecuteCalled?.Invoke(context);
    }
}