using System.Collections.Generic;
using System;

public abstract class Ability
{
    public string DisplayName { get; set; }
    public Action<AbilityContext> OnExecuteCalled;
    public abstract void Execute(AbilityContext context);
}