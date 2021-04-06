using System;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PathCreator))]
public class GeneratePath : MonoBehaviour {
    
    private static int pathPointsSize = 40; 
    public int pathIndex;
   
    private float startZ = 0f;
    private static float deltaZ = 1f;
    private float scaleFactor = 3;
    private float cutter = 5f;

    private Evaluator functionEvaluator = new Evaluator("0.6 * x - 3");

    private RoadMeshCreator roadMeshCreator;

    public void createRoad(int index)
    {
        pathIndex = index;
        roadMeshCreator = GetComponent<RoadMeshCreator>();
        makePath(index);
    }

    public static float pathZLength()
    {
        return deltaZ * pathPointsSize;
    }
    
    public  float EndZ()
    {
        return startZ + pathZLength()*(pathIndex+1);
    }

    private float ScaledValue(float x)
    {
        return functionEvaluator.Evaluate(x / scaleFactor) * scaleFactor;
    }

    private void makePath(int pathIndex)
    {
        Transform[] points = new Transform[pathPointsSize+1];
        for (int i = 0; i < pathPointsSize+1; i++)
        {
            float z_i = startZ + i * deltaZ + pathIndex * pathZLength();
            points[i] = new GameObject().transform;
            points[i].position = new Vector3(0,ScaledValue(z_i), z_i);
        }
        BezierPath bezierPath = new BezierPath (points, false, PathSpace.xyz);
        //bezierPath.GlobalNormalsAngle = 90f;
        GetComponent<PathCreator>().bezierPath = bezierPath;
        roadMeshCreator.TriggerUpdate();
    }
}
