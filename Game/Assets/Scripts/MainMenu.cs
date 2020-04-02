using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;

    private bool start = false;
    private bool quit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        if (isStart)
        {
            Debug.Log("Game started. Transition to next scene");
            StartGame();
        }
        else if (isQuit)
        {
            Debug.Log("Quitting game.");
            Application.Quit();
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
