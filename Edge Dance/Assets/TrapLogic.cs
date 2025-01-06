using UnityEngine;

public class TrapLogic : MonoBehaviour
{
    private FinishLogic finishLogic;

    void Start()
    {
        finishLogic = GameObject.Find("x0.5").GetComponent<FinishLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name + " Layer: " + LayerMask.LayerToName(other.gameObject.layer)); // ������� ���������� � ��������

        if (other.gameObject.tag == "Knife") // ���� � ���� ���������� ���
        {
            Debug.Log("Knife entered trigger, executing code");
            finishLogic.EnableFinishPanel(GameObject.Find("Knife").GetComponent<KnifeLogic>());
        }
        
    }
}