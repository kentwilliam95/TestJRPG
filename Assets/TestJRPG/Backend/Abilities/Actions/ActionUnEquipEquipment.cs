using UnityEngine;

public class ActionUnEquipEquipment : Ability
{
  public override void Execute(AbilityContext context)
  {
    context.ActorTarget.Status.Add(PropertiesCollection.Category.AttackDamage, -context.Value);
    Debug.Log($"released weapon on {context.ActorTarget}: {context.Value}, Attack Damage: {context.ActorTarget.Status.Getvalue(PropertiesCollection.Category.AttackDamage).Value}");
  }
}