using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Questmenu : MonoBehaviour
{
    Vector2 endPos;
    Vector2 hiddenPos;

    public RectTransform imageRect;
    public Button openButton;
    public Button openButton2;
    public Button closeButton;

    public WalkTracker walkTracker;
    public Coins coins;


    public float duration = 0.35f;
    public float startXOffset = 400f;

    public TextMeshProUGUI DistanceQuest;
    public TextMeshProUGUI TimeQuest;
    public TextMeshProUGUI AmountQuest;

    Coroutine anim;
    bool shown;

    bool distanceRewardGiven;
    bool timeRewardGiven;
    bool amountRewardGiven;

    void Update()
    {
        UpdateText();
        if (!distanceRewardGiven && walkTracker.totalDistance >= 4)
        {
            DistanceQuest.color = Color.green;
            coins.CoinTotal += 100;
            distanceRewardGiven = true;
        }

        if (!timeRewardGiven && walkTracker.totalMinutes >= 30)
        {
            TimeQuest.color = Color.green;
            coins.CoinTotal += 200;
            timeRewardGiven = true;
        }

        if (!amountRewardGiven && walkTracker.amount >= 3)
        {
            AmountQuest.color = Color.green;
            coins.CoinTotal += 50;
            amountRewardGiven = true;
        }
    }

    void Awake()
    {
        endPos = imageRect.anchoredPosition;
        hiddenPos = endPos + Vector2.left * startXOffset;

        imageRect.anchoredPosition = hiddenPos;

        openButton.onClick.AddListener(Toggle);
        openButton2.onClick.AddListener(Toggle);
        closeButton.onClick.AddListener(Toggle);
    }

    void Toggle()
    {
        shown = !shown;
        if (shown)
            RefreshQuestColors();
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
        DistanceQuest.text = "Distance Walked\n" + walkTracker.totalDistance + "/4km";
        TimeQuest.text = "Time Walked\n" + Mathf.FloorToInt(walkTracker.totalMinutes) + "/30min";
        AmountQuest.text = "Amount of Walks\n" + walkTracker.amount + "/3";
    }

    void RefreshQuestColors()
    {
        if (distanceRewardGiven)
        {
            DistanceQuest.color = Color.green;
        }
        if (timeRewardGiven)
        {
            TimeQuest.color = Color.green;
        }

        if (amountRewardGiven)
        {
            AmountQuest.color = Color.green;
        }
    }
}

