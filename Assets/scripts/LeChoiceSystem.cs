using UnityEngine;

public class LeChoiceSystem
{
    public static string WeBeChoosing = "Nothing";
    public enum YourBuildChoise
    {
        Storage,
        Housing,
        Farming,
        Forestry,
        Saw,
        Workshop
    }
    public static void ChooseStorage()
    {
        WeBeChoosing = "Storage";
    }
    public void ChooseHousing()
    {
        WeBeChoosing = "Housing";
    }
    public void ChooseFamring()
    {
        WeBeChoosing = "Farming";
    }
    public void ChooseForestry()
    {
        WeBeChoosing = "Forestry";
    }
    public void ChooseSaw()
    {
        WeBeChoosing = "Saw";
    }
    public void ChooseWorkshop()
    {
        WeBeChoosing = "Workshop";
    }
}
