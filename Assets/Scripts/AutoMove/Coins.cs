using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    int coins = 0;
    [SerializeField] Text coinsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            coins++;
            coinsText.text = "Coins: " + coins;
            Destroy(collision.gameObject);
        }
    }
}
