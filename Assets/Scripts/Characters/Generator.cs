using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    bool Can_Generate { get; set; }
    public float Interval { get; set; }
    public GameObject Demon;// { get; set; }
    public GameController game;
    float t0 = 0;
    int count = 6;
    void Start()
    {
        
        Interval = 5;
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        if(count < 0)
        {
            Destroy(this);
        }
        t0 += Time.deltaTime;
        if( !(t0 < Interval) ) Generate();

    }
    void Generate()
    {
        //if(Can_Generate)
        //{
            count--;
            var obj = Instantiate(Demon, new Vector3 (Random.Range(-6, 6), 0, 0), Quaternion.identity);
            //IOpponent opponent = obj.transform.GetComponent<IOpponent>();
            
        //}
        t0 = 0;
        //Can_Generate = false;
    }
    void Continue_Gen()
    {
        Can_Generate = true;
        // t0 = Interval;
    }
}
