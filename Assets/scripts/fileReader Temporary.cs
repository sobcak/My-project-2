using UnityEngine;
using System.IO;
using System.Linq;

public class fileReaderTemporary
{
    public static int MappingWidth = 50;
    public static int MappingHeight = 50;
    static char CurrentData = 'P';
    static char[,] Cords;
    public static void LoadMapsIntoMemory()
    {
        TextAsset mapFile = Resources.Load<TextAsset>("map");
        string[] lines = mapFile.text.Trim().Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None);
        Cords = new char[MappingWidth, MappingHeight];

        for (int y = 0; y < MappingHeight; y++)
        {
            string line = lines[y];
            for (int x = 0; x < MappingWidth; x++)
            {
                char currentData = line[x];
                Cords[x, y] = currentData;
            }
        }
    }
    public static char Coordinance(Vector2 MapCords)
    {
        int y = (int)MapCords.y;
        int x = (int)MapCords.x;


        return Cords[y, x];
    }
}
