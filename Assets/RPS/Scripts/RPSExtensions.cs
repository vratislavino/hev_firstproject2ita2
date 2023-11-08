using UnityEngine;

public static class RPSExtensions
{
    public static bool? Beats(this SymbolEnum first, SymbolEnum second) {
        if((first == SymbolEnum.Rock && second == SymbolEnum.Scissors) ||
            (first == SymbolEnum.Paper && second == SymbolEnum.Rock) ||
            (first == SymbolEnum.Scissors && second == SymbolEnum.Paper)) {
            return true;
        }

        if(first == second) {
            return null;
        }

        return false;
    
    }
}
