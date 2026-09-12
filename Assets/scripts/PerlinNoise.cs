using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class PerlinNoise : MonoBehaviour
{
    public Button button;
    int width  = 50;
    int height = 50;
    float scale = 1f;

    const string ramp = "WSP";

    void Start()
    {
        button.onClick.AddListener(Perlin);
    }

    void Perlin()
    {
        string path = Path.Combine(Application.dataPath, "Resources/map.txt");
        var sb = new StringBuilder();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float val = Mathf.PerlinNoise(x * scale, y * scale);
                int idx = Mathf.Clamp(
                    (int)(val * (ramp.Length - 1)), 0, ramp.Length - 1);
                sb.Append(ramp[idx]);
            }
            sb.AppendLine();
        }

        File.WriteAllText(path, sb.ToString());
        Debug.Log($"Wrote to {path}");
    }
}
