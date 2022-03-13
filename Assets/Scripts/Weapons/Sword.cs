using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public  float       Damage    { get; set; }
    public  float       Interval  { get; set; }
    private Animator    animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent< Animator >();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Player_Initialize(PlayerController player)
    {

    }

    public void Attack(float damage)
    {
        animator.SetTrigger("Base_Attack");
        this.Damage = damage;
    }
    void OnTriggerEnter2D(Collider2D Col)
    {
        if(Col != null && this.transform.parent.tag != Col.tag)
        {
            if(Col.tag == "Opponent")
            {
                Col.transform.
                GetComponent<IOpponent>().
                Take_damage(this.Damage);
            }
            else if(Col.tag == "Player")
            {
                Col.transform
                .GetComponent<PlayerController>()
                .Take_damage(this.Damage);
            }
        }
    }
}
