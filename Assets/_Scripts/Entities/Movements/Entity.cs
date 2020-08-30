using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    public float speed = 1f;

    protected Rigidbody2D rb;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Move()
    {
        //Debug.Log(gameObject.name + " is moving!");
    }

    public void ToggleKinematic(bool activation)
    {
        rb.isKinematic = activation;
        //Debug.Log(rb.isKinematic);
    }
}
