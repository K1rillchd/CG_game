using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPrefabs : MonoBehaviour
{
    public GameObject GroundEnemy;
    public GameObject GroundShootingEnemy;
    public GameObject GroundShootingTurret;
    public GameObject FlyingEnemy;
    public GameObject FlyingShootingEnemy;
    public GameObject FlyingShootingTurret;
    // Start is called before the first frame update
    public GameObject GetPrefabByIndex(int indEnemy)
    {
        switch (indEnemy)
        {
            case 1: return GroundEnemy;
            case 2: return GroundShootingEnemy;
            case 3: return GroundShootingTurret;
            case 4: return FlyingEnemy;
            case 5: return FlyingShootingEnemy;
            case 6: return FlyingShootingTurret;
            default: return GroundEnemy;
        }
    }
}
