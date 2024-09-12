using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinCollector : MonoBehaviour
{
    public int coinCount = 0;

    public TextMeshProUGUI coinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Coin"))
        {
            coinCount++;
            coinText.text = "Coin: " + coinCount.ToString();
            Debug.Log (coinCount);
            Destroy(other.gameObject);
        }
    }

   
}
