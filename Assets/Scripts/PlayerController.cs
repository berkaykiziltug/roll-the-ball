using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    [SerializeField] private float moveSpeed;
    private Rigidbody rigidBody;
    private bool isTouching;
    private bool hasMoved;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //If there is touch input... Only a single input
        if (Input.touchCount > 0)
        {
            isTouching = true;
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                hasMoved = true;
            }
        }
        else
        {
            isTouching = false;
        }
    }

    void FixedUpdate()
    {
        if (hasMoved)
        {
            rigidBody.linearVelocity = new Vector3(touch.deltaPosition.x * moveSpeed,
            0,
            touch.deltaPosition.y * moveSpeed);
        }
        else
        {
            return;
        }
       
    }

}
