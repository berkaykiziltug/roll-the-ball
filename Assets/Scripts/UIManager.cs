using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject whiteImage;
    public static UIManager Instance { get; private set; }
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
        PlayerCollision.Instance.OnDeath += StartScreenEffect;
    }

    private void StartScreenEffect(object sender, EventArgs e)
    {
        StartCoroutine(StartWhiteScreenEffect());
    }

    public IEnumerator StartWhiteScreenEffect()
    {
        float elapsedTime = 0f;
        float duration = .015f;
        whiteImage.SetActive(true);
        Image image = whiteImage.GetComponent<Image>();
        Color whiteImageAlpha = image.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            whiteImageAlpha.a = Mathf.Lerp(0, 1, elapsedTime / duration);
            image.color = whiteImageAlpha;
            yield return null;
        }
         whiteImageAlpha.a = 1;
        image.color = whiteImageAlpha;
        StartCoroutine(EndWhiteScreenEffect());
    }
    public IEnumerator EndWhiteScreenEffect()
    {
        float elapsedTime = 0f;
        float duration = .015f;
        Image image = whiteImage.GetComponent<Image>();
        Color whiteImageAlpha = image.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            whiteImageAlpha.a = Mathf.Lerp(1, 0, elapsedTime / duration);
            image.color = whiteImageAlpha;
            yield return null;
        }
        whiteImageAlpha.a = 0;
        image.color = whiteImageAlpha;
        whiteImage.SetActive(false);
    }
}
