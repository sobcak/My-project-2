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
        EvolutionPanel.SetActive(false);
        ExtractionPanel.SetActive(false);
        ProductionPanel.SetActive(false);
    }
    public void ShowEvolutionPanel()
    {
        HousingPanel.SetActive(false);
        EvolutionPanel.SetActive(true);
        ExtractionPanel.SetActive(false);
        ProductionPanel.SetActive(false);
    }
    public void ShowExtractionPanel()
    {
        HousingPanel.SetActive(false);
        EvolutionPanel.SetActive(false);
        ExtractionPanel.SetActive(true);
        ProductionPanel.SetActive(false);
    }
    public void ShowProductionPanel()
    {
        HousingPanel.SetActive(false);
        EvolutionPanel.SetActive(false);
        ExtractionPanel.SetActive(false);
        ProductionPanel.SetActive(true);
    }
}
