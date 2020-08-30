using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public int currentStage = 1;
    public static int maxStage = 1;
    public Stage[] stages;
    public delegate void OnStageCompleted();
    public OnStageCompleted onStageCompleted = delegate { };

    public void ReleaseFirstStage()
    {
        currentStage = 1;
        stages[currentStage - 1].target.gameObject.SetActive(true);
    }

    public void IncrementStage()
    {
        currentStage++;
        onStageCompleted();
        stages[currentStage - 1].target.gameObject.SetActive(true);

        if (currentStage > maxStage)
            maxStage = currentStage;
    }
}
