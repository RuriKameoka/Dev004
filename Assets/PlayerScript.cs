using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	Vector3 down_posi = new Vector3( 0.0f, 0.0f, 0.0f);
	Vector3 up_posi = new Vector3( 0.0f, 0.0f, 0.0f);
	Vector3 vel_vec = new Vector3( 0.0f, 0.0f, 0.0f);
	Vector3 nom_vel = new Vector3( 0.0f, 0.0f, 0.0f);
	bool mouseFlag = false;
	Vector3 init_posi = new Vector3(0.0f, 0.0f, 0.0f);

	int Gameover_flag = 0;
	public float timer = 30f; 
	public int score = 0;
	public GameObject Timer_text;
	public GameObject Gameover_text;
	public GameObject Clear_text;


	// Use this for initialization
	void Start () {
		init_posi = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//------ timer ------//
		timer -= 1 * Time.deltaTime;
		Timer_text.GetComponent<Text>().text = "Time : " + timer.ToString();

		if((timer < 0)&&(Gameover_flag == 0)){
			Gameover_text.GetComponent<Text>().enabled = true;
		}

		//------ score ------//
		if(score == 3){
			Gameover_flag = 1;
			Clear_text.GetComponent<Text>().enabled = true;
			Debug.Log("CLEAR");

		}


		//------ mouse Input ------//
		if(Input.GetMouseButtonDown(0)){
			mouseFlag = true;
			down_posi = Input.mousePosition;
		}

		if((Input.GetMouseButtonUp(0))&&(mouseFlag == true)){
			mouseFlag = false;
			up_posi = Input.mousePosition;
			vel_vec = down_posi - up_posi;
			if(vel_vec.sqrMagnitude > 40f){
				nom_vel = vel_vec.normalized;
				gameObject.GetComponent<Rigidbody>().velocity = nom_vel * 40f;
			}else{
				gameObject.GetComponent<Rigidbody>().velocity = nom_vel;
			}
			
		}
		

		//------ player position ------//
		if((transform.position.x < -15) || (transform.position.x > 15)){
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);;
			transform.position = init_posi;
		}
		if((transform.position.y < -20) || (transform.position.y > 20)){
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);;
			transform.position = init_posi;
		}

	}

	private void OnTriggerEnter(Collider other){
		if((other.gameObject.tag == "treasure")&&(other.gameObject.GetComponent<Light>().range < 5)){
			other.gameObject.GetComponent<Light>().range = 10;
			score += 1;
			Debug.Log("スコア: " + score);
		}
	}
}
