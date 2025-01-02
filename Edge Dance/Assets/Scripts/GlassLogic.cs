using Unity.VisualScripting;
using UnityEngine;

public class GlassLogic : MonoBehaviour
{
    public GameObject FirstHalf;
    private Rigidbody FirstHalfRB;

    public GameObject SecondHalf;
    private Rigidbody SecondHalfRB;

    void Start()
    {
        FirstHalf = transform.GetChild(0).gameObject;
        SecondHalf = transform.GetChild(1).gameObject;
        FirstHalfRB = FirstHalf.GetComponent<Rigidbody>();
        SecondHalfRB = SecondHalf.GetComponent<Rigidbody>();
    }

    private void DisableKinematicRigibody()
    {
        FirstHalfRB.isKinematic = false;
        SecondHalfRB.isKinematic = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        print("GetTrigger");
        if (collision.CompareTag("Knife"))
        {
            DisableKinematicRigibody();

        }
    }
}
