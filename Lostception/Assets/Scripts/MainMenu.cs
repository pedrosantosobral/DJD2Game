using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main menu.
/// </summary>
public class MainMenu : MonoBehaviour {

    //Start the game and go next scene
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
