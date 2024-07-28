using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToCreateScene()
    {
        SceneManager.LoadScene("CreateAccount");
    }

    public void changeToLoginScene()
    {
        SceneManager.LoadScene("LoginMenu");
    }

    public void changeToGameScene()
    {
        SceneManager.LoadScene("BlocketLeague");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
