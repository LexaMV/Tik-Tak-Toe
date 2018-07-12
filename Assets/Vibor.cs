using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibor : MonoBehaviour {

	// Use this for initialization

	public GameObject kubik;
	Transform transformkubik;
	void Start () {
		
	}
	
	// Update is called once per frame
	
    void Moves(){

		if(Input.GetMouseButtonDown(0)){
			

		Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition)); 

        Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(vector.y > kubik.transform.position.y){
        kubik.transform.position = new Vector2(kubik.transform.position.x, transform.position.y + 1.38f);

	    
		}
		else if(vector.y < kubik.transform.position.y){
        kubik.transform.position = new Vector2(kubik.transform.position.x, transform.position.y - 1.38f);
		}
		

		Debug.Log(kubik.transform.position);
		}
	}
	
		

	// Update is called once per frame
	void Update () {
		 
		    Moves();
			//transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y-10f), speed * Time.deltaTime);
			
		}  

}
