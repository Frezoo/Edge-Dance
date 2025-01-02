using UnityEngine;

public class KnifeLogic : MonoBehaviour
{
    public GameObject Knife;
    private Rigidbody knifeRB;

    private Vector3 forceVector;
    void Start()
    {
        Knife = gameObject;
        knifeRB = GetComponent<Rigidbody>();
        forceVector = new Vector3(0, 300, 140);
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddKnifeForce();
        }
    }

    void AddKnifeForce()
    {

        Vector3 worldForce = forceVector * 1.4f;

        knifeRB.linearVelocity = new Vector3(0,0, knifeRB.linearVelocity.z);
        knifeRB.angularVelocity = new Vector3(0, 0, knifeRB.linearVelocity.z);

        knifeRB.AddForce(worldForce * Time.deltaTime, ForceMode.Impulse);
        knifeRB.AddTorque(2550 * Time.deltaTime, 0, 0);
    }
}
