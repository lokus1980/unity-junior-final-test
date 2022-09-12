using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnoCube : Cube
{
    protected override void ChangeMaterialIfTime()
    {
        MaterialIndex = (MaterialIndex + 1) % materials.Length;
        meshRenderer.material = materials[MaterialIndex];
    }
}
