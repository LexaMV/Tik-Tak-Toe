using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Primer : MonoBehaviour {
    private Color color1;
    private TimeSpan timeTimer;
    private TimeSpan timeproverka;
    private DateTime timeBegin;
    private DateTime dateproverka;

    private bool dpr;
    int x = 0;
	public  TextMeshProUGUI TextXod;

	public  TextMeshProUGUI Vrema;
   
   
    private GameObject[] plastinka;

    private GameObject[] proverkaenter;
    private GameObject[] proverkaexit;

	private GameObject gaming;

    private Vector3[] itog;
    private Vector3[] vectorproverki;

    private GameObject promej;

	Vector2 vector2;

    void Start () {
        timeBegin = DateTime.Now;

        color1 = new Color(255f,255f,255f,255f);
        Xodiki();
        
        dpr = false;
       
       // proverkaenter = GameObject.FindGameObjectsWithTag("Plastinka");
        plastinka = GameObject.FindGameObjectsWithTag("Plastinka");
       
        gaming = GameObject.Find("16");
        
        proverkaexit = new GameObject[16];
        itog = new Vector3[16];
        vectorproverki = new Vector3[16];

        for(int i = 0; i < plastinka.Length; i++)
        {
            itog[i] = new Vector3(plastinka[i].transform.position.x, plastinka[i].transform.position.y, 0);
            vectorproverki[i] = new Vector3(plastinka[i].transform.position.x, plastinka[i].transform.position.y,0);
        }

        Shuffle(itog);

        for (int i = 0; i < itog.Length; i++)
        {
            plastinka[i].transform.position = itog[i];
        }

      
        promej = null;

    }

void Xodiki(){
    TextXod.text = x.ToString();
}


     //Метод для перемешивания игрового поля
    void Shuffle(Vector3[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            Vector3 temp = deck[i];
            int randomIndex = UnityEngine.Random.Range(0, deck.Length);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }


    public void Proverka(){
    dateproverka = DateTime.Now;
    dpr = true;
    proverkaexit = GameObject.FindGameObjectsWithTag("Plastinka");
    for(int i = 0; i < proverkaexit.Length; i++){
        if(proverkaexit[i].transform.position == vectorproverki[i]){
            proverkaexit[i].gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else{
            proverkaexit[i].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

   
    }
    }






    void Update () {

         

          timeTimer = DateTime.Now - timeBegin;
          Vrema.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeTimer.Hours, timeTimer.Minutes, timeTimer.Seconds);
          //Vrema.text =  (Mathf.Round(z/3600)).ToString()+ " : " + (Mathf.Round(z/60)).ToString() + " : " + z.ToString();
		if(Input.GetMouseButtonDown(0)){
          
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
				// там есть объект?

               if(!(hit.rigidbody.gameObject.Equals(gaming))){
                 promej = hit.rigidbody.gameObject;
			     Debug.Log(promej);
				  Debug.Log((gaming.transform.position.x - promej.transform.position.x));
				  Debug.Log((gaming.transform.position.y - promej.transform.position.y));
			   }

			    else if(hit.rigidbody.gameObject.Equals(gaming) && promej != null){

                  if ((((int)(Math.Abs(gaming.transform.position.x - promej.transform.position.x)) == 1) && (Math.Abs(gaming.transform.position.y - promej.transform.position.y) == 0)) || 
				     ((Math.Abs(gaming.transform.position.x - promej.transform.position.x) == 0) && (Math.Abs(gaming.transform.position.y - promej.transform.position.y) == 1))) {
                         x++;
                  vector2 = promej.transform.position;
				  promej.transform.position = gaming.transform.position;
                  gaming.transform.position = vector2;
                  Xodiki();

			   }
                }
            }
        }
    


            if(dpr == true){
            timeproverka = DateTime.Now - dateproverka;
           if(timeproverka.Seconds > 4){
                for(int i = 0; i < proverkaexit.Length; i++){
           proverkaexit[i].gameObject.GetComponent<SpriteRenderer>().color = color1;
           }
           dpr = false;
          }
          
            }

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



