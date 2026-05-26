using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_movement : MonoBehaviour
{
 public float speed = 6f;
    public float gravity = -20f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 move;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 12 * Time.deltaTime);

        isGrounded = controller.isGrounded;

        move = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) {
            move += transform.forward;
        }
        if (Input.GetKey(KeyCode.S)) {
            move -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A)) {
            move -= transform.right;
        }
        if (Input.GetKey(KeyCode.D)) {
            move += transform.right;
        }

        move.Normalize();

        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), $"IsGrounded: {isGrounded}");
        GUI.Label(new Rect(10, 40, 200, 30), $"Velocity Y: {velocity.y:F2}");
    }
}
