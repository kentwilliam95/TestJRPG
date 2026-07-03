using UnityEngine;

public class ReactionHeal : Ability
{
    public override void Execute(AbilityContext context)
    {
        Debug.Log(context.Value);
        context.ActorTarget.Status.Add(PropertiesCollection.Category.Health, context.Value);
        OnExecuteCalled?.Invoke(context);
    }
}