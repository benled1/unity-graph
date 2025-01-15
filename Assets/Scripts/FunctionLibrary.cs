using System;
using System.Net.NetworkInformation;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public static class FunctionLibrary
{
    public delegate float Function(float x, float z, float t);

    public enum FunctionName {Wave, MultiWave, Ripple};
    private static Function[] functions = {Wave, MultiWave, Ripple};

    public static Function getFunction(FunctionName name)
    {
        return functions[(int)name];
    }
    public static float Wave(float x, float z, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }

    public static float MultiWave(float x, float z, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (x+t))*0.5f;
        return y*(2f/3f);
    }

    public static float Ripple (float x, float z, float t) {
		float d = Mathf.Abs(x);
        float y = Mathf.Sin(Mathf.PI * (4f * d - t));
		return y / (1f + 10f * d);
	}

    public static float MultiWave2(float x, float z, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(4f * Mathf.PI * (x+t))*0.5f;
        return y*(2f/3f);
    }
}