using UnityEngine;

public class LeChoiceSystem : MonoBehaviour
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
        WeBeChoosing = "Farm";
    }
    public void ChooseForestry()
    {
        WeBeChoosing = "Forestry";
        Debug.Log(WeBeChoosing);
    }
    public void ChooseSaw()
    {
        WeBeChoosing = "Saw";
    }
    public void ChooseWorkshop()
    {
        WeBeChoosing = "Workshop";
    }
    public void ChooseMine()
    {
        WeBeChoosing = "Mine";
    }
    public void ChooseWell()
    {
        WeBeChoosing = "Well";
    }
    public void ChooseSmelter()
    {
        WeBeChoosing = "Smelter";
    }
    public void ChooseChapel()
    {
        WeBeChoosing = "Chapel";
    }
    public void ChooseSchool()
    {
        WeBeChoosing = "School";
    }
}
