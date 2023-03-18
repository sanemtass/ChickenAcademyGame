using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorChickenHealth : MonoBehaviour
{
    public HealthSystem chickenHealth = new HealthSystem(1000, 1000);

    public void ChickenTakeDamage(int damage)
    {
        chickenHealth.Damage(damage);
    }

    public void ChickenHeal(int healing)
    {
        chickenHealth.Heal(healing);
    }

    public void ChickenDie(GameObject warriorChicken)
    {
        chickenHealth.WarriorChickenDie(warriorChicken);
    }
}
