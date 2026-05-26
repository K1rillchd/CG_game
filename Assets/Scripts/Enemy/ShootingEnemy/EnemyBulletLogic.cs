using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    public float damage = 25f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerCharacteristics target = collision.transform.GetComponent<PlayerCharacteristics>();

            if (target != null) {
                target.TakeDamage(damage);
            }

            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
