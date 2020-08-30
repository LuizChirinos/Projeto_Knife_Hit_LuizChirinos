using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[System.Serializable]
public static class ScoreController
{
    public static int score = 0;

    public static void SetScore(int value)
    {
        score = value;
    }
    public static void ModifyScore(int amount)
    {
        score += amount;
    }
}
