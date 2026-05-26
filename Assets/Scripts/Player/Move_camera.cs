using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_camera : MonoBehaviour
{
    public GameObject player;
    public float speedH;
    public float speedW;
    public float cameraDistanceX;
    public float cameraDistanceY;
    public float cameraDistanceZ;
    public float scrollSpeed;


    private Vector3 previousPosition;
    private float xAngle = 0.0f;
    private float yAngle = 0.0f;
    //[SerializeField]private Camera cam;
    

    void Start()
    {
        previousPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Cursor.lockState = CursorLockMode.Locked;
        
        Cursor.visible = false;
    }

    void Update()
    {
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        //cameraDistanceZ += scroll * scrollSpeed;
        //cameraDistanceZ = Mathf.Clamp(cameraDistanceZ,-14,0);

        transform.position = player.transform.position;

        xAngle -= Input.GetAxis("Mouse Y")*speedH;
        yAngle += Input.GetAxis("Mouse X")*speedW;

        xAngle = Mathf.Clamp(xAngle, -50f, 80f);

        transform.eulerAngles = new Vector3(xAngle, yAngle, 0.0f);
        //transform.Translate(new Vector3(cameraDistanceX,cameraDistanceY,cameraDistanceZ));
    }

    void FixedUpdate()
    {
        
    }
}
