using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material[] materials;
    public float rotationSpeedX = 1.0f;
    public int colourChangeIntervalInSeconds = 2;

    private TimeSpan colourChangeInterval;
    private DateTime lastColourChangeTime;
    private int materialIndex = -1;
    private MeshRenderer meshRenderer;

    void Start()
    {
        colourChangeInterval = new TimeSpan(0, 0, colourChangeIntervalInSeconds);
        lastColourChangeTime = DateTime.Now;
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime * rotationSpeedX, 0.0f, 0.0f);

        if (DateTime.Now - lastColourChangeTime >= colourChangeInterval)
        {
            lastColourChangeTime = DateTime.Now;

            materialIndex = (materialIndex + 1) % materials.Length;
            meshRenderer.material = materials[materialIndex];
        }
    }
}
