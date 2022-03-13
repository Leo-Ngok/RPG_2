using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOpponent
{
    int   ID          { get; set; }
    float Experience  { get; set; }
    float LifeSpan    { get; set; }
    float Max_LifeSpan { get; set; }
    float Range         { get; set; }
    void Kill();
    void Take_damage(float amount);
    void Attack();
}
