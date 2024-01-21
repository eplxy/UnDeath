using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
public void PlayGame() {
	SceneManager.LoadScene("InitialLevel");
}

// Update is called once per frame
	void Update ()
	{
		
	
	}
public void ExitGame() {
	Application.Quit();
}

}
