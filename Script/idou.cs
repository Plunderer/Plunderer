using UnityEngine;
using System.Collections;

public class idou : MonoBehaviour {

	public float timer = 3;
	
	void Update() {

	}
	
	void OnTriggerEnter (Collider col) {
		if(col.gameObject.tag == "Player"){
			Application.LoadLevel("gameover");
		}
	}
}
