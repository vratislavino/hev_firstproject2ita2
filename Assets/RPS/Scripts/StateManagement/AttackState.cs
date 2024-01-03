using UnityEngine;

public class AttackState : State
{
    public AttackState(Symbol player, Symbol enemy) : base(player, enemy) {
    }

    public override void InitState() { }

    public override void Update() {
        agent.SetDestination(playerSymbol.transform.position);
    }

    public override State TryToGetNewState() {
        if (Vector3.Distance(playerSymbol.transform.position, agent.transform.position) > 15)
            return new IdleState(playerSymbol, enemySymbol);

        var wouldWin = enemySymbol.CurrentSymbol.Beats(playerSymbol.CurrentSymbol);
        if (wouldWin.HasValue) {
            if (wouldWin.Value) {
                return null;
            } else {
                return new FleeState(playerSymbol, enemySymbol);
            }
        } else {
            return new IdleState(playerSymbol, enemySymbol);
        }
    }
}
