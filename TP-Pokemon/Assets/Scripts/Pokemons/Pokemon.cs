
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    //Base Values
    public string Name { get; private set; }

    public Types Type { get; private set; }

    public int PV { get; private set; }
    public int ATK { get; private set; }
    public int DEF { get; private set; }
    public int VIT { get; private set; }

    public DataAttack[] Datas { get; private set; }

    //Dynamic values

    private int currentPV;
    private bool inPokeball = true;
    private bool isAlive = true;

    private Attack[] attacks;

    private Human trainer;

    public Pokemon (DataPokemon _data, Human _trainer)
    {
        LoadData(_data);
        MakeMoves();

        if (Random.Range(0, 4102) == 0)
        {
            Name += " shiny";
        }

        trainer = _trainer;

        Name += " de " + _trainer.TrainerName;
    }

    private void LoadData(DataPokemon _data)
    {
        Name = _data.Name;
        Type = _data.Type;
        PV = _data.PV;
        ATK = _data.ATK;
        DEF = _data.DEF;
        VIT = _data.VIT;
        Datas = _data.Datas;

        currentPV = PV;
    }

    private void MakeMoves()
    {
        attacks = new Attack[Datas.Length];

        for(int i = 0; i < Datas.Length; i++)
        {
            attacks[i] = new Attack(Datas[i]);
        }
    }



    /// <summary>
    /// Used when automatically searching for an available pokemon => Doesn't do Debug.Log because not an action
    /// </summary>
    /// <returns></returns>
    public bool CanBeSentOut()
    {
        return currentPV > 0 && inPokeball;
    }

    /// <summary>
    /// 
    /// </summary>
    public void SendOut()
    {
        if (!isAlive)
        {
            Debug.Log($"{Name} est K.O. Il ne peut plus se battre");
            return;
        }

        if (!inPokeball)
        {
            Debug.Log($"{Name} est déjà sorti");
        }

        else
        {
            Debug.Log($"{trainer.TrainerName} envoie {Name}");
            inPokeball = false;
        }
    }

    /// <summary>
    /// The pokemon attacks using the required move given, from 0 to 3
    /// </summary>
    /// <param name="_index"></param>
    public void Attack(int _index, Pokemon _target)
    {
        if (!isAlive)
        {
            Debug.Log($"{Name} est K.O. Il ne peut plus attaquer !");
            return;
        }

        if (inPokeball)
        {
            Debug.Log($"{Name} est dans sa pokeball, il ne peut pas attaquer !");
            return;
        }

        if (_target.inPokeball)
        {
            Debug.Log($"{_target.Name} est dans sa pokeball, il ne peut pas se faire attaquer !");
            return;
        }

        if (attacks[_index] == null)
        {
            Debug.Log($"{Name} n'a pas appris de {_index + 1}e attaque !");
        }
        else
        {
            if (this.Equals(_target))
            {
                Debug.Log($"{Name} utilise {attacks[_index].Name} sur lui-même");
            }
            else
            {
                Debug.Log($"{Name} utilise {attacks[_index].Name} sur le {_target.Name}");
            }

            attacks[_index].Use(this, _target);
        }
    }

    public void RecieveDamage(float _trueDamage)
    {
        int _damage = (int)(_trueDamage - (DEF / 1.5f));

        Debug.Log($"{Name} reçoit {_damage} dégats !");

        currentPV = Mathf.Clamp(currentPV - _damage, 0, PV);    //Damage is rounded down

        if (currentPV > 0)
        {
            Debug.Log($"{Name} : {currentPV}/{PV}");
        }
        else
        {
            Debug.Log($"{Name} est K.0");
            isAlive = false;
            trainer.SendNextPokemon();
        }
    }

    public void RecieveHeal(float _healValue)
    {
        if (!isAlive)
        {
            Debug.Log($"{Name} est K.O. Il ne peut pas être soigné");
            return;
        }

        Debug.Log($"{Name} se soigne de {_healValue} pvs !");

        currentPV = (int) Mathf.Clamp(currentPV + _healValue, 0, PV);

        Debug.Log($"{Name} : {currentPV}/{PV}");
    }

    public void Revive(float _healValue)
    {
        if (isAlive)
        {
            Debug.Log($"{Name} est déjà en vie. Il ne peut pas être ressucité");
            return;
        }

        isAlive = true;
        RecieveHeal(_healValue);
    }
}