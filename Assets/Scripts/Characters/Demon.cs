using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Demon : MonoBehaviour, IOpponent
{
    // Start is called before the first frame update
    PlayerController player;
    public GameObject sword;
    GameController game;
    public float Prev_Attack_Time_Stamp {get;set;}
    void Start()
    {
        player = GameObject.Find("Player") .GetComponent<PlayerController>();
        game   = GameObject.Find("Scripts").GetComponent<GameController>();
        LifeSpan  = Max_LifeSpan = 10;
        Interval  = 2.5f;
        MoveSpeed = 0.01f;
        Prev_Attack_Time_Stamp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.gameObject.transform.position);
        if(4 < dist )
        this.Move();
        if( game.Time_Elapsed - Prev_Attack_Time_Stamp >= Interval
             && dist <= 4)
        this.Attack();
    }

    public int   ID          { get; set; }
    public float Experience  { get; set; }
    public float LifeSpan    { get; set; }
    public float Max_LifeSpan { get; set; }
    public float Range { get; set; }
    public float MoveSpeed      {get;set;}
    public float Interval       {get;set;}
    public void Kill()
    {
        
        Destroy( this.gameObject );
    }
    public void Take_damage(float amount)
    {
        LifeSpan -= amount;
        GameObject health_disp = this.transform.Find("Canvas").Find("Panel").gameObject;
        Vector2 offsetmax = health_disp.GetComponent<RectTransform>().offsetMax;
        health_disp.GetComponent<RectTransform>().offsetMax 
        = new Vector2( ( LifeSpan / Max_LifeSpan -1 ) * 200, offsetmax.y);
        var health_color = health_disp.GetComponent<Image>().color;
        health_color = new Color(1 - LifeSpan / Max_LifeSpan, LifeSpan / Max_LifeSpan, 0);
        health_disp.GetComponent<Image>().color = health_color;
        if( ! (0 < LifeSpan) ) Kill();
    }
    public void Attack()
    {
        Prev_Attack_Time_Stamp = game.Time_Elapsed;
        sword.GetComponent<Sword>().Attack(0.7f);
    }
    public void Move()
    {
        float t = Mathf.Sign(player.gameObject.transform.position.x - this.transform.position.x);
        this.transform.position += t * MoveSpeed * new Vector3( 1, 0, 0);
    }
}
