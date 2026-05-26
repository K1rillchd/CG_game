using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject prefab;
    public float distance = 4f;
    public float shootingDelay = 1f;
    public float bulletSpeed = 1f;

    private float y, x;
    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        Vector3 bullet_pos = transform.position + Camera.main.transform.forward * distance;

        if (Input.GetMouseButton(0) && timer >= shootingDelay)
        {
            GameObject bullet = Instantiate(prefab, bullet_pos, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Impulse);
            timer = 0;
        }
    }
}
