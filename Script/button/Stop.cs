using UnityEngine;
using System.Collections;

public class Stop : MonoBehaviour {
	public GameObject button1;
	public GameObject button2;
	public GameObject s;
	public GameObject s2;
	public GameObject restart;
	public GameObject ads1;
	public GameObject ads2;
	public GameObject end;
	public GameObject stop;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void ButtonPush() {
		button1.SetActiveRecursively (false);
		button2.SetActiveRecursively (false);
		ads1.SetActiveRecursively (false);
		ads2.SetActiveRecursively (false);
		restart.SetActiveRecursively (true);
		end.SetActiveRecursively (true);
		Time.timeScale = 0.0f;
		stop.SetActiveRecursively (false);
	}
}
