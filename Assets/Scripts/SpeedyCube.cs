using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyCube : Cube
{
    public float rotationSpeedY = 70.0f;

    SpeedyCube()
    {
        rotationSpeedX = 40.0f;
    }

    protected override void Rotate()
    {
        transform.Rotate(Time.deltaTime * rotationSpeedX, Time.deltaTime * rotationSpeedY, 0.0f);
    }
}

