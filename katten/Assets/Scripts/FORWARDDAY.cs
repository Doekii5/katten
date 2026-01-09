using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FORWARDDAY : MonoBehaviour
{
    public UnityEngine.UI.Button PijltjeForward;
    public TextMeshProUGUI Counter;
    public int DayCount;
    public Levelloaderscript levelloaderscript;
    public float stage = 1;
    public float consecutivewalks;
    public progressBar progressbar;
    public TextMeshProUGUI howmuch;
    // Start is called before the first frame update
    void Awake()
    {
        DayCount = 0;
        UpdateDayText();
        PijltjeForward.onClick.AddListener(AddDay);
    }

    // Update is called once per frame  
    void AddDay()
    {
        DayCount += 1;
        UpdateDayText();
        progressbar.walkChange(0);
        if (stage != 5) {
            if (levelloaderscript.timesWalked > 1)
            {
                if (stage != 1)
                {
                    --stage;
                }
            } else
            {
                Debug.Log("Increasing stage from: " + stage);
                ++stage;
                Debug.Log("Stage increased to: " + stage);
            }
        } else
        {
            if (levelloaderscript.timesWalked > 1)
            {
                ++consecutivewalks;
                howmuch.text = consecutivewalks + "/5";
            } else
            {
                consecutivewalks = 0;
                howmuch.text = consecutivewalks + "/5";
            }
            if (consecutivewalks == 5)
            {
                stage = 1;
                consecutivewalks = 0;
                howmuch.text = null;
            }
        }
        levelloaderscript.timesWalked = 0;
        levelloaderscript.StageChange(stage);
        Debug.Log("Day: " + DayCount);
        Debug.Log(stage);

    }

    void UpdateDayText()
    {
        Counter.text = DayCount.ToString();
    }
}
