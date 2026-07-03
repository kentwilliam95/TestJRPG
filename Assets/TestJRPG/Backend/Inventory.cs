using System.Collections.Generic;
using System;

public class Inventory
{
    public Dictionary<Item, int> _items;
    public Dictionary<Item, int> ItemCatalogue => _items;
    
    public Inventory()
    {
        _items = new Dictionary<Item, int>();
    }

    public void Add(Item item)
    {
        if(!_items.ContainsKey(item))
        {
            _items.Add(item, 1);
        }
        else
        {
            _items[item] += 1;
        }
    }

    public bool UseItem(Item item, Action<Item> OnItemUsed = null)
    {
        var isContain = _items.ContainsKey(item);
        if(!isContain)
        {
            return false;
        }
        if(_items[item] - 1 < 0)
        {
            return false;
        }
        _items[item] = _items[item] - 1;
        OnItemUsed?.Invoke(item);
        return true;
    }

    public int GetItemAmount(Item item)
    {
        if(_items.ContainsKey(item))
        {
            return _items[item];
        }
        return int.MinValue;
    }
}