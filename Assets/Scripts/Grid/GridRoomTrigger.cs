using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRoomTrigger : MonoBehaviour
{
    public Grid grid;

    private void OnEnable()
    {
        GameEvents.OnRoomEnter += HandleRoomEnter;
    }

    private void OnDisable()
    {
        GameEvents.OnRoomEnter -= HandleRoomEnter;
    }

    private void HandleRoomEnter(string roomID)
    {
        Debug.Log("Игрок вошел в комнату: " + roomID);
        grid.AddPrefabToGridToCenter();
    }
}
