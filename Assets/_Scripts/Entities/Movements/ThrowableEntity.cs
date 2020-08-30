using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableEntity : Entity
{
    public Vector3 direction = Vector3.up;
    public bool interacted = false;
    public delegate void OnHit();
    public OnHit ontargetHit = delegate { };

    public override void Move()
    {
        if (!interacted)
        {
            base.Move();

            interacted = true;
            rb.velocity = direction.normalized * speed;
        }
        else
        {
            Debug.Log(gameObject.name + " has already been thrown");
        }
    }
}
