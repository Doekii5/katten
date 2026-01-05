using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FORWARDDAY : MonoBehaviour
{
    public Button PijltjeForward;
    public TextMeshProUGUI Counter;
    public int DayCount;
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
        Debug.Log("Day: " + DayCount);  
    }

    void UpdateDayText()
    {
        Counter.text = DayCount.ToString();
    }
}
