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
        Debug.Log("Triggered with: " + other.gameObject.name + " Layer: " + LayerMask.LayerToName(other.gameObject.layer)); // выводим информацию о триггере

        if (other.gameObject.tag == "Knife") // если у ножа правильный тег
        {
            Debug.Log("Knife entered trigger, executing code");
            finishLogic.EnableFinishPanel(GameObject.Find("Knife").GetComponent<KnifeLogic>());
        }
        
    }
}