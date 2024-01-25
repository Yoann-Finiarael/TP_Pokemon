using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Pokemons")]
    [SerializeField] DataPokemon[] pokemons;

    public static GameManager Instance;

    private Human[] allTrainers;

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

    public void InitGame(int _seed, Human[] _trainers)
    {
        Random.InitState(_seed);

        InitTrainers(_seed, _trainers);
    }

    public void InitTrainers(int _seed, Human[] _trainers)
    {
        allTrainers = _trainers;
        for (int i = 0; i < _trainers.Length; i++)
        {
            for (int j = 0; j < _trainers[i].MaxPokemons; j++)
            {
                _trainers[i].Catch(new Pokemon(pokemons[(int)(Random.value * (pokemons.Length - 1))], _trainers[i]));
            }
        }
    }

    public void Winner()
    {
        Human winner = null;

        for (int i = 0; i < allTrainers.Length; i++)
        {
            if (allTrainers[i].HasAvailablePokemons())
            {
                if (winner == null)     //No trainer has had available pokemons yet (could be the winner)
                {
                    winner = allTrainers[i];
                }
                else                    //If One trainer already has available pokemons (no winner yet)
                {                   
                    return;
                }
            }
        }

        if (winner != null)
        {
            Debug.Log($"{winner.TrainerName} est le vainceur");
        }
    }
}
