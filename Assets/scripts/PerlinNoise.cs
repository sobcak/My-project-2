using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class PerlinNoise : MonoBehaviour
{
    public Button button;
    int width  = 50;
    int height = 50;
    float scale = 0.05f;

    const string ramp = "PWPS";

    void Start()
    {
        Perlin();
    }

    void Perlin()
    {
        string path = Path.Combine(Application.dataPath, "Resources/map.txt");
        var sb = new StringBuilder();

        float offsetX = Random.Range(0f, 9999f);
        float offsetY = Random.Range(0f, 9999f);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float val = Mathf.PerlinNoise((x + offsetX) * scale, (y + offsetY) * scale);
                int idx = Mathf.Clamp((int)(val * ramp.Length), 0, ramp.Length - 1);
                sb.Append(ramp[idx]);
            }
            sb.AppendLine();
        }

        File.WriteAllText(path, sb.ToString());
        Debug.Log($"Wrote to {path}");
        
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}