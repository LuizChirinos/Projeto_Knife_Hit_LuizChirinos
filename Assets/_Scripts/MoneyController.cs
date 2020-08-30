using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class MoneyController
{
    public static int money = 0;

    public static void SetMoney(int value)
    {
        money = value;
    }
    public static void ModifyMoney(int amount)
    {
        money += amount;
    }
}
