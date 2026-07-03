using System.Collections.Generic;
using System;

public class PropertiesCollection
{
    public enum Category
    {
        Health,
        Energy,
        AttackDamage,
        ATBSpeed,
        Team,
        Dodge,
        Defend,
    }
    
    private Dictionary<Category, Range> _dict = new Dictionary<Category, Range>();
    public Action<Category, Range> OnValueChanged;
    public void Register(Category category, Range value)
    {
        if (HasKey(category))
        {
            return;
        }
        _dict.Add(category, value);
    }

    public void Add(Category category, float value)
    {
        if (!HasKey(category))
        {
            Console.WriteLine($"No {category} Key found!");
            return; 
        }

        var range = _dict[category];
        var oldValue = range.Value;
        var newValue = oldValue + value;
        range.SetValue(newValue);

        if(range.OldValue != range.Value)
        {
            OnValueChanged?.Invoke(category, range);
        }
    }

    public Range Getvalue(Category category)
    {
        if(!HasKey(category))
        {
            return null;
        }
        return _dict[category];
    }

    public bool ChangeRange(Category category,Range newRange)
    {
        if(!HasKey(category))
        {
            return false;
        }
        _dict[category] = newRange;
        return true;
    }

    public void ChangeValue(Category category, float value)
    {
        
    }

    public void ChangeMax()
    {

    }

    public void ChangeMin()
    {

    }

    private bool HasKey(Category category)
    {
        return _dict.ContainsKey(category);
    }
}