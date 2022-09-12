using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material[] materials;
    public float rotationSpeedX = 10.0f;
    public int colourChangeIntervalInSeconds = 2;

    private TimeSpan colourChangeInterval;
    private DateTime lastColourChangeTime;
    protected MeshRenderer meshRenderer;

    public int MaterialIndex
    {
        get; protected set;
    }

    public Cube()
    {
        MaterialIndex = -1;
    }

    protected virtual void Rotate()
    {
        transform.Rotate(Time.deltaTime * rotationSpeedX, 0.0f, 0.0f);
    }

    protected virtual void ChangeMaterialIfTime()
    {
        if (DateTime.Now - lastColourChangeTime >= colourChangeInterval)
        {
            lastColourChangeTime = DateTime.Now;

            MaterialIndex = (MaterialIndex + 1) % materials.Length;
            meshRenderer.material = materials[MaterialIndex];
        }
    }

    protected virtual void Initialize()
    {
        colourChangeInterval = new TimeSpan(0, 0, colourChangeIntervalInSeconds);
        lastColourChangeTime = DateTime.Now;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected virtual void Start()
    {
        Initialize();
    }

    protected virtual void Update()
    {
        Rotate();
        ChangeMaterialIfTime();
    }
}
