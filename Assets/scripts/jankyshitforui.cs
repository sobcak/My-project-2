using UnityEngine;

public class jankyshitforui : MonoBehaviour
{
    [SerializeField] private GameObject HousingPanel;
    [SerializeField] private GameObject EvolutionPanel;
    [SerializeField] private GameObject ExtractionPanel;
    [SerializeField] private GameObject ProductionPanel;
    public static bool IsOpen = false;
    public void ShowHousingPanel()
    {
        HousingPanel.SetActive(true);
    }
    public void ShowEvolutionPanel()
    {
        EvolutionPanel.SetActive(true);
    }
    public void ShowExtractionPanel()
    {
        ExtractionPanel.SetActive(true);
    }
    public void ShowProductionPanel()
    {
        ProductionPanel.SetActive(true);
    }
}
