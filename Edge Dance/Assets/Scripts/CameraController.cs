using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform KnfieControllPoint;
    void Update()
    {
        if(KnfieControllPoint.position.z + 2 <= 103.4)
            transform.position =  Vector3.Lerp(transform.position,new Vector3(transform.position.x, transform.position.y,KnfieControllPoint.position.z+2),Time.deltaTime * 15);

    }
}
