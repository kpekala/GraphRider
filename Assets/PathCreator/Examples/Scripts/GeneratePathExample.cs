using System;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;

[RequireComponent(typeof(PathCreator))]
public class GeneratePathExample : MonoBehaviour {
    private float deltaZ = 1f;
    private float factor = 3;

    private RoadMeshCreator roadMeshCreator;
    void Start ()
    {
        roadMeshCreator = GetComponent<RoadMeshCreator>();
        makePath(0f);
    }

    private void makePath(float startZ)
    {
        int pathPointsSize = 40;
        Transform[] points = new Transform[pathPointsSize];
        for (int i = 0; i < pathPointsSize; i++)
        {
            float z_i = startZ + i * deltaZ;
            points[i] = new GameObject().transform;
            points[i].position = new Vector3(0, (float)Math.Sin(z_i/factor)*factor, z_i);
        }
        BezierPath bezierPath = new BezierPath (points, false, PathSpace.xyz);
        //bezierPath.GlobalNormalsAngle = 90f;
        GetComponent<PathCreator> ().bezierPath = bezierPath;
        roadMeshCreator.TriggerUpdate();
    }
}
