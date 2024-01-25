using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TypeMatchups
{
    [SerializeField] private Types attackingType;
    [SerializeField] private TypeMatchup[] matchups;

    public Types GetAttackingType() { return attackingType; }

    public float GetMultiplier(Types _defendingType)
    {
        for (int i = 0; i < matchups.Length; i++)
        {
            if (matchups[i].GetDefendingType().Equals(_defendingType))
            {
                return matchups[i].GetDamageMultiplier();
            }
        }

        return 1;       //Neutral if not in database
    }
}
