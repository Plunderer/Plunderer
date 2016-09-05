using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//0.11~0.625~0.75
public class Lifebar: MonoBehaviour {
	Image image;
	PlayerLife    playerLife;
	float lifepa;
	void Start () {
		image = GetComponent<Image>();
		GameObject obj = GameObject.Find ("PlayerMove");
		playerLife = obj.GetComponent<PlayerLife> ();
	}
	
	void Update ()
	{
		if (playerLife.life == 0) {
			image.fillAmount = 0;
		} else {
			lifepa = playerLife.hacgage;
			lifepa = lifepa / 1000;
			image.fillAmount = lifepa;
			if (image.fillAmount <= 0) {
				image.fillAmount = 0;
			}
		}

	}
}
