using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public float damage = 100f;
    public float upgradeDamage = 1.1f;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.EnemyTakeDamage(damage);
        }
    }

    public void AddDamage()
    {
        damage *= upgradeDamage;
    }

   
}
