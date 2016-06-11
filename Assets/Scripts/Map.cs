using System.Collections.Generic;

public class Map
{
    public Map()
    {
        layers = new List<Layer>();
    }

    public List<Layer> layers;
}

public class Layer
{
    public Layer()
    {
        dataPoints = new List<DataPoint>();
    }

    public List<DataPoint> dataPoints;
}

public class DataPoint
{
    public DataPoint(int x, int z, int intensity)
    {
        this.x = x;
        this.z = z;
        this.intensity = intensity;
    }

    public int x;
    public int z;
    public int intensity;
}