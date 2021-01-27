using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private BonusData data;

    public void Init(BonusData _data)
    {
        data = _data;
        GetComponent<SpriteRenderer>().sprite = data.MainSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int tempCurrency = PlayerPrefs.GetInt("Currency") + 1;
        PlayerPrefs.SetInt("Currency", tempCurrency);
        Destroy(gameObject);
    }
}
