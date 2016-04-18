using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private bool isPaused;
	
    // Use this for initialization
	void Start ()
    {
	    if (Time.timeScale != 0)
            isPaused = false;
        else
            isPaused = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // "P", the pause button, was pressed.
        if (Input.GetKeyDown("p"))
        {
            if (isPaused == false)
                PauseGame();
            else
                ResumeGame();
        }
	}

    // Pauses the game.
    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    // Resumes the game.
    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
}
