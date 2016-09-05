using UnityEngine;
using System.Collections;

public class end : MonoBehaviour {

	Pausable    pausable;
	
	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find ("Canvas");
		pausable = obj.GetComponent<Pausable> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ButtonPush() {
		Time.timeScale = 1.0f;
        Application.LoadLevel("title");
	}
	
}
