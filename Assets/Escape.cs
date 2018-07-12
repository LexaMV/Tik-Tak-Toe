using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
         {
             if (Application.platform == RuntimePlatform.Android)
             {
                SceneManager.LoadScene(0);
             }
             else
             {
                 Application.Quit();
             }
         }

	}
}
