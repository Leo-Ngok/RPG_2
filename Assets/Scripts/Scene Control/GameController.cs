using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    public float Time_Elapsed{ get; set; }
    public GameObject[] monsters;
    void Start()
    {
        Time_Elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Time_Elapsed += Time.deltaTime;
        Camera.main.transform.position = Player.position - new Vector3(0, 0, 10);
        if(this.GetComponent<Generator>() == null && GameObject.Find("Demon(Clone)") == null)
        {
            Scenes.msg = "You Won";
            SceneManager.LoadScene(Scenes.End);
        } 
    }
}
