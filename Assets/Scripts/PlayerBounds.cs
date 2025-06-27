using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    [SerializeField] private Transform vectorBottom;
    [SerializeField] private Transform vectorForward;
    [SerializeField] private Transform vectorLeft;
    [SerializeField] private Transform vectorRight;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {

        Vector3 nextPosition = rb.position + PlayerController.Instance.GetPlayerVelocity() * Time.fixedDeltaTime;
        float clampedX = Mathf.Clamp(nextPosition.x, vectorLeft.position.x, vectorRight.position.x);
        float clampedZ = Mathf.Clamp(nextPosition.z, vectorBottom.position.z, vectorForward.position.z);
        
        Vector3 clampedNextPosition = new Vector3(clampedX, nextPosition.y, clampedZ);

        //Velocity = Distance/Time. Basic physics formula.
        Vector3 clampedVelocity = (clampedNextPosition - rb.position) / Time.fixedDeltaTime;

        rb.linearVelocity = clampedVelocity;
    }
}
