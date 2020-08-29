using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]
public class InteractionBehaviour : MonoBehaviour
{
    public bool repeatInteraction = false;
    public bool hasInteracted = false;
    public bool disableMovement = false;

    public delegate void DispatchInteraction(Collider2D col);
    public DispatchInteraction interactionEvent = delegate { };

    private Entity entity;

    public virtual void Start()
    {
        hasInteracted = false;
        entity = GetComponent<Entity>();
    }
    public virtual void Interact(Collider2D col)
    {
        if (!hasInteracted)
        {
            hasInteracted = true;

            interactionEvent(col);

            if (disableMovement)
            {
                entity.enabled = false;
                entity.ToggleKinematic(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Interact(collision.collider);
        //Debug.Log(gameObject.name + " interacted with " + collision.transform.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Interact(other);
        Debug.Log(gameObject.name + " interacted with " + other.name);
    }
}
