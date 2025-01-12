using System;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    [SerializeField]
    int resolution = 10;
    float[] domain = {-1, 1};
    float baseUnit => Math.Abs(domain[1]-domain[0])/resolution;
    float pointShift => baseUnit*0.5f;
    Transform[] points;

    void Awake()
    {
        float x = domain[0];
        Vector3 scale = Vector3.one * baseUnit;
        points = new Transform[resolution];

        for (int i=0; i<resolution; i++)
        {
            Transform currPoint = Instantiate<Transform>(pointPrefab);
            currPoint.SetParent(this.transform, false);
            currPoint.localScale = scale;
            Vector3 oldPosition = currPoint.localPosition;
            oldPosition.x = x + pointShift;
            currPoint.localPosition = oldPosition;
            x = x + baseUnit;
            points[i] = currPoint;
        }
    }

    void Update() 
    {
        for (int i=0;i<points.Length;i++)
        {
            Transform currPoint = points[i];
            Vector3 oldPosition = currPoint.localPosition;
            oldPosition.y = Mathf.Sin(Mathf.PI * (currPoint.position.x + Time.time));
            currPoint.localPosition = oldPosition;
        }
    }

    private float xPlusOne(float x)
    {
        return x + baseUnit;
    }

    private float xSquared(float x)
    {
        return x * x; 
    }

    private float xCubed(float x)
    {
        return x * x * x;
    }
}
