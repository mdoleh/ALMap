using System.IO;
using UnityEditor;
using UnityEngine;

namespace Menus
{
    public class ReadFile : MonoBehaviour
    {
        public GenerateGraph generator;

        public void LoadFile()
        {
            var directoryPath = EditorUtility.OpenFolderPanel("Select folder with AL Map files", "", "");
            var files = Directory.GetFiles(directoryPath);
            generator.Generate(generateMap(files));
        }

        private Map generateMap(string[] files)
        {
            var map = new Map();
            foreach (var file in files)
            {
                var layer = new Layer();
                var contents = File.ReadAllLines(file);
                for (var i = 0; i < contents.Length; ++i)
                {
                    var points = contents[i].Split('\t');
                    for (var j = 0; j < points.Length; ++j)
                    {
                        var intensity = int.Parse(points[j]);
                        if (intensity > 0)
                            layer.dataPoints.Add(new DataPoint(j, i, int.Parse(points[j])));
                    }
                }
                map.layers.Add(layer);
            }
            return map;
        }
    }
}