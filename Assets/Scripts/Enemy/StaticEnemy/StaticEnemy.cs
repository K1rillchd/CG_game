using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public float distanceFromPlayer = 14f;
    public float speed = 2f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;
    private GameObject player;

    private Vector3 move, moveNormalized;
    private float distanceMove;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        move = (player.transform.position - transform.position);

        move.y = 0f;

        distanceMove = move.magnitude;

        moveNormalized = move.normalized;

        Quaternion targetRotation = Quaternion.LookRotation(move);
        transform.rotation = targetRotation;
    }
}
