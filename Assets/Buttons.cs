using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public void Staring () {
		SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
	public void Exiting () {
		Application.Quit();
	}


	public void Helpening () {
  
              SceneManager.LoadScene(2);
	}
}
