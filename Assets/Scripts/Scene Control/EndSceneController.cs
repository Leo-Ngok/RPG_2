using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndSceneController : MonoBehaviour
{
    public Text Des;
    // Start is called before the first frame update
    void Start()
    {
        Des.text=Scenes.msg;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            btn_quit_click();
    }
    public void btn_quit_click()
    {
        SceneManager.LoadScene(Scenes.Home);
    }
}
