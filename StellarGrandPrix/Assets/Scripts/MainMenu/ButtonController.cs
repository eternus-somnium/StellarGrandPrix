using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
	// Starts the demo level.
	public void StartDemo()
	{
		Debug.Log("Button was pressed.");
		SceneManager.LoadScene("Prototype");
	}

	// Closes the game.
	public void CloseGame()
	{
		Debug.Log("This should quit the game.");
		Application.Quit();
	}
}
