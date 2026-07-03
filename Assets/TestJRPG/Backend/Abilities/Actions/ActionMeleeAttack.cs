public class ActionMeleeAttack : Ability
{
    public override void Execute(AbilityContext context)
    {        
        var hit = context.ActorTarget.GetReaction<ReactionHit>();
        if(hit == null)
        {
            return;
        }

        OnExecuteCalled?.Invoke(context);
        hit.Execute(context);
    }
}