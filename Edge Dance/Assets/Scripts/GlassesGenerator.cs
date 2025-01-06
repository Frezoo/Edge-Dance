using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GlassesGenerator : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;

    public List<GameObject> CanCatchOBJ;
    public List<GameObject> TrapsOBJ;
    [SerializeField] private float spawnInterval;

    public List<Vector3> ObjPositions = new List<Vector3>();
    public List<GameObject> CatchObjects = new List<GameObject>();

    private void Awake()
    {
        GenerateGlasses();
    }

    private void GenerateGlasses()
    {
        ObjPositions.Add(StartPoint.position);
        while (ObjPositions[ObjPositions.Count - 1].z + spawnInterval < EndPoint.position.z)
        {
            float objectChance = Random.Range(0f, 1f);
            Vector3 spawnPoint = ObjPositions[ObjPositions.Count - 1] + new Vector3(0, 0, Random.Range(spawnInterval, 3 * spawnInterval));
            if (objectChance > 0f && objectChance <= 0.01f)
            {
                objectChance = 2;
                CatchObjects.Add((GameObject)Instantiate(CanCatchOBJ[(int)objectChance], spawnPoint, CanCatchOBJ[(int)objectChance].transform.rotation));
            }
            if (objectChance > 0.1f && objectChance <= 0.22f)
            {
                int trapNumber = Random.Range(0, 2);
                Instantiate(TrapsOBJ[trapNumber], spawnPoint - new Vector3(0,0.4f,0), TrapsOBJ[trapNumber].transform.rotation);
            }
            else
            {
                objectChance = (int)Random.Range(0, 2);
                CatchObjects.Add((GameObject)Instantiate(CanCatchOBJ[(int)objectChance], spawnPoint, CanCatchOBJ[(int)objectChance].transform.rotation));
            }
 
            ObjPositions.Add(spawnPoint);
        }
        ObjPositions.Remove(StartPoint.position);
        int secondRowObjectNumber = -1;
        foreach (Vector3 posZ in ObjPositions)
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
