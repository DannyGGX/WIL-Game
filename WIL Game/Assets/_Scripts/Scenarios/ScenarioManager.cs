using System;
using Unity.Netcode;
using UnityEngine;

public class ScenarioManager : NetworkSingleton<ScenarioManager>
{
    private Scenarios scenarios;
    private DrawScenarioCard cardDrawer;
    private Scenario currentScenario;
    private LoadExcel loadExcel;
    
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
        loadExcel = new LoadExcel();
        loadExcel.LoadScenarioData();
        scenarios = loadExcel.GetScenariosReference();
        
        //debug log all scenarios
        foreach (var scenario in scenarios.scenarios)
        {
            Debug.Log(scenario.Value.ToString());
        }
    }
    
    public void DrawScenario()
    {
        int cardId = cardDrawer.DrawCard();
        currentScenario = scenarios.GetScenario(cardId);
    }
    
    
    
}