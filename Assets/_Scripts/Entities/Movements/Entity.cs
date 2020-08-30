using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    public float defaultSpeed = 0.5f;
    protected float targetSpeed;
    protected float speed = 1f;

    protected Rigidbody2D rb;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;
        targetSpeed = speed;
    }

    public virtual void Move()
    {
        Debug.Log(GameStatus.gameActive);

        //Debug.Log(gameObject.name + " is moving!");
    }

    public void ToggleKinematic(bool activation)
    {
        rb.isKinematic = activation;
        //Debug.Log(rb.isKinematic);
    }
}
