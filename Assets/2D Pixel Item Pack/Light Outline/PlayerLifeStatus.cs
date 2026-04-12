using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// 
/// </summary>

public class PlayerLifeStatus : MonoBehaviour
{
    [SerializeField] private int maxHP = 3;
    private int currentHP;

    public static event Action<int> OnLifeChanged;
    public static event Action OnLifeZero;

    void Awake()
    {
        currentHP = maxHP;
    }

    private void OnEnable()
    {
        PlayerController.OnHitEnemy += Damage;
    }

    private void OnDisable()
    {
        PlayerController.OnHitEnemy -= Damage;
    }

    void Damage()
    {
        currentHP--;
        OnLifeChanged?.Invoke(currentHP);

        if (currentHP <= 0)
            OnLifeZero?.Invoke();
    }
}

