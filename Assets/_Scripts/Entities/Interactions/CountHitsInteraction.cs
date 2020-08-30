using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountHitsInteraction : InteractionBehaviour
{
    public int pointsAmount = 1;
    public int amountOfHits;

    public bool isMoney = false;
    public bool deactivateOnInteraction;

    public override void Start()
    {
        base.Start();
        interactionEvent += GivePoints;
    }

    public void GivePoints(Collider2D col)
    {
        ThrowableEntity throwable = col.GetComponent<ThrowableEntity>();

        if (!isMoney)
            ScoreController.ModifyScore(pointsAmount);
        else
            MoneyController.ModifyMoney(pointsAmount * 10);

        amountOfHits++;

        throwable.ontargetHit();
        //Debug.Log("Interacted with " + col.name);

        if (deactivateOnInteraction)
            gameObject.SetActive(false);
    }
}
