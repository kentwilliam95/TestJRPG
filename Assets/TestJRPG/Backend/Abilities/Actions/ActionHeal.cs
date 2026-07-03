public class ActionHeal : Ability
{
    public override void Execute(AbilityContext context)
    {
        context.ActorTarget.GetReaction<ReactionHeal>().Execute(context);
    }
}