using UnityEngine;
using System.Collections;

public class ClearScreen : MonoBehaviour
{
    public void ClearAll()
    {
        var objects = GameObject.FindGameObjectsWithTag("DataPoint");
        foreach (var item in objects)
        {
            Destroy(item);
        }
    }
}
