using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    SymbolEnum symbol;

    public SymbolEnum CurrentSymbol => symbol;

    [SerializeField]
    private bool isPlayer;

    public bool IsPlayer => isPlayer;

    [SerializeField]
    private MeshRenderer quad;

    [SerializeField]
    private List<Material> materials;

    void Start() {
        
        ChangeSymbol(GetRandomSymbol());

        if (isPlayer) {
            StartCoroutine(GenerateRandomSymbolRoutine());
        }
    }

    IEnumerator GenerateRandomSymbolRoutine() {
        while (true) {
            yield return new WaitForSeconds(5);
            ChangeSymbol(GetRandomSymbol());
        }
    }

    private SymbolEnum GetRandomSymbol() {
        return (SymbolEnum) Random.Range(0, 3);
    }

    private void ChangeSymbol(SymbolEnum newSymbol) {
        symbol = newSymbol;
        quad.material = materials[(int) symbol];
    }

    private void OnCollisionEnter(Collision collision) {
        if (!isPlayer) return;

        var enemySymbol = collision.gameObject.GetComponent<Symbol>();

        if (enemySymbol == null) return;

        var enemy = enemySymbol.symbol;

        Debug.Log(symbol + " : " + enemy);

        var res = symbol.Beats(enemy);
        if (res.HasValue && res.Value == true) {
            Destroy(collision.gameObject);
        }
    }
}

public enum SymbolEnum
{
    Rock,
    Paper,
    Scissors
}
