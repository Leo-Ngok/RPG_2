using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F10))
        {
            Btn_Save_Click();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Btn_Exit_Click();
        }
    }
    public void Btn_Save_Click()
    {

        Btn_Exit_Click();
    }
    public void Btn_Exit_Click()
    {
        SceneManager.LoadScene(Scenes.Home);
    }
}
