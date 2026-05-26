using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject prefab;
    public float distance = 4f;
    public float shootingDelay = 1f;
    public float bulletSpeed = 1f;

    private GameObject player;

    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;

        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        Vector3 bullet_pos = transform.position + directionToPlayer * distance;

        if (timer >= shootingDelay)
        {
            GameObject bullet = Instantiate(prefab, bullet_pos, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(directionToPlayer * bulletSpeed, ForceMode.Impulse);
            timer = 0;
        }
    }
}
