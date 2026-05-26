using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static System.Action<string> OnRoomEnter;
    public static System.Action<int> OnRoomExit;
}
public class RoomTrigger : MonoBehaviour
{
    public string roomID;
    public GameObject spawner;
    Grid spawnerGrid;

    private bool roomEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !roomEntered)
        {
            spawnerGrid = spawner.GetComponent<Grid>();
            spawnerGrid.AddPrefabToGridToCenter();
            roomEntered = true;
        }
    }
}
