using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid : MonoBehaviour
{
    public GameObject prefab;    
    public GridPrefabs gridPrefabs;
    public Vector3Int gridSize = new Vector3Int(5, 5, 5);
    public Vector3Int gridSpacing = new Vector3Int(1, 1, 1);
    public Vector3Int GroundEnemyAmounts = new Vector3Int(3,2,1);
    public Vector3Int FlyingEnemyAmounts = new Vector3Int(0,0,0);
    public MeshFilter planeMesh;

    public void AddPrefabToGridToCenter()
    {
        MeshFilter prefabMesh = prefab.GetComponent<MeshFilter>();

        Vector3 prefabSize = prefabMesh.mesh.bounds.size;
        Vector3 prefabWorldSize = prefabMesh.transform.TransformVector(prefabSize);
        Vector3 planeSize = planeMesh.mesh.bounds.size;
        Vector3 planeWorldSize = planeMesh.transform.TransformVector(planeSize);

        float stepX = prefabWorldSize.x + gridSpacing.x;
        float stepY = prefabWorldSize.y + gridSpacing.y;
        float stepZ = prefabWorldSize.z + gridSpacing.z;

        float totalWidth = stepX * gridSize.x - gridSpacing.x;
        float totalDepth = stepZ * gridSize.z - gridSpacing.z;

        float startX = planeMesh.transform.position.x - (totalWidth / 2) + (prefabWorldSize.x / 2);
        float startZ = planeMesh.transform.position.z - (totalDepth / 2) + (prefabWorldSize.z / 2);

        
        Vector3 startPos = new Vector3(startX, planeMesh.transform.position.y+1, startZ);

        //List<Vector3Int> listPos = generatePositions(gridSize, 5);
        List<(int indEnemy, Vector3 pos)> IndEnemyAndPosList = new List<(int indEnemy, Vector3 pos)>();
        
        //foreach (Vector3Int pos in listPos)
        //{
            //Vector3 posElem = startPos + new Vector3(pos[0] * stepX, pos[1] * stepY, pos[2] * stepZ);
            //Debug.Log($"({pos[0]}, {pos[1]}, {pos[2]})\n");
            //Instantiate(GroundEnemy, posElem, Quaternion.identity);
        //}
        
        IndEnemyAndPosList = addIndEnemyToPos(gridSize, GroundEnemyAmounts, FlyingEnemyAmounts);
        foreach ((int indEnemy, Vector3 pos) tuple in IndEnemyAndPosList)
        {
            //Debug.Log($"({tuple.indEnemy}) - ({tuple.pos[0]}, {tuple.pos[1]}, {tuple.pos[2]})\n");
            Vector3 posElem = startPos + new Vector3(tuple.pos[0] * stepX, tuple.pos[1] * stepY, tuple.pos[2] * stepZ);
            Instantiate(gridPrefabs.GetPrefabByIndex(tuple.indEnemy), posElem, Quaternion.identity);
        }
    }

    List<(int indEnemy, Vector3 pos)> addIndEnemyToPos(Vector3Int grindSize, Vector3Int GroundEnemyAmount, Vector3Int FlyingEnemyAmount)
    {
        List<(int indEnemy, Vector3 pos)> IndEnemyAndPosList = new List<(int indEnemy, Vector3 pos)>();
        List<Vector3Int> geList = new List<Vector3Int>();
        List<Vector3Int> feList = new List<Vector3Int>();
        int gea, fea, randInd;
        gea = GroundEnemyAmount[0]+GroundEnemyAmount[1]+GroundEnemyAmount[2];
        fea = FlyingEnemyAmount[0]+FlyingEnemyAmount[1]+FlyingEnemyAmount[2];
        if (gea > 0)
        {
            geList = generatePositions(gridSize, gea);
            for (int i=0; i<3; i++)
            {
                for (int j=0; j<GroundEnemyAmount[i]; j++)
                {
                    Vector3Int pos = geList[0];
                    pos[1] = 0;
                    IndEnemyAndPosList.Add((i+1, pos));
                    geList.RemoveAt(0);
                }
            }
        }
        if (fea > 0)
        {
            feList = generatePositions(gridSize, fea);
            for (int i=0; i<3; i++)
            {
                for (int j=0; j<FlyingEnemyAmount[i]; j++)
                {
                    Vector3Int pos = feList[0];
                    IndEnemyAndPosList.Add((i+4, pos));
                    feList.RemoveAt(0);
                }
            }
        }
        return IndEnemyAndPosList;
    }

    List<Vector3Int> generatePositions(Vector3Int gridSize, int elementAmount)
    {
        HashSet<Vector3Int> list_pos = new HashSet<Vector3Int>();
        Vector3Int pos;
        int x,y,z;

        do
        {
            x = gridSize[0];
            y = gridSize[1];
            z = gridSize[2];

            pos = new Vector3Int(
                Random.Range(0, x), 
                Random.Range(0, y), 
                Random.Range(0, z)
            );

            list_pos.Add(pos);
        }
        while (list_pos.Count < elementAmount);

        return list_pos.ToList();
    }
}



