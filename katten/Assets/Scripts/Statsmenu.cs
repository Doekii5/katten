using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Statsmenu : MonoBehaviour
{
    Vector2 endPos;
    Vector2 hiddenPos;
    public RectTransform imageRect;
    public Button openButton;
    public float duration = 0.35f;
    public float startYOffset = 800f;

    public TextMeshProUGUI distance;
    public TextMeshProUGUI time;
    public TextMeshProUGUI count;

    public int TotalDistance;
    public int TotalTime;
    public int TotalCount;

    Coroutine anim;
    bool shown;

    void Awake()
    {
        endPos = imageRect.anchoredPosition;
        hiddenPos = endPos + Vector2.up * startYOffset;
        imageRect.anchoredPosition = hiddenPos;
        openButton.onClick.AddListener(Toggle);

        TotalDistance = 0;
        TotalTime = 0;
        TotalCount = 0;
        UpdateText();
    }
    void Toggle()
    {
        shown = !shown;
        StartAnim(shown ? endPos : hiddenPos);
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


    void UpdateText()
    {
        distance.text = "Total Distance: " + TotalDistance + "km";
        time.text = "Total Time: " + TotalTime + "min";
        count.text = "Amount of Walks: " + TotalCount;
    }
}
