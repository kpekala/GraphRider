using System;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;

[RequireComponent(typeof(PathCreator))]
public class GeneratePath : MonoBehaviour {
    private static float deltaZ = 1f;
    private float factor = 3;
    private float cutter = 5f;
    private static int pathPointsSize = 40;
    public int index;
    private float startZ = 0f;

    private RoadMeshCreator roadMeshCreator;
    void Start ()
    {
        
    }

    public void createRoad(int index)
    {
        this.index = index;
        roadMeshCreator = GetComponent<RoadMeshCreator>();
        makePath(index, 0f);
    }

    public static float pathZLength()
    {
        return deltaZ * pathPointsSize;
    }
    
    public  float EndZ()
    {
        return startZ + pathZLength()*(index+1);
    }

    private void makePath(int pathIndex, float startZ)
    {
        this.startZ = startZ;
        Transform[] points = new Transform[pathPointsSize+1];
        for (int i = 0; i < pathPointsSize+1; i++)
        {
            float z_i = startZ + i * deltaZ + pathIndex * pathZLength();
            points[i] = new GameObject().transform;
            points[i].position = new Vector3(0, (float)(Math.Log(z_i/factor) * Math.Cos(Math.Sin(z_i/factor)))*factor/cutter, z_i);
            //points[i].position = new Vector3(0, (float)eval*factor, z_i);
            //points[i].position = new Vector3(0, (float) 1/z_i, z_i);
        }
        BezierPath bezierPath = new BezierPath (points, false, PathSpace.xyz);
        //bezierPath.GlobalNormalsAngle = 90f;
        GetComponent<PathCreator> ().bezierPath = bezierPath;
        roadMeshCreator.TriggerUpdate();
    }
}
