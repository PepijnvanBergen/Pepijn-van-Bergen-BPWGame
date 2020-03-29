using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform player;
    private FlowerScript FS;
    private float flower;
    private float flower2;
    void Start()
    {
        FS = GameObject.FindObjectOfType<FlowerScript>();

        this.player = GameObject.FindWithTag("Player").transform;

        if (player)
        {
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Update()
    {
        if(player == null)
        {
            SceneManager.LoadScene("Menu");
        }
        if(flower >= 3)
        {
            SceneManager.LoadScene("Level2");
        }
        if(flower2 >= 3)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void UpdateFlower()
    {
        flower++;
    }
    public void UpdateFlower2()
    {
        flower2++;
    }

}
