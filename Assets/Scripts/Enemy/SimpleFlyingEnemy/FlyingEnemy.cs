using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float distanceFromPlayer = 14f;
    public float speed = 3f;

    private Rigidbody rb;
    private GameObject player;

    private Vector3 velocity, move, moveNormalized;
    private float distanceMove;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        move = (player.transform.position - transform.position);

        distanceMove = move.magnitude;

        moveNormalized = move.normalized;

        Quaternion targetRotation = Quaternion.LookRotation(move);
        transform.rotation = targetRotation;

        if (distanceMove > distanceFromPlayer){
            rb.velocity = moveNormalized * speed;
        }

    }
}
