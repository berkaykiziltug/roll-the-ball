using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    [SerializeField] private Transform vectorBottom;
    [SerializeField] private Transform vectorForward;
    [SerializeField] private Transform vectorLeft;
    [SerializeField] private Transform vectorRight;


    void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.z = Mathf.Clamp(viewPosition.z, vectorBottom.transform.position.z, vectorForward.transform.position.z);
        viewPosition.x = Mathf.Clamp(viewPosition.x, vectorLeft.transform.position.x, vectorRight.transform.position.x);

        transform.position = viewPosition;
    
    }
}
