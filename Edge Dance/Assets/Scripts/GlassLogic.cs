using Unity.VisualScripting;
using UnityEngine;

public class GlassLogic : MonoBehaviour
{
    public GameObject FirstHalf;
    private Rigidbody firstHalfRB;

    public GameObject SecondHalf;
    private Rigidbody secondHalfRB;

    void Start()
    {
        FirstHalf = transform.GetChild(0).gameObject;
        SecondHalf = transform.GetChild(1).gameObject;
        firstHalfRB = FirstHalf.GetComponent<Rigidbody>();
        secondHalfRB = SecondHalf.GetComponent<Rigidbody>();
    }

    private void DisableKinematicRigibody()
    {
        firstHalfRB.isKinematic = false;
        secondHalfRB.isKinematic = false;
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
