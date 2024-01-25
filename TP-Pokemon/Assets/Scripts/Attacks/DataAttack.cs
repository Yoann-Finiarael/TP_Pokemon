using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AttackScriptableObject", order = 2)]
public class DataAttack : ScriptableObject
{
    public string Name;

    public int BasePower;
    public Types Type;

    public bool DoesDamage;
    public bool DoesHeal;

    public bool TargetSelf;
}
