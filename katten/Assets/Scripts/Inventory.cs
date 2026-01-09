using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Vector2 endPos;
    Vector2 hiddenPos;

    public RectTransform imageRect;
    public Button openButton;

    public Shop shop;

    public float duration = 0.35f;
    public float startXOffset = 400f;
    Coroutine anim;
    bool shown;

    public Button none;
    public Button wol;
    public Button mario;
    public Button wizard;

    
    void Update()
    {
       
    }

    void Awake()
    {
        endPos = imageRect.anchoredPosition;
        hiddenPos = endPos + Vector2.right * startXOffset;

        imageRect.anchoredPosition = hiddenPos;

        openButton.onClick.AddListener(Toggle);

        none.onClick.AddListener(Nohat);
        wol.onClick.AddListener(bolwol);
        mario.onClick.AddListener(mariohat);
        wizard.onClick.AddListener(wizardhat);

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

    public void Nohat()
    {

    }

    public void bolwol()
    {

    }

    public void mariohat()
    {

    }

    public void wizardhat()
    {

    }
} 
