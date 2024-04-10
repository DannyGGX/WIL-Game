using System;
using Unity.Netcode;
using UnityEngine;

public class ScenarioManager : NetworkSingleton<ScenarioManager>
{
    private Scenarios scenarios;
    private DrawScenarioCard cardDrawer;
    private Scenario currentScenario;
    private ReadScenarioData _readScenarioData;
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsServer) return;
    }

    protected override void Awake()
    {
        base.Awake();
        GetScenariosFromCSVReader();
        cardDrawer = new DrawScenarioCard(scenarios);
    }
    
    // Get the scenarios from the CSV reader
    private void GetScenariosFromCSVReader()
    {
        _readScenarioData = new ReadScenarioData();
        _readScenarioData.LoadScenarioData();
        scenarios = _readScenarioData.GetScenariosReference();
        
        //debug log all scenarios
        foreach (var scenario in scenarios.scenarios)
        {
            // Debug each individual variable in scenario in the same debug message
            Debug.Log(scenario.Value.Id + " " + scenario.Value.Text + " " + scenario.Value.Difficulty + " " + scenario.Value.ControversialPoints + " " + scenario.Value.CleanPoints);
        }
    }
    
    public void DrawScenario()
    {
        int cardId = cardDrawer.DrawCard();
        currentScenario = scenarios.GetScenario(cardId);
    }
    
}