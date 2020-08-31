using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CountHitsInteraction))]
public class TargetEnemy : MonoBehaviour
{
    public CountHitsInteraction countHitInteraction;
    private ThrowKnife throwKnife;
    private GameObject managerGO;
    private StageController stageController;

    private void Start()
    {
        countHitInteraction = GetComponent<CountHitsInteraction>();
        countHitInteraction.interactionEvent += CheckHits;
        managerGO = GameObject.Find("Manager");
        throwKnife = managerGO.GetComponent<ThrowKnife>();
        stageController = managerGO.GetComponent<StageController>();
    }

    public void CheckHits(Collider2D col)
    {
        if (countHitInteraction.amountOfHits >= throwKnife.knifesStorage.Length-1)
        {
            stageController.IncrementStage();
            //Debug.Log("Current Stage " + stageController.currentStage);
            //Mudar implementação de Die()
            Die();
        }
    }

    public virtual void Die()
    {
        countHitInteraction.RestartHits();
        gameObject.SetActive(false);
    }
}
