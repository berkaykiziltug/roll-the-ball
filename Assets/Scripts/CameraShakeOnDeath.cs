using System.Collections;
using UnityEngine;

public class CameraShakeOnDeath : MonoBehaviour
{

    void Start()
    {
        PlayerCollision.Instance.OnDeath += ShakeCameraWrapper;
    }

    private void ShakeCameraWrapper(object sender, System.EventArgs e)
    {
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsedTime = 0f;
        float duration = .4f;
        float shakeIntensifier = 1f;
        while (elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensifier;
            float y = Random.Range(-1f, 1f) * shakeIntensifier;
            transform.localPosition = new Vector3(x, y, originalPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = new Vector3(0,0,0);
    }
   
   
}
