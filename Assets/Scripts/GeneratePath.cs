using System;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;
using UnityEngine.Serialization;

//This class is calculating points for a section of path and creating path with them
[RequireComponent(typeof(PathCreator))]
public class GeneratePath : MonoBehaviour {
    
    private const float ScaleFactor = 3;
    private const float Cutter = 5f;
    public int index;

    private Evaluator _functionEvaluator = new Evaluator("0.1 * (x^2)");

    private RoadMeshCreator _roadMeshCreator;

    public void createRoad(int index)
    {
        this.index = index;
        _roadMeshCreator = GetComponent<RoadMeshCreator>();
        makePath();
    }

    private float ScaledValue(float x)
    {
        return _functionEvaluator.Evaluate(x / ScaleFactor) * ScaleFactor;
    }

    private Transform[] GeneratePathPoints()
    {
        int n = PathSection.pointsSize;
        Transform[] points = new Transform[n+1];
        for (int i = 0; i < n+1; i++)
        {
            float z_i = PathSection.ConvertToZPos(index, i);
            points[i] = new GameObject().transform;
            points[i].position = new Vector3(0,ScaledValue(z_i), z_i);
        }
        return points;
    }

    private void makePath()
    {
        
        BezierPath bezierPath = new BezierPath (GeneratePathPoints(), false, PathSpace.xyz);
        //bezierPath.GlobalNormalsAngle = 90f;
        GetComponent<PathCreator>().bezierPath = bezierPath;
        _roadMeshCreator.TriggerUpdate();
    }
}
