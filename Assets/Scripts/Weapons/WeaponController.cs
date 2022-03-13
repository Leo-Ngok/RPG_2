using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Vector3 dir;
    public float velocity;
    public float LifeSpan_Reduction;
    public float Freeze_Duration = 2.0f;
    public virtual void Player_Initialize(ref PlayerController playerController){}
    public virtual void Demon_Initialize(){}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
