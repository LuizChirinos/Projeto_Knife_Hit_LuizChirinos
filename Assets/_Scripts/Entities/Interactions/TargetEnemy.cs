using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointGiverInteraction))]
public class TargetEnemy : MonoBehaviour
{
    private PointGiverInteraction pointGiverInteraction;
    public ThrowKnife throwKnife;

    private void Start()
    {
        pointGiverInteraction = GetComponent<PointGiverInteraction>();
        pointGiverInteraction.interactionEvent += CheckHits;
    }

    public void CheckHits(Collider2D col)
    {
        if (pointGiverInteraction.amountOfHits >= throwKnife.knifesStorage.Length-1)
        {
            Debug.Log("YOU WIN DUDE!");
        }
    }
}
