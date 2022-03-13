using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : BulletController
{
    float Freeze_Duration = 2.0f;
    Vector3 dir;
    public void Player_Initialize(ref PlayerController player)
    {
        Freeze_Duration = 2.0f;
        var r = player.dir;
        switch(r)
        {
            case Direction.Left:
            dir = new Vector3(-1f, 0f, 0f); break;
            case Direction.Right:
            dir = new Vector3(+1f, 0f, 0f); break;
            default: break;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var prof = collider.GetComponent<PlayerController>();
        if( prof == null ) return;
        if(this.tag != collider.tag)
        {
            if(collider.tag == "Opponent")
            {
                collider.transform.
                GetComponent<IOpponent>().
                Take_damage(this.Damage);
            }
            else
            {
                collider.transform
                .GetComponent<PlayerController>()
                .Take_damage(this.Damage);
            }
        }
        var tc         = GameObject.Find("Scripts").GetComponent<GameController>();
        prof.Frozen_Time = tc.Time_Elapsed;
        prof.Un_Freeze_Time = tc.Time_Elapsed + Freeze_Duration;
        Debug.Log(prof.LifeSpan);
        Destroy(this.gameObject);
        
    }
}
