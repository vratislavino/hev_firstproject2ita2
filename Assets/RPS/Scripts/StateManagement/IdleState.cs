using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    Vector3 targetPoint;

    public IdleState(Symbol player, Symbol enemy) : base(player, enemy) {
    }

    public override void InitState() {
        GenerateTarget();
    }

    private void GenerateTarget() {
        targetPoint = new Vector3(Random.Range(0f, 100f), 60f, Random.Range(0, 100f));
        if(Physics.Raycast(targetPoint, Vector3.down, out RaycastHit hit, 61f)) {
            targetPoint = hit.point;
        }
    }

    public override void Update() {
        agent.SetDestination(targetPoint);
        if (Vector3.Distance(targetPoint, agent.transform.position) < 2f) {
            GenerateTarget();
        } 
    }

    public override State TryToGetNewState() {
        if(Vector3.Distance(playerSymbol.transform.position, agent.transform.position) < 15) {

            var wouldWin = enemySymbol.CurrentSymbol.Beats(playerSymbol.CurrentSymbol);
            if(wouldWin.HasValue) {
                if(wouldWin.Value) {
                    return new AttackState(playerSymbol, enemySymbol);
                } else {
                    return new FleeState(playerSymbol, enemySymbol);
                }
            } else {
                return null;
            }
        } else {
            return null;
        }
    }

    
}
