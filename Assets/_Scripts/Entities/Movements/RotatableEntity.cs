using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableEntity : Entity
{
    public float speedVariation = 2f;
    public float timerSpeed;
    public float timeToChange = 4f;
    public bool changeSpeed = true;

    public override void Start()
    {
        base.Start();
        timerSpeed = timeToChange;
    }
    public override void Move()
    {
        base.Move();

        transform.Rotate(Vector3.forward * speed);
    }
    public void Update()
    {
        Move();
        SpeedCycle();
    }

    private void ChangeSpeed(float modifier)
    {
        speed += modifier;
    }

    private void SpeedCycle()
    {
        speed = Mathf.Lerp(speed, targetSpeed, 0.1f);

        if (timerSpeed < 0)
        {
            targetSpeed = defaultSpeed + (int)Random.Range(-speedVariation, speedVariation);
            timerSpeed = timeToChange;
        }
        else
        {
            if (changeSpeed)
                timerSpeed -= Time.deltaTime;
        }
    }
}
