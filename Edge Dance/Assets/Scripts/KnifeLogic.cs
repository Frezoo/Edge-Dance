using UnityEngine;
using UnityEngine.InputSystem;

public class KnifeLogic : MonoBehaviour
{
    public GameObject Knife;
    private Rigidbody knifeRB;
    private Vector3 forceVector;

    public float impulseCooldown = 0.1f;
    private float lastImpulseTime = 0f;
    private bool flag = false;
    void Start()
    {
        Knife = gameObject;
        knifeRB = GetComponent<Rigidbody>();
        forceVector = new Vector3(0, 300, 140);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            flag = true;
        }
    }
    private void FixedUpdate()
    {
        if (flag)
        {
            AddKnifeForce();
            flag = false;
        }

    }

    void AddKnifeForce()
    {

        Vector3 worldForce = forceVector * 1.1f;

        if (Time.time - lastImpulseTime >= impulseCooldown)
        {
            knifeRB.linearVelocity = new Vector3(0, 0, knifeRB.linearVelocity.z / 20);
            

            knifeRB.AddForce(worldForce * Time.deltaTime, ForceMode.Impulse);
            knifeRB.AddTorque(760 * Time.deltaTime, 0, 0);
            lastImpulseTime = Time.time; 
        }
    }
}
