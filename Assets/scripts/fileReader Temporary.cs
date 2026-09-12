using UnityEngine;
using System.IO;
using System.Linq;

public class fileReaderTemporary
{
    public int MappingWidth = 50;
    public int MappingHeight = 50;
    public void LoadMapsIntoMemory()
    {
        for (int x = MappingWidth; x >= 0; x--)
        {
            for (int y = MappingHeight; y >= 0; y--)
            {
                string line = File.ReadLines("Jsynu/map").Skip(y).Take(1).First();
            }
        }
    }
    public string Coordinance(Vector2 MapCords)
    {
        


        return "";
    }
}
