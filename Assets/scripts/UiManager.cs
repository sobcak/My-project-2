using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private DataStorage dataStorage;
    [SerializeField] private TextMeshProUGUI NOHtext;
    [SerializeField] private TextMeshProUGUI Foodtext;
    [SerializeField] private TextMeshProUGUI Housingtext;
    [SerializeField] private TextMeshProUGUI Workerstext;
    [SerializeField] private TextMeshProUGUI Stonetext;
    [SerializeField] private TextMeshProUGUI Woodtext;
    [SerializeField] private TextMeshProUGUI Bricktext;
    [SerializeField] private TextMeshProUGUI Tooltext;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dataStorage = FindFirstObjectByType<DataStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        NOHtext.text = $"Population: {dataStorage.NumberOfHumans.ToString()}";
        Foodtext.text = $"Food: {dataStorage.AvailableFood.ToString()}";
        Housingtext.text = $"Housing: {dataStorage.AvailableHousing.ToString()}";
        Workerstext.text = $"Workers: {dataStorage.Workers.ToString()}";
        Stonetext.text = $"Stone: {dataStorage.Stone.ToString()}";
        Woodtext.text = $"Wood: {dataStorage.Wood.ToString()}";
        Bricktext.text = $"Bricks: {dataStorage.brick.ToString()}";
        Tooltext.text = $"Tools: {dataStorage.Tools.ToString()}";

    }
}
