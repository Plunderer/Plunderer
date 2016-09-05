using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {
	public GameObject button1;
	public GameObject button2;
	public GameObject s;
	public GameObject s2;
	public GameObject Restart;
	public GameObject ads;
	public GameObject end;
	public GameObject stop;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ButtonPush2() {
		Time.timeScale = 1.0f;
		button1.SetActiveRecursively (true);
		button2.SetActiveRecursively (true);
		ads.SetActiveRecursively (true);
		stop.SetActiveRecursively (true);
		end.SetActiveRecursively (false);
		Restart.SetActiveRecursively (false);
	}
	
}
