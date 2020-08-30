using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public int currentStage = 1;
    public Stage[] stages;

    public void IncrementStage()
    {
        currentStage++;
        stages[currentStage - 1].target.gameObject.SetActive(true);
    }
}
