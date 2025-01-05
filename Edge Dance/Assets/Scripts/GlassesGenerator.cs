using System.Collections.Generic;
using UnityEngine;

public class GlassesGenerator : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;

    public GameObject Glass;
    [SerializeField] private float spawnInterval;

    public List<Vector3> GlassesPositions = new List<Vector3>();

    private void Awake()
    {
        GenerateGlasses();
    }

    private void GenerateGlasses()
    {
        GlassesPositions.Add(StartPoint.position);
        while (GlassesPositions[GlassesPositions.Count - 1].z + spawnInterval < EndPoint.position.z)
        {
            Vector3 spawnPoint = GlassesPositions[GlassesPositions.Count - 1] + new Vector3(0, 0, Random.Range(spawnInterval, 3 * spawnInterval));
            Instantiate(Glass,spawnPoint,Glass.transform.rotation);
            GlassesPositions.Add(spawnPoint);
        }
        foreach (Vector3 posZ in GlassesPositions)
        {
            if (Random.Range(0f, 1f) < 0.15f)
            {
                Instantiate(Glass, new Vector3(posZ.x, 2.178f, posZ.z), Glass.transform.rotation);
            }
        }

    }


}
