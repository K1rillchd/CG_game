using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacteristics : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
