using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float gravity = -20f;
    public float speed = 3f;

    private Rigidbody rb;
    private GameObject player;

    private Vector3 velocity, move;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        move = (player.transform.position - transform.position).normalized;

        move.y = 0f;

        rb.AddForce(move * speed);
    }
}
