using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static bool Assert_Pos( float x,float y)
    {
        return (x*x<=Variables.dimX*Variables.dimX/4&&y*y<=Variables.dimY*Variables.dimY/4);
    }
}
