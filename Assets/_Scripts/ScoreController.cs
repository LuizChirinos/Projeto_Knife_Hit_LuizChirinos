using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class ScoreController
{
    public static int score = 0;
    public static int maxScore = 0;

    public static void SetScore(int value)
    {
        score = value;
    }
    public static void ModifyScore(int amount)
    {
        score += amount;
        if (score > maxScore)
            maxScore = score;
    }
}
