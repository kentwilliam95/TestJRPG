using System;
using frontend;
using Frontend;
using UnityEngine;

public class Enemy : BaseActor
{
    [SerializeField] protected HealthBar _healthBar;

    protected virtual void Start()
    {
        _status = _statData.GenerateCollection();
    }

    public override bool ReceiveItem(Item item)
    {
        return false;
    }

    public override void SwitchToBattle() { }

    public override void SwitchToNormal() { }

    public override void Hit(float damage)
    {
        if (IsDead) { return;}

        _status.Add(PropertiesCollection.Category.Health, -damage);
        var currentHealth = _status.Getvalue(PropertiesCollection.Category.Health).Value;
        if (currentHealth <= 0)
        {
            OnDead?.Invoke();
            IsDead = true;
        }
    }
}
