using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public string Name { get; private set; }

    public int BasePower { get; private set; }
    public Types Type { get; private set; }

    public bool DoesDamage { get; private set; }
    public bool DoesHeal { get; private set; }

    public bool TargetSelf { get; private set; }


    private float effectivenessMulti;
    private float critMulti;
    private float effectivePower;

    public Attack (DataAttack _data)
    {
        Name = _data.Name;

        BasePower = _data.BasePower;
        Type = _data.Type;

        DoesDamage = _data.DoesDamage;
        DoesHeal = _data.DoesHeal;

        TargetSelf = _data.TargetSelf;  
    }

    public void Use(Pokemon _user, Pokemon _target)
    {
        if (TargetSelf && (!_user.Equals(_target)))     //Si l'attaque est sur soi et la cible n'est pas l'utilisateur
        {
            Debug.Log($"{Name} ne peut cibler que le lanceur. L'attaque est donc redirigée vers celui ci");
            _target = _user;
        }

        if (DoesDamage)
        {
            effectivenessMulti = TypesMatchups.Instance.GetMultplier(Type, _target.Type);

            if (Random.Range(0, 23) == 0)
            {
                critMulti = 1.5f;
                Debug.Log("Coup critique !");
            }
            else
            {
                critMulti = 1;
            }

            effectivePower = ((float)BasePower / 100);

            _target.RecieveDamage(effectivePower * _user.ATK * effectivenessMulti * critMulti);
        }
            
        if (DoesHeal)
        {
            _target.RecieveHeal(BasePower);
        }
    }
}