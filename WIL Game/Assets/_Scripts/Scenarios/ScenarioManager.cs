using System;
using Unity.Netcode;
using UnityEngine;

public class ScenarioManager : NetworkSingleton<ScenarioManager>
{
    private Scenarios scenarios;
    private DrawScenarioCard cardDrawer;
    private Scenario currentScenario;
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
        throw new NotImplementedException();
    }
    
    public void DrawScenario()
    {
        int cardId = cardDrawer.DrawCard();
        currentScenario = scenarios.GetScenario(cardId);
    }
    
    
    
}