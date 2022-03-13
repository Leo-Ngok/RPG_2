#define DEBUG
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Btn_Entry_Click();
        }
        else if(Input.GetKeyDown(KeyCode.F10))
        {
            //Btn_Settings_Click();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Btn_Exit_Click();
        }
    }
    public void Btn_Entry_Click()
    {
        SceneManager.LoadScene(Scenes.Level1);
    }
    public void Btn_Settings_Click()
    {
        SceneManager.LoadScene(Scenes.Settings);
    }
    public void Btn_Exit_Click()
    {
#if DEBUG
        Debug.Log("Quit invoked");
#endif
        Application.Quit(0);
    }
}
