using System.Collections.Generic;
using System;


public class Actor : BaseActions
{
    protected PropertiesCollection _status;
    public PropertiesCollection Status => _status;
    public bool IsDead => Status.Getvalue(PropertiesCollection.Category.Health).Value <= 0;

    protected List<Ability> _listReactions = new List<Ability>();
    
    public T GetReaction<T>() where T : Ability
    {
        for (int i = 0; i < _listReactions.Count; i++)
        {
            if(_listReactions[i] is T value)
            {
                return value;
            }
        }
        return null;
    }

    public virtual void EquipEquipment(Equipment equipment, out Equipment oldEquipment)
    {
        oldEquipment = null;
    }
}