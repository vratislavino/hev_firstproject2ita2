using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    SymbolEnum symbol;

    [SerializeField]
    private bool isPlayer;

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
            yield return new WaitForSeconds(1);
            ChangeSymbol(GetRandomSymbol());
        }
    }

    private SymbolEnum GetRandomSymbol() {
        return (SymbolEnum)Random.Range(0, 3);
    }

    private void ChangeSymbol(SymbolEnum newSymbol) {
        symbol = newSymbol;
        quad.material = materials[(int) symbol];
    }
}

public enum SymbolEnum
{
    Rock,
    Paper,
    Scissors
}
