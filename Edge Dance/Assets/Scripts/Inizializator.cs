using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inizializator : MonoBehaviour
{
    public List<GameObject> Knifes = new List<GameObject>();
    public GameObject CurrentKnife;
    private Vector3 Spawn = new Vector3(0.209999993f, 1.48000002f, -3.56999993f);
    private void Awake()
    {
        int randint = Random.Range(0, Knifes.Count);
        CurrentKnife = (GameObject)Instantiate(Knifes[randint],Spawn, Knifes[randint].transform.rotation);
    }
}
