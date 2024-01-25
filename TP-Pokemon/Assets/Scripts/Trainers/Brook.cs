using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brook : Human
{
    [SerializeField] private int cookHeal = 50;
    // Start is called before the first frame update
    void Start()
    {
        this.TrainerName = "Pierre";
        this.MaxPokemons = 2;
    }

    
    public void Cook(Human[] _trainers)
    {
        Debug.Log($"{TrainerName} cuisine pour tous les pokemons");

        for (int i = 0; i < _trainers.Length; i++)
        {
            for (int j = 0; j < _trainers[i].pokemons.Count; j++)
            {
                _trainers[i].pokemons[j].RecieveHeal(cookHeal);
            }
        }
    }

    public void FullRestore(Pokemon _mon)
    {
        Debug.Log($"{TrainerName} utilise un Full Restore sur {_mon.Name}");

        _mon.RecieveHeal(_mon.PV);
    }

}
