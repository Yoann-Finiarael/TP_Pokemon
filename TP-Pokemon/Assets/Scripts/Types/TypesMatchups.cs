using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class TypesMatchups : MonoBehaviour
{
    [SerializeField] private TypeMatchups[] typesMathups;

    public static TypesMatchups Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public float GetMultplier(Types _attackingType, Types _defendingType)
    {
        for (int i = 0; i < typesMathups.Length; i++)
        {
            if (typesMathups[i].GetAttackingType().Equals(_attackingType))
            {
                return typesMathups[i].GetMultiplier(_defendingType);
            }
        }

        return 1;   //Neutral if not in database
    }
}