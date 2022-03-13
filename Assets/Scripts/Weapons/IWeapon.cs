using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float Damage    {get;set;}
    float Interval  {get;set;}
    //float LifeSpan  {get;set;}
    void Player_Initialize(PlayerController player);
    void Attack(float damage);

}
