using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class weponchange : MonoBehaviour {
	PlayerController    playerController;
	public int a = 1;
	public GameObject wepon;
	float outsidegun , obj ,EagleEye ,wepontype ,b ,c;
	GameObject camera;
	public Text bulletp;
	public Transform player;
	public Transform gun;
	public Animator animator;
	void Start(){
		GameObject obj = GameObject.Find ("Player");
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerController = obj.GetComponent<PlayerController> ();
	}
	void Update() {
		animcheck ();
		Vector3 playerPos = player.position;
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
				animator.SetBool("outside", true);
				animator.SetBool("Motionbool", true);
				a = 0;
			} 
			else {
				animator.SetBool("outside", false);
				animator.SetBool("Motionbool", true);
				a = 1;
			}
			playerController.wepontype = a;
			playerController.PlayAudio();
		}
	}
	void animcheck(){
		AnimatorStateInfo animInfo = animator.GetCurrentAnimatorStateInfo (0);

		if (animInfo.normalizedTime <= 1.0f) {
			animator.SetBool("Motionbool", false);
		}
	}
}