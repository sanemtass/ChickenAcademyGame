using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBehaviour : MonoBehaviour
{
    public HealthSystem enemyHealth = new HealthSystem(300, 300);

    public void EnemyTakeDamage(int damage)
    {
        enemyHealth.Damage(damage);
    }

    public void EnemyHeal(int healing)
    {
        enemyHealth.Heal(healing);
    }

    public void EnemyDie(GameObject enemy)
    {
        enemyHealth.Die(enemy);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Bullet"))
    //    {
    //        EnemyTakeDamage(10);
    //        //Debug.Log(GameManager.Instance.enemyHealth.Health);
    //        EnemyDie(this.gameObject);
    //    }
    //}

}
