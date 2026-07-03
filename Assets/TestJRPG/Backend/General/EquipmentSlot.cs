using System.Diagnostics;

public class EquipmentSlot
{
    private Equipment _equipment;
    private Actor _owner;

    public EquipmentSlot(Actor owner)
    {
        _owner = owner;
    }

    public Equipment Equip(Equipment equipment)
    {
        if(_equipment == null)
        {            
            _equipment = equipment;
            _equipment.Equip(_owner.Status);
            return null;
        }
        else
        {        
            var oldEquipment = _equipment;
            oldEquipment.UnEquip(_owner.Status);
            _equipment = equipment;
            _equipment.Equip(_owner.Status);
            return oldEquipment;
        }
    }
}