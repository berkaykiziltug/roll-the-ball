using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void LateUpdate()
    {
         if (PlayerController.Instance.IsFirstTouch())
        {
            transform.position +=  new Vector3(0, 0, PlayerController.Instance.GetPlayerConstantForwardSpeed()*Time.deltaTime);
        }
    }
}
    
