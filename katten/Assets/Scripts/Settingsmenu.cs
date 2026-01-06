using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DropInImage : MonoBehaviour
{
    Vector2 endPos;
    Vector2 hiddenPos;
    public RectTransform imageRect;
    public Button openButton;
    public float duration = 0.35f;
    public float startYOffset = 800f;

    public Button resetButton;
    public Button quitButton;

    Coroutine anim;
    bool shown;

    void Awake()
    {
        endPos = imageRect.anchoredPosition;
        hiddenPos = endPos + Vector2.up * startYOffset;
        imageRect.anchoredPosition = hiddenPos;
        openButton.onClick.AddListener(Toggle);
        resetButton.onClick.AddListener(Resetsave);
        quitButton.onClick.AddListener(Quit);
    }

    void Toggle()
    {
        shown = !shown;
        StartAnim(shown ? endPos : hiddenPos);
    }

    void Resetsave()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void Quit()
    {
        Application.Quit();
    }
    void StartAnim(Vector2 target)
    {
        if (anim != null) StopCoroutine(anim);
        anim = StartCoroutine(AnimateTo(target));
    }

    IEnumerator AnimateTo(Vector2 target)
    {
        Vector2 start = imageRect.anchoredPosition;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float s = Mathf.SmoothStep(0f, 1f, t / duration);
            imageRect.anchoredPosition = Vector2.Lerp(start, target, s);
            yield return null;
        }

        imageRect.anchoredPosition = target;
        anim = null;
    }
}

