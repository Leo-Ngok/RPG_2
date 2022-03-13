//#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Start is called before the first frame update
#if RELEASE
    public KeyCode      key;
    public GameObject   weapon;
    public Type         objType = typeof(BulletController);
#else
    
            
           int          count;        
    public KeyCode[]    keys    = {KeyCode.Space,KeyCode.Mouse0,KeyCode.Mouse1,
                                    KeyCode.E,KeyCode.F,KeyCode.R,KeyCode.Q};
    public GameObject[] weapons;
    public Type[]       objTypes;
#endif
    void Start()
    {
        count = weapons.Length;
    }

    // Update is called once per frame
    void Update()
    {
#if RELEASE
        for(int ii = 0; ii < count; ii++)
        {
            if(Input.GetKeyDown(keys[ii]))
            {
                var player = this.GetComponent<PlayerController>();
                var _weapon = Instantiate(weapons[ii], this.transform.position + new Vector3(-1.7F, 0.5F, 0), this.transform.rotation);
                WeaponController weaponController = (WeaponController) _weapon.GetComponent(objTypes[ii]);
                weaponController.Player_Initialize(ref player);
            }
        }
        
#else

#endif
    }
}
