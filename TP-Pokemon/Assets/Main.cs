using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [Header("Game")]
    [SerializeField] private GameManager game;    // Start is called before the first frame update

    [Header("Trainers")]
    [SerializeField] Human[] trainers;

    [Header("Individual Support Trainers")]
    [SerializeField] private Brook pierre;

    [Header("Seed")]
    [SerializeField] private int seed = 100;

    void Start()
    {
        //this.Play();
        this.Test();
    }

    private void Play()
    {
        game.InitGame(seed, trainers);
    }

    private void Test()
    {
        game.InitGame(seed, trainers);  //Test avec Seed 100

        trainers[0].pokemons[0].Attack(1, trainers[1].pokemons[0]); //Both in pokeball

        trainers[0].SendOut(trainers[1].pokemons[0]);   //Send Out pokemon of other trainer

        trainers[0].SendOut(trainers[0].pokemons[0]);   //Sacha envoie son Salam�che
        trainers[0].SendOut(trainers[0].pokemons[0]);   //Already Sent out

        trainers[0].pokemons[0].Attack(1, trainers[1].pokemons[0]);

        trainers[1].SendOut(trainers[1].pokemons[0]);   //Ondine envoie son Marisson

        trainers[0].pokemons[0].Attack(1, trainers[1].pokemons[0]); //Salam�che utilise Flam�che sur Marisson
        trainers[1].pokemons[0].Attack(2, trainers[1].pokemons[0]); //Marisson utilise Soin sur Lui m�me
        trainers[1].pokemons[0].Attack(1, trainers[0].pokemons[0]); //Marisson utilise TranchHerbe sur Salam�che
        trainers[1].pokemons[0].Attack(0, trainers[0].pokemons[0]); //Marisson utilise Belier sur Salam�che
        trainers[0].pokemons[0].Attack(1, trainers[1].pokemons[0]); //Salam�che utilise Flam�che sur Marisson
        trainers[0].pokemons[0].Attack(1, trainers[1].pokemons[0]); //Salam�che utilise Flam�che sur Marisson
        //Marisson meurt et Bulbizarre est envoy�
        trainers[1].pokemons[0].Attack(0, trainers[0].pokemons[0]); //Marisson utilise Belier sur Salam�che (il est mort)

        trainers[0].pokemons[0].Attack(1, trainers[1].pokemons[0]); //Salam�che utilise Flam�che sur Bulbizarre
    }
}
