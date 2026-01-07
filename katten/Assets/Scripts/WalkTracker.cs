using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using TMPro;

public class WalkTracker : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI distancestat;
    public TextMeshProUGUI timestat;
    public TextMeshProUGUI amountstat;

    public bool IsWalking;

    float totalMinutes;
    float totalDistance;
    float distanceKm;
    float distanceTimer;
    float roundedMinutes;
    float timeSince;
    public int amount;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (!IsWalking) return;

        float dt = Time.deltaTime;

        totalMinutes += dt;       
        distanceTimer += dt;
        timeSince += dt;

        if (distanceTimer >= 10f)   
        {
            int kmToAdd = Mathf.FloorToInt(distanceTimer / 10f);
            distanceKm += kmToAdd;
            totalDistance += kmToAdd;
            distanceTimer -= kmToAdd * 10f;
        }

        UpdateUI();
    }

    public void StartWalk()
    {
        IsWalking = true;
        amount += 1;
    }

    public void StopWalk()
    {
        IsWalking = false;
        UpdateUI();
        distanceKm = 0;
        distanceTimer = 0;
        timeSince = 0;

        Debug.Log(totalMinutes);
        Debug.Log(totalDistance);
        Debug.Log(amount);

        timestat.text = "Total Time: " + Mathf.FloorToInt(totalMinutes) + "min";
        distancestat.text = "Total Distance: " + totalDistance + "km";
        amountstat.text = "Amount of Walks: " + amount;
    }

    void UpdateUI()
    {
        roundedMinutes = Mathf.RoundToInt(timeSince);

        timeText.text = roundedMinutes + " min";
        distanceText.text = distanceKm + " km";
    }
}


