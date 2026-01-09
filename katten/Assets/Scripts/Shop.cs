using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Vector2 endPos;
    Vector2 hiddenPos;

    public RectTransform imageRect;
    public Button openButton;

    public Coins coins;

    public float duration = 0.35f;
    public float startXOffset = 400f;
    Coroutine anim;
    bool shown;

    public Color boughtColor = Color.gray;
    public Color wolOriginalColor;

    public Button mario;
    public bool mariobought;
    public Button wizard;
    public bool wizardbought;
    public Button wol;
    public bool wolbought;
    public Inventory inventory;
    

    void Start()
    {
        wolbought = false;
        wizardbought = false;
        mariobought = false;

        wolOriginalColor = wol.image.color;
    }

    void Awake()
    {
        endPos = imageRect.anchoredPosition;
        hiddenPos = endPos + Vector2.left * startXOffset;
        imageRect.anchoredPosition = hiddenPos;

        openButton.onClick.AddListener(Toggle);

        wol.onClick.AddListener(Buywool);
        wizard.onClick.AddListener(Buywizard);
        mario.onClick.AddListener(Buymario);
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

    public void Buywool()
    {
        if (wolbought == false)
        {
            if (coins.CoinTotal >= 150)
            {
                coins.CoinTotal -= 150;
                wolbought = true;
                wol.image.color = boughtColor;
                wol.interactable = false;

                if (inventory != null)
                {
                    inventory.OnWolBought();
                }
            }

        }
    }

    public void ResetWolForSale()
    {
        wolbought = false;
        wol.interactable = true;
        wol.image.color = wolOriginalColor;
        //inventory.backwool.color = Color.gray;
    }

    public void Buywizard()
    {
        if (wizardbought == false)
        {
            if (coins.CoinTotal >= 100)
            {
                coins.CoinTotal -= 100;
                wizardbought = true;
                wizard.image.color = boughtColor;
                wizard.interactable = false;
            }
        }
    }

    public void Buymario()
    {
        if (mariobought == false)
        {
            if (coins.CoinTotal >= 100)
            {
                coins.CoinTotal -= 100;
                mariobought = true;
                mario.image.color = boughtColor;
                mario.interactable = false;
            }
        }
    }
}

