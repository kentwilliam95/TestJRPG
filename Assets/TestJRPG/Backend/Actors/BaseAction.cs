using System.Collections.Generic;
using System;

public class BaseActions
{
    public List<Ability> ListActions{get; private set;}
    public BaseActions()
    {
        ListActions = new List<Ability>();
    }

    public void InstallActions(Ability ability)
    {
        ListActions.Add(ability);
    }
    
    public T GetAction<T>() where T : Ability
    {
        for (int i = 0; i < ListActions.Count; i++)
        {
            if(ListActions[i] is T value)
            {
                return value;
            }                
        }
        return null;
    }
}