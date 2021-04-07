//This class holds information about path section
public class PathSection
{
    private static float startZ = 0f;
    public static float deltaZ = 1f;
    public static int pointsSize = 40;

    public static float pathZLength()
    {
        return deltaZ * pointsSize;
    }
    
    public static float EndZ(int index)
    {
        return startZ + pathZLength()*(index+1);
    }

    public static float ConvertToZPos(int pathIndex, int pointIndex)
    {
        return startZ + pointIndex * deltaZ + pathIndex * pathZLength();
    }
}
