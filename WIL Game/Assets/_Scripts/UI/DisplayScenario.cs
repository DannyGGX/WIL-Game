using UnityEngine;
using TMPro;

public class DisplayScenario : MonoBehaviour
{
    [SerializeField] private GameObject scenarioCard;
    [SerializeField] private TextMeshProUGUI scenarioText;
    [SerializeField] private TextMeshProUGUI controversialPointsText;
    [SerializeField] private TextMeshProUGUI cleanPointsText;
    
    public void Display(Scenario scenario)
    {
        scenarioCard.SetActive(true);
        scenarioText.text = scenario.Text;
        cleanPointsText.text = scenario.CleanPoints.ToString();
        controversialPointsText.text = scenario.ControversialPoints.ToString();
    }

    public void Hide()
    {
        scenarioCard.SetActive(false);
    }
    
    private void Awake()
    {
        Hide();
    }
}