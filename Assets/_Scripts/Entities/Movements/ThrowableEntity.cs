using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableEntity : Entity
{
    public Vector3 direction = Vector3.up;
    public bool interacted = false;
    public delegate void OnHit();
    public OnHit ontargetHit = delegate { };
    private GameObject managerGO;

    public override void Start()
    {
        base.Start();
        managerGO = GameObject.Find("Manager");
    }

    public override void Move()
    {
        base.Move();

        if (!interacted)
        {
            interacted = true;
            rb.velocity = direction.normalized * speed;
        }
        else
        {
            Debug.Log(gameObject.name + " has already been thrown");
        }
    }

    public void RestartInteraction()
    {
        gameObject.layer = 9;
        transform.parent = managerGO.transform;

        StickyInteraction sticky = GetComponent<StickyInteraction>();
        sticky.hasInteracted = false;

        interacted = false;
        ToggleKinematic(false);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
