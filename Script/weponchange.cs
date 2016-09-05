using UnityEngine;
using System.Collections;

public class weponchange : MonoBehaviour {
	PlayerController    playerController;
	public float a = 1;
	public GameObject wepon;
	float outsidegun , obj ,EagleEye ,wepontype ,b ,c;
	GameObject camera;

	public Transform player;
	public Transform gun;

	

	void start(){
		GameObject obj = GameObject.Instantiate (wepon)as GameObject;
		obj.transform.parent = GameObject.Find("hand").transform;
	}

	void Update() {

		GameObject obj = GameObject.Find ("Player");
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 playerPos = player.position;
		playerController = obj.GetComponent<PlayerController> ();
		outsidegun = playerController.outsidegun;
		wepontype = playerController.wepontype;
		if (EagleEye == 0) {
			if (wepontype == 2){
				if (outsidegun == 2) {
					camera = GameObject.Find ("Main Camera");
					Vector3 pos = camera.transform.position;
					pos.y += 13;
					pos.z -= 4;
					camera.transform.position = pos;
					EagleEye = 1;

				}
			}
		}
		else {
			if (wepontype != 2){
				camera = GameObject.Find ("Main Camera");
				Vector3 pos = camera.transform.position;
				pos.y -= 13;
				pos.z += 4;
				camera.transform.position = pos;
				EagleEye = 0;
			}
		}
	}
	
	public void ButtonPush() {
		b = playerController.outsidegun;
		c = playerController.insidegun;
		if (b >= 1){
			if (a == 1){
				a = 2;

			} 
			else {
				a = 1;

			}
			playerController.wepontype = a;
			playerController.PlayAudio();

		}
	}
}