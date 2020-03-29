using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Level1Button()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2Button()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Sandbox()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
