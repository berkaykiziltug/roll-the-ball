using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static PlayerCollision Instance { get; private set; }
    [SerializeField] private GameObject[] sphereFracturesList;

    public EventHandler OnDeath;
    private Rigidbody rb;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach (GameObject gameObject in sphereFracturesList)
            {
                OnDeath?.Invoke(this, EventArgs.Empty);
                SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
                Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                sphereCollider.enabled = true;

            }
        }
    }
}
