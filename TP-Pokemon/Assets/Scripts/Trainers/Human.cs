using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : MonoBehaviour
{
    public List<Pokemon> pokemons 
    { 
        get;
        protected set;
    } 
        = new List<Pokemon>();

    public string TrainerName { get; protected set; }
    public int MaxPokemons { get; protected set; }

    protected Human opponent = null;
    protected bool isBattling = false;
    
    public void Catch(Pokemon _mon)
    {
        pokemons.Add(_mon);
        Debug.Log($"{TrainerName} a attrappé un {_mon.Name}");
    }

    public void SendOut(Pokemon _mon)
    {
        for (int i = 0; i < pokemons.Count; i++)
        {
            if (pokemons[i].Equals(_mon))
            {
                _mon.SendOut();
                return;
            }
        }

        Debug.Log("On ne peut pas envoyer au combat le pokemon d'un autre dresseur !");
    }

    /// <summary>
    /// Called upon the death of one of the Trainer's pokemon. Automatically sends the next available pokemon. Also checks if the trainer has lost all its pokemons
    /// </summary>
    public void SendNextPokemon()
    {
        for (int i = 0; i < pokemons.Count; i++)
        {
            if (pokemons[i].CanBeSentOut())
            {
                pokemons[i].SendOut();
                return;
            }
        }

        if (!HasAvailablePokemons())
        {
            Debug.Log($"Toues les pokemons de {TrainerName} sont K.O. {TrainerName} a donc perdu");
        }

        GameManager.Instance.Winner();
    }

    /// <summary>
    /// Returns true if the Trainer still has at least one pokemon alive
    /// </summary>
    /// <returns></returns>
    public bool HasAvailablePokemons()
    {
        for (int i = 0; i < pokemons.Count; i++)
        {
            if (pokemons[i].CanBeSentOut()) //IsAlive
            {
                return true;
            }
        }

        return false;
    }
}