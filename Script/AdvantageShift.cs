using UnityEngine;
using System.Collections;

public class AdvantageShift : MonoBehaviour {
	PlayerController    playerController;
	PlayerLife    playerLife;
	float ads = 1;
    public int advantageshift = 1;//アドバンテージシフトのコード
    
    /*
アドバンテージシフトのコード
    0機動型
    1攻撃型
    2防御型
     */
    // Use this for initialization
    void Start (){
        GameObject obj = GameObject.Find ("PlayerMove");
		playerLife = obj.GetComponent<PlayerLife> ();
		GameObject obj2 = GameObject.Find ("Player");
		playerController = obj2.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ads != advantageshift) {
			ads = advantageshift;
			if (playerLife.life >= playerLife.maxLife){
				playerLife.life = playerLife.maxLife;
			}
			if (playerController.ammo >= playerController.MAXammo){
				playerController.ammo = playerController.MAXammo;
			}

		}
	}
}