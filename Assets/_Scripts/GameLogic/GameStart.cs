using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private GameObject managerGO;
    private ThrowKnife throwKnife;
    private UIManager uimanager;

    private StageController stageController;

    private GameObject enemiesParent;
    private TargetEnemy[] enemies;

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies");
        managerGO = GameObject.Find("Manager");
        throwKnife = managerGO.GetComponent<ThrowKnife>();
        stageController = managerGO.GetComponent<StageController>();
        uimanager = managerGO.GetComponent<UIManager>();
        enemies = enemiesParent.GetComponentsInChildren<TargetEnemy>();

        stageController.onStageCompleted += RestartGame;
        GameStatus.ToggleGameActivation(false);

    }
    public void StartGame()
    {
        throwKnife.RestartKnifesThrow();
        //throwKnife.SetKnifePosition(0, throwKnife.knifeStartPosition.position);

        for (int i = 0; i < throwKnife.knifesStorage.Length; i++)
        {
            throwKnife.SetKnifePosition(i, throwKnife.knifeStartPosition.position);
        }

        stageController.ReleaseFirstStage();
        ScoreController.SetScore(0);

        uimanager.UpdateUI();
        Invoke("ReleaseGameStatus", 1f);
    }

    public void RestartGame()
    {
        throwKnife.RestartKnifesThrow();
        for (int i = 0; i < throwKnife.knifesStorage.Length; i++)
        {
            throwKnife.SetKnifePosition(i, throwKnife.knifeStartPosition.position);
        }

        uimanager.UpdateUI();
    }
    public void ReturnMenu()
    {
        enemies = enemiesParent.GetComponentsInChildren<TargetEnemy>();

        foreach (TargetEnemy enemy in enemies)
        {
            enemy.countHitInteraction.RestartHits();
            enemy.gameObject.SetActive(false);
        }
        throwKnife.RestartKnifesThrow();

        GameStatus.ToggleGameActivation(false);

        for (int i = 0; i < throwKnife.knifesStorage.Length; i++)
        {
            throwKnife.SetKnifePosition(i, throwKnife.knifeStartPosition.position);
        }

        uimanager.UpdateUI();
    }

    public void ReleaseGameStatus()
    {
        GameStatus.ToggleGameActivation(true);
    }
}
