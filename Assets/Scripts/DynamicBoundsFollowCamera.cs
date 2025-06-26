using UnityEngine;

public class DynamicBoundsFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
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
        //Just make this object follow the camera rather than the player. Because following player means left and right movement will also change and boundaries will not function properly.
        transform.position = new Vector3(0, 0, cameraTransform.position.z);
    }
}
