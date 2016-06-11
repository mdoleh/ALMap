using UnityEngine;
using System.Collections;

public class GenerateGraph : MonoBehaviour
{
    public GameObject dataPointPrefab;

    public void Generate(Map map)
    {
        for (var i = 0; i < map.layers.Count; ++i)
        {
            foreach (var dataPoint in map.layers[i].dataPoints)
            {
                var point = Instantiate(dataPointPrefab);
                point.transform.position = new Vector3(dataPoint.x, i, dataPoint.z);
            }
        }
    }
}
