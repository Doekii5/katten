using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Vector2 endPos;
    Vector2 hiddenPos;

    public RectTransform imageRect;
    public Button openButton;

    public Shop shop;
    public Levelloaderscript level;

    public float duration = 0.35f;
    public float startXOffset = 400f;
    Coroutine anim;
    bool shown;

    public bool wolused;
    public bool marioactive;
    public bool wizardactive;

    public Button none;
    public Button wol;
    public Button mario;
    public Button wizard;

    public Image BOLWOL;
    public Image MARIO;
    public Image WIZARD;
    //public Image backwool;

    public Color marioColor;
    public Color wizardColor;
    //public Color backwoolcolor;
    public Color equipColor = Color.green;

    void Start()
    {
        WIZARD.gameObject.SetActive(false);
        MARIO.gameObject.SetActive(false);

        //mario.image.color = Color.gray;
        //wizard.image.color = Color.gray;
        //backwool.color = Color.gray;

        marioColor = mario.image.color;
        wizardColor = wizard.image.color;
        //backwoolcolor = backwool.color;

        

        wol.interactable = false;
    }

    void Awake()
    {
        endPos = imageRect.anchoredPosition;
        hiddenPos = endPos + Vector2.right * startXOffset;
        imageRect.anchoredPosition = hiddenPos;

        openButton.onClick.AddListener(Toggle);

        none.onClick.AddListener(Nohat);
        wol.onClick.AddListener(Bolwol);
        mario.onClick.AddListener(Mariohat);
        wizard.onClick.AddListener(Wizardhat);
    }

    void Update()
    {
        if (shop.wolbought == true && wolused == false)
        {
            wol.interactable = true;
        }
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
        MARIO.gameObject.SetActive(false);
        WIZARD.gameObject.SetActive(false);
        wizard.image.color = wizardColor;
        mario.image.color = marioColor;

        marioactive = false;
        wizardactive = false;
    }

    public void Bolwol()
    {
        if (shop.wolbought == true)
        {
            level.woltr();
            wolused = true;
            wol.interactable = false;
            shop.ResetWolForSale();
        }
    }

    public void Mariohat()
    {
        if (shop.mariobought == true)
        {
            WIZARD.gameObject.SetActive(false);
            MARIO.gameObject.SetActive(true);
            mario.image.color = equipColor;
            wizard.image.color = wizardColor;
            wizardactive = false;
            marioactive = true;
        }
    }

    public void Wizardhat()
    {
        if (shop.wizardbought == true)
        {
            WIZARD.gameObject.SetActive(true);
            MARIO.gameObject.SetActive(false);
            wizard.image.color = equipColor;
            mario.image.color = marioColor;
            wizardactive = true;
            marioactive = false;
        }
    }

    public void OnWolBought()
    {
        wolused = false;
    }
}

