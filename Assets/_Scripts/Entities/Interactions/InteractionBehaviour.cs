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

    public string targetTag;

    public virtual void Start()
    {
        hasInteracted = false;
        entity = GetComponent<Entity>();
    }
    public virtual void Interact(Collider2D col)
    {
        if (!hasInteracted)
        {
            if (!repeatInteraction)
                hasInteracted = true;

            interactionEvent(col);

            if (disableMovement)
            {
                //entity.enabled = false;
                //entity.ToggleKinematic(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Interact(collision.collider);
            //Debug.Log(gameObject.name + " interacted with " + collision.transform.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Interact(other);
            //Debug.Log(gameObject.name + " interacted with " + other.name);
        }
    }
}
