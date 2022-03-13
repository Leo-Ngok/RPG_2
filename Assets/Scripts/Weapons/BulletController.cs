using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletController : MonoBehaviour, IWeapon
{
    public float Damage    { get; set; }
    public float Interval  { get; set; }
    public float Velocity  { get; set; }
    public float Range     { get; set; }
    public Vector3 r_0     { get; set; }

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        this.Velocity = 0.05f;
        this.Damage   = 1.50f;
        this.r_0      = this.transform.position;
        var col = this.gameObject.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
    }
    public void Player_Initialize(PlayerController player)
    {
        var r = player.dir;
        switch(r)
        {
            case Direction.Left:
            dir = new Vector3(-1f, 0f, 0f);break;
            case Direction.Right:
            dir = new Vector3(+1f, 0f, 0f);break;
            default: break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += dir * Velocity;
        if(!( Vector3.Distance(r_0, this.transform.position )  < Range ) )
            Destroy(this.gameObject);
        
    }
    public void Attack (float damage)
    {
        this.Damage = damage;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
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
        Destroy(this.gameObject);
    }
    
}
