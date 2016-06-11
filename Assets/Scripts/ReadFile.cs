using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Menus
{
    public class ReadFile : MonoBehaviour
    {
        public string FILE_NAME = "layer";
        public string FILE_TYPE = ".txt";
        public GenerateGraph generator;

        public void LoadFile()
        {
            var directoryPath = EditorUtility.OpenFolderPanel("Select folder with AL Map files", "", "");
            var files = Directory.GetFiles(directoryPath);
            generator.Generate(generateMap(files));
        }

        private Map generateMap(string[] files)
        {
            var sorted = sort(files);
            var map = new Map();
            foreach (var file in sorted)
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

        private List<string> sort(string[] unsorted)
        {
            var dictionary = new Dictionary<int, string>();
            foreach (var item in unsorted)
            {
                var number = findNumber(item);
                dictionary.Add(number, item);
            }
            var sorted = dictionary.OrderBy(x => x.Key);
            return sorted.ToList().ConvertAll(x => x.Value);
        }

        private int findNumber(string path)
        {
            var index = path.IndexOf(FILE_NAME);
            var fileName = path.Substring(index, path.Length - index);
            return int.Parse(fileName.Replace(FILE_NAME, "").Replace(FILE_TYPE, ""));
        }
    }
}