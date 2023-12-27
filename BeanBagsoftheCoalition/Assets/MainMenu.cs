using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string localMultiplayerScene;
    public void loadMultiplayer()
    {
        SceneManager.LoadScene(localMultiplayerScene);
    }
    public void Quit()
    {
        Debug.Log("quit");
        //Application.Quit();
    }
}
