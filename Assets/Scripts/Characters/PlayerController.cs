using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public double LifeSpan       = 40;
    public float  Experience     = 0;
    public bool   Frozen         = false;
    public float  Frozen_Time    = -1f;
    public float  Un_Freeze_Time = -1f;
    float Max_LifeSpan = 40;
    public Direction dir;
    public GameObject[] Weapons;
    int dir_sign = 1;
    List<IWeapon> weapons;
    GameObject sword;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(LifeSpan);
        LifeSpan = 40;
        weapons = new List<IWeapon>();
        //Sword
        sword = Instantiate( Weapons[0], this.transform.position - new Vector3(0, 0, 1), this.transform.rotation);
        sword.transform.SetParent(this.transform);
        weapons.Add(sword.transform.GetComponent<IWeapon>());
        //weapon = Sword.GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        Translate();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            weapons[0].Attack(1);
        }
        /*
        if(Input.GetKeyDown(KeyCode.Y))
        {
            var w = Instantiate(Weapons[1], this.transform.position + dir_sign * new Vector3 (2, 0, 0), this.transform.rotation);
            var t = w.GetComponent<BulletController>();
            t.Damage = 2;
            t.Range = 20;
            t.Velocity = 5;
            t.Player_Initialize(this);
        }*/
    }
    void Translate()
    {
        Vector3 pos = this.transform.position;
        float   x0  = pos.x;
        float   y0  = pos.y;
        float   z0  = pos.z;
        float   dt  = 0.02f;
        if(Frozen)
        {
            var tc = GameObject.Find("Scripts").GetComponent<GameController>();
            if(tc.Time_Elapsed > Un_Freeze_Time)
                Frozen = false;
            return;
        }
        if(Input.GetKey(KeyCode.S))
        {
            //if(Tools.Assert_Pos(x0, y0 - dt))
            {
                pos = new Vector3(x0, y0 - dt, z0);
            }
        }
        if(Input.GetKey(KeyCode.W))
        {
            //if(Tools.Assert_Pos(x0, y0 + dt))
            {
                pos = new Vector3(x0, y0 + 4 * dt, z0);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            dir = Direction.Left;
            if( 0 < dir_sign )
            {
                this.transform.Rotate(0, 180, 0);
                sword.transform.position -= new Vector3(0, 0, 2);

            }
            dir_sign = -1;
            //if(Tools.Assert_Pos(x0 - dt, y0))
            {
                pos = new Vector3(x0 - dt, y0, z0);
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            dir = Direction.Right;
            if( dir_sign < 0 )
            {
                this.transform.Rotate(0, 180, 0);
                sword.transform.position += new Vector3(0, 0, 2);
            }
            dir_sign = 1;
            //if(Tools.Assert_Pos(x0 + dt, y0))
            {
                pos = new Vector3(x0 + dt, y0, z0);
            }
        }
        this.transform.position = pos;
    }
    public void Take_damage(float amount)
    {
        LifeSpan -= amount;
        Debug.Log(LifeSpan);
        GameObject health_disp = this.transform.Find("Canvas").Find("Panel").gameObject;
        Vector2 offsetmax = health_disp.GetComponent<RectTransform>().offsetMax;
        health_disp.GetComponent<RectTransform>().offsetMax 
        = new Vector2( (float) ( LifeSpan / Max_LifeSpan -1 ) * 200, offsetmax.y);
        var health_color = health_disp.GetComponent<Image>().color;
        health_color = new Color( 1 - (float) LifeSpan / Max_LifeSpan, (float) LifeSpan / Max_LifeSpan, 0);
        health_disp.GetComponent<Image>().color = health_color;
        if( ! ( 0 < LifeSpan ) )
        {
            Scenes.msg = "You Lose";
            SceneManager.LoadScene(Scenes.End);
        }
    }
}
