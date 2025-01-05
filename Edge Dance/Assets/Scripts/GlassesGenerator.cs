using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GlassesGenerator : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;

    public List<GameObject> CanCatchOBJ;
    [SerializeField] private float spawnInterval;

    public List<Vector3> CatchPositions = new List<Vector3>();
    public List<GameObject> CatchObjects = new List<GameObject>();

    private void Awake()
    {
        GenerateGlasses();
    }

    private void GenerateGlasses()
    {
        CatchPositions.Add(StartPoint.position);
        while (CatchPositions[CatchPositions.Count - 1].z + spawnInterval < EndPoint.position.z)
        {
            float objectChance = Random.Range(0f, 1f);
            if (objectChance > 0f && objectChance <= 0.01f)
            {
                objectChance = 2;
            }
            else
            {
                objectChance = (int)Random.Range(0, 2);
            }

            Vector3 spawnPoint = CatchPositions[CatchPositions.Count - 1] + new Vector3(0, 0, Random.Range(spawnInterval, 3 * spawnInterval));
            CatchObjects.Add((GameObject)Instantiate(CanCatchOBJ[(int)objectChance], spawnPoint, CanCatchOBJ[(int)objectChance].transform.rotation));
            CatchPositions.Add(spawnPoint);
        }
        CatchPositions.Remove(StartPoint.position);
        int secondRowObjectNumber = -1;
        foreach (Vector3 posZ in CatchPositions)
        {
            secondRowObjectNumber++;
            if (Random.Range(0f, 1f) < 0.15f && (CatchObjects[secondRowObjectNumber].CompareTag("Glass") || CatchObjects[secondRowObjectNumber].CompareTag("GoldGlass")))
            {
                Instantiate(CanCatchOBJ[0], new Vector3(posZ.x, 2.178f, posZ.z), CanCatchOBJ[0].transform.rotation);
                print(CatchObjects[secondRowObjectNumber].tag  + " " + CatchObjects[secondRowObjectNumber].name);
            }
        }

    }


}
