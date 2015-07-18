using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {
	public float timer = 30f; 
	public GameObject Gameover_text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//------ timer ------//
		timer -= 1 * Time.deltaTime;
		GetComponent<Text>().text = "Time : " + timer.ToString();

		if(timer < 0){
			//Gameover_text.GetComponents<Text>().enabled = true;
		}
	
	}
}
