using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public int currentHealth;
    public int currentMaxHealth;

    public int Health
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return currentMaxHealth;
        }

        set
        {
            currentMaxHealth = value;
        }
    }

    //Constructor
    public HealthSystem(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
        }
    }

    public void Heal(int healAmount)
    {
        if (currentHealth < currentMaxHealth)
        {
            currentHealth += healAmount;
        }
        if (currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
    }

    public void Die(GameObject gameObject)
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Respawn(GameObject player, Transform transform)
    {
        player.transform.position = transform.transform.position;
    }

    public void WarriorChickenDie(GameObject warriorChicken)
    {
        if(currentHealth<=0)
        ObjectPooling.Instance.SetPoolObject(warriorChicken, 2);
    }

}
