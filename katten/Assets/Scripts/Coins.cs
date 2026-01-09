using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public int CoinTotal;
    public TextMeshProUGUI CoinCounter;
    public MusicVolumeUI muziek;

    int lastCoinTotal;

    void Start()
    {
        CoinTotal = 0;
        lastCoinTotal = CoinTotal;
        CoinCounter.text = CoinTotal.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CoinTotal += 100;
            muziek.coinsfx();
        }

        if (CoinTotal > lastCoinTotal)
        {
            Debug.Log("make it rain");
            
        }

        lastCoinTotal = CoinTotal;
        CoinCounter.text = CoinTotal.ToString();
    }
}
