using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyInteraction : InteractionBehaviour
{
    public override void Start()
    {
        base.Start();
        interactionEvent += Stick;
    }

    private void Stick(Collider2D col)
    {
        transform.parent = col.transform;
        transform.gameObject.layer = 8;
    }
}
