using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CountHitsInteraction))]
public class TargetEnemy : MonoBehaviour
{
    public CountHitsInteraction pointGiverInteraction;
    private ThrowKnife throwKnife;
    private GameObject managerGO;
    private StageController stageController;

    private void Start()
    {
        pointGiverInteraction = GetComponent<CountHitsInteraction>();
        pointGiverInteraction.interactionEvent += CheckHits;
        managerGO = GameObject.Find("Manager");
        throwKnife = managerGO.GetComponent<ThrowKnife>();
        stageController = managerGO.GetComponent<StageController>();
    }

    public void CheckHits(Collider2D col)
    {
        if (pointGiverInteraction.amountOfHits >= throwKnife.knifesStorage.Length-1)
        {
            stageController.IncrementStage();
            Debug.Log("Current Stage " + stageController.currentStage);
            //Mudar implementação de Die()
            Die();
        }
    }

    public virtual void Die()
    {
        pointGiverInteraction.RestartHits();
        gameObject.SetActive(false);
    }
}
