﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringObject : MonoBehaviour {

    public bool IsFlickering { get; set; }

    public Color flickeringColor;
    public AnimationCurve flickeringCurve;
    private Renderer meshRenderer;

    private float time = 0f;

    // Use this for initialization
    void Start () {
        IsFlickering = false;
        meshRenderer = GetComponent<Renderer>();
        meshRenderer.material.EnableKeyword("_EMISSION");
    }
	
	// Update is called once per frame
	void Update () {
        if (IsFlickering)
        {
            time += Time.deltaTime;
            Color color = Color.Lerp(Color.black, flickeringColor, flickeringCurve.Evaluate(time));
            meshRenderer.material.SetColor("_EmissionColor", color);
        }
        else
        {
            meshRenderer.material.SetColor("_EmissionColor", Color.black);
        }
	}
}
