using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public static bool enhanced;

    // Start is called before the first frame update
    void Start()
    {
        enhanced = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame(){
        enhanced = false;
        SceneManager.LoadScene("Game");
    }

    public void Enhanced(){
        enhanced = true;
        SceneManager.LoadScene("Game");
    }

    public void  QuitGame(){
        Application.Quit();
    }

    
}
