public class ActionUsePotion : Ability
{
    public override void Execute(AbilityContext context)
    {
        var heal = context.ActorOrigin.GetReaction<ReactionHeal>();
        if(heal == null)
        {
            return;
        }
        heal.Execute(context);
    }
}