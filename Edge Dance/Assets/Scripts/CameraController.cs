using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform KnfieControllPoint;
    void Update()
    {
        transform.position =  Vector3.Lerp(transform.position,new Vector3(transform.position.x, transform.position.y,KnfieControllPoint.position.z+2),Time.deltaTime * 15);
    }
}