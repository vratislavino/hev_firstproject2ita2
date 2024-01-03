using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateManager : MonoBehaviour
{
    State currentState;

    void Start()
    {
        var player = FindObjectsOfType<Symbol>().ToList().First(s => s.IsPlayer);

        currentState = new IdleState(player, GetComponent<Symbol>());
        currentState.InitState();
    }

    void Update()
    {
        currentState.Update();
        var newState = currentState.TryToGetNewState();
        if (newState != null) {
            currentState = newState;
            currentState.InitState();
        }
    }
}
