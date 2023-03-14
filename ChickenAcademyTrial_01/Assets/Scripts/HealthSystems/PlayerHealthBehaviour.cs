using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    public HealthSystem playerHealth = new HealthSystem(300, 300);

    public Transform playerRespawnPoint;

    public void PlayerTakeDamage(int damage)
    {
        playerHealth.Damage(damage);        
    }

    public void PlayerHeal(int healing)
    {
        playerHealth.Heal(healing);
    }

    public void PlayerRespawn()
    {
        if (playerHealth.currentHealth <= 0)
        {
            playerHealth.Respawn(gameObject, playerRespawnPoint);
            playerHealth.currentHealth = playerHealth.MaxHealth;
            GetComponent<Gun>().muzzleFlash.Stop();
        }

        
    }
    
}
