using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bonus", fileName = "New Bonus")]

public class BonusData : ScriptableObject
{
    [Tooltip("Спрайт")] [SerializeField] private Sprite mainSprite;
    public Sprite MainSprite 
    { 
        get { return mainSprite; } 
        protected set { } 
    }

    [Tooltip("Шанс появления в процентах")] [SerializeField] private int chance;
    public int Chance
    {
        get { return chance; }
        protected set { }
    }
}
