using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private GameObject managerGO;
    private ThrowKnife throwKnife;
    private StageController stageController;

    private GameObject enemiesParent;
    private Entity[] enemies;

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies");
        managerGO = GameObject.Find("Manager");
        throwKnife = managerGO.GetComponent<ThrowKnife>();
        stageController = managerGO.GetComponent<StageController>();
        enemies = enemiesParent.GetComponentsInChildren<Entity>();

        stageController.onStageCompleted += RestartGame;
        stageController.onStageCompleted += throwKnife.RestartKnifesThrow;
        GameStatus.ToggleGameActivation(false);

    }
    public void StartGame()
    {
        throwKnife.SetKnifePosition(0, throwKnife.knifeStartPosition.position);
        stageController.ReleaseFirstStage();
        Invoke("ReleaseGameStatus", 1f);
    }

    public void RestartGame()
    {
        for (int i = 0; i < throwKnife.knifesStorage.Length; i++)
        {
            throwKnife.SetKnifePosition(i, throwKnife.knifeStartPosition.position);
        }
    }
    public void ReturnMenu()
    {
        throwKnife.SetKnifePosition(0, throwKnife.knifeMenuPosition.position);

        for (int i = 1; i < throwKnife.knifesStorage.Length; i++)
        {
            throwKnife.SetKnifePosition(i, throwKnife.knifeStartPosition.position);
        }
    }

    public void ReleaseGameStatus()
    {
        GameStatus.ToggleGameActivation(true);
    }
}
