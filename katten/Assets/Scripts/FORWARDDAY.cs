using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;

public class FORWARDDAY : MonoBehaviour
{
    public Button PijltjeForward;
    public TextMeshProUGUI Counter;
    public int DayCount;
    public Levelloaderscript levelloaderscript;
    public float stage = 1;
    public float consecutivewalks;
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
            } else
            {
                consecutivewalks = 0;
            }
            if (consecutivewalks == 5)
            {
                stage = 1;
                consecutivewalks = 0;
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
