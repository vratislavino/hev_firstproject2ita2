using UnityEngine;

public class FleeState : State
{
    public FleeState(Symbol player, Symbol enemy) : base(player, enemy) {
    }

    public override void InitState() {
    }

    public override void Update() {
        var dir = playerSymbol.transform.position - enemySymbol.transform.position;
        agent.SetDestination(enemySymbol.transform.position - dir);
    }

    public override State TryToGetNewState() {
        if (Vector3.Distance(playerSymbol.transform.position, agent.transform.position) > 15)
            return new IdleState(playerSymbol, enemySymbol);

        var wouldWin = enemySymbol.CurrentSymbol.Beats(playerSymbol.CurrentSymbol);
        if (wouldWin.HasValue) {
            if (wouldWin.Value) {
                return new AttackState(playerSymbol, enemySymbol);
            } else {
                return null;
            }
        } else {
            return new IdleState(playerSymbol, enemySymbol);
        }
    }
}
