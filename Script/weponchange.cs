using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class weponchange : MonoBehaviour {
	PlayerController    playerController;
	public float a = 1;
	public GameObject wepon;
	float outsidegun , obj ,EagleEye ,wepontype ,b ,c;
	GameObject camera;
	public Text bulletp;
	public Transform player;
	public Transform gun;


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
		if (playerController.wepontype == 1) {
			bulletp.color = new Color (15f/255f, 60/255f, 70/255f);
		}
		else{
			bulletp.color = new Color (200/255f, 255/255f, 255/255f);
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