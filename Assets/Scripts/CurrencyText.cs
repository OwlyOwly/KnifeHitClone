using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyText : MonoBehaviour
{
    private TMP_Text currencyText;

    private void Awake()
    {
        currencyText = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        currencyText.text = PlayerPrefs.GetInt("Currency").ToString();
    }
}
