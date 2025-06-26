using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    private Touch touch;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float forwardSpeed;
    public bool isFirstTouch;
    private Rigidbody rigidBody;
    private bool isTouching;
    private bool hasMoved;

    private Vector3 newVelocity = Vector3.zero;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {

        if (Variables.firstTouch == 1)
        {
            isFirstTouch = true;
        }
        //If there is touch input... Only a single input
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Variables.firstTouch = 1;
                isTouching = true;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                hasMoved = true;
            }
        }
        else
        {
            isTouching = false;
        }
        if (touch.phase == TouchPhase.Ended)
        {
            hasMoved = false;
        }
    }

    void FixedUpdate()
    {
        newVelocity = Vector3.zero;
        if (isFirstTouch)
        {
            //Continuous forward movement.
            newVelocity.z = forwardSpeed;
        }
        if (hasMoved)
        {
            newVelocity.x = touch.deltaPosition.x * moveSpeed;

            newVelocity.z += touch.deltaPosition.y * moveSpeed;
        }

        rigidBody.linearVelocity = newVelocity;

    }
    public Vector3 GetPlayerVelocity()
    {
        return newVelocity;
    }

    public float GetPlayerConstantForwardSpeed()
    {
        return forwardSpeed;
    }

    public bool IsFirstTouch()
    {
        return isFirstTouch;
    }

}
