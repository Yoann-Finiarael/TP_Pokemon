using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PokemonScriptableObject", order = 1)]
public class DataPokemon : ScriptableObject
{
    public string Name;

    public Types Type;

    public int PV;
    public int ATK;
    public int DEF;
    public int VIT;

    public DataAttack[] Datas;
}
