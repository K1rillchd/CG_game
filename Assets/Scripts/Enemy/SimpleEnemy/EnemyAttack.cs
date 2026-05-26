using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10f;
    public float cooldown = 1f;
    
    private float timerCooldown = 0f;

    void Start()
    {
        timerCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCooldown <= cooldown) {
            timerCooldown += Time.deltaTime;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && timerCooldown >= cooldown)
        {
            PlayerCharacteristics playerC = collision.gameObject.GetComponent<PlayerCharacteristics>();
            playerC.TakeDamage(damage);
            timerCooldown = 0f;
        }
    }
}
