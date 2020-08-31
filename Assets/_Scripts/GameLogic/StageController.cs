using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public int currentStage = 0;
    public static int maxStage = 0;
    public Stage[] stages;
    public delegate void OnStageCompleted();
    public OnStageCompleted onStageCompleted = delegate { };

    public void ReleaseFirstStage()
    {
        currentStage = 0;
        stages[currentStage].target.gameObject.SetActive(true);
    }

    public void IncrementStage()
    {
        currentStage++;
        onStageCompleted();
        stages[currentStage].target.gameObject.SetActive(true);

        if (currentStage >= stages.Length)
        {
            SceneManager.LoadScene("Win");
        }

        if (currentStage > maxStage)
            maxStage = currentStage;
    }
}
