using Unity.VisualScripting;
using UnityEngine;

public class GlassLogic : MonoBehaviour
{
    public GameObject FirstHalf;
    private Rigidbody firstHalfRB;

    public GameObject SecondHalf;
    private Rigidbody secondHalfRB;

    [SerializeField] private float Value;
    private bool isTrigger = true;
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
        if (collision.CompareTag("Knife") && isTrigger)
        {
            DisableKinematicRigibody();
            collision.gameObject.GetComponent<KnifeLogic>().UpdateScore(Value);
            isTrigger = false;
            
        }
    }
}
