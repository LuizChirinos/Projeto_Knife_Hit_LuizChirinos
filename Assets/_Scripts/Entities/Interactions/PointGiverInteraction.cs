using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGiverInteraction : InteractionBehaviour
{
    public int pointsAmount = 1;
    public int amountOfHits;
    public override void Start()
    {
        base.Start();
        interactionEvent += GivePoints;
    }

    public void GivePoints(Collider2D col)
    {
        ThrowableEntity throwable = col.GetComponent<ThrowableEntity>();

        ScoreController.score += pointsAmount;
        amountOfHits++;

        throwable.ontargetHit();
        //Debug.Log("Interacted with " + col.name);
    }
}
