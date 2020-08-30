using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatus
{
    public static bool gameActive = false;

    public static void ToggleGameActivation(bool value)
    {
        gameActive = value;
    }
}
