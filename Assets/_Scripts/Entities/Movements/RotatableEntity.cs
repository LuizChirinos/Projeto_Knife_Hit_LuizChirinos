using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableEntity : Entity
{
    public override void Move()
    {
        base.Move();

        transform.Rotate(Vector3.forward * speed);
    }
    private void Update()
    {
        Move();
    }
}
