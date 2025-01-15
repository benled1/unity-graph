using System;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    [SerializeField, Range(10,200)]
    int resolution = 10;
    [SerializeField]
    FunctionLibrary.FunctionName function;
    float[] domain = {-3, 3};
    float baseUnit => Math.Abs(domain[1]-domain[0])/resolution;
    float pointShift => baseUnit*0.5f;
    Transform[,] points;


    void Awake()
    {
        float x = domain[0];
        float z = domain[0];

        Vector3 scale = Vector3.one * baseUnit;
        points = new Transform[resolution, resolution];

        for (int i=0; i<resolution; i++)
        {
            float zShift = baseUnit * i;
            for (int j=0; j<resolution; j++)
            {   
                Transform currPoint = Instantiate<Transform>(pointPrefab);
                currPoint.SetParent(this.transform, false);
                currPoint.localScale = scale;
                Vector3 oldPosition = currPoint.localPosition;
                oldPosition.x = x + (baseUnit*j) + pointShift;
                oldPosition.z = z + zShift;
                currPoint.localPosition = oldPosition;
                points[i,j] = currPoint;
            }
        }
    }

    void Update() 
    {
        FunctionLibrary.Function f = FunctionLibrary.getFunction(function);
        Debug.Log(points.GetLength(0));
        for (int i=0;i<points.GetLength(0);i++)
        {
            for (int j=0;j<points.GetLength(1);j++)
            {
                Transform currPoint = points[i,j];
                Vector3 oldPosition = currPoint.localPosition;
                oldPosition.y = f(currPoint.position.x, currPoint.position.z, Time.time);
                currPoint.localPosition = oldPosition;
            }
        }
    }
}
