using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TypeMatchup
{
    [SerializeField] private Types defendingType;
    [SerializeField] private float damageMultiplier;

    public Types GetDefendingType() { return defendingType; }
    public float GetDamageMultiplier() { return damageMultiplier; } 
}
