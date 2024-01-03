using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent agent;

    protected Symbol enemySymbol;
    protected Symbol playerSymbol;

    public State(Symbol player, Symbol enemy) {
        enemySymbol = enemy;
        playerSymbol = player;
        agent = enemySymbol.GetComponent<NavMeshAgent>();
    }

    public abstract void InitState();

    public abstract void Update();

    public abstract State TryToGetNewState();

}
