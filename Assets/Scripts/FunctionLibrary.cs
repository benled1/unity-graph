using System;
using System.Net.NetworkInformation;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public static class FunctionLibrary
{
    public static float Wave(float x, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }

    public static float MultiWave(float x, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (x+t))*0.5f;
        return y*(2f/3f);
    }

    public static float Ripple (float x, float t) {
		float d = Mathf.Abs(x);
        float y = Mathf.Sin(Mathf.PI * (4f * d - t));
		return y / (1f + 10f * d);
	}
}