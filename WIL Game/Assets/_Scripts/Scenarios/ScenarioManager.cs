using System;
using Unity.Netcode;
using UnityEngine;

public class ScenarioManager : NetworkSingleton<ScenarioManager>
{
    private Scenarios _scenarios;
    private DrawScenarioCard _cardDrawer;
    private Scenario _currentScenario;
    private ReadScenarioData _readScenarioData;
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsServer) return;
    }

    protected override void Awake()
    {
        base.Awake();
        GetScenariosFromCsvReader();
        _cardDrawer = new DrawScenarioCard(_scenarios);
    }
    
    // Get the scenarios from the CSV reader
    private void GetScenariosFromCsvReader()
    {
        _readScenarioData = new ReadScenarioData();
        _scenarios = _readScenarioData.GetScenarioData();
        _readScenarioData = null;
    }
    
    public void DrawScenario()
    {
        int cardId = _cardDrawer.DrawCard();
        _currentScenario = _scenarios.GetScenario(cardId);

        if (_cardDrawer.IsDrawCardsEmpty())
        {
            _cardDrawer.RefillDrawCards(_scenarios);
        }
    }
    
}