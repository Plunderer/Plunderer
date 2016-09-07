using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//残りライフに応じてライフバーの針を移動させる
public class Lifebar2: MonoBehaviour {
	PlayerLife    playerLife;
	float lifepa;
	void Start () {
		GameObject obj = GameObject.Find ("PlayerMove");
		playerLife = obj.GetComponent<PlayerLife> ();
	}
	
	void Update ()
	{
        lifepa = Mathf.Round(playerLife.life);
        lifepa = (lifepa * 5) - 250;
        if (playerLife.life <= 0)
        {
            iTween.MoveTo(gameObject, iTween.Hash(
            "x", -250, "isLocal", true
        ));
        }
        iTween.MoveTo(gameObject, iTween.Hash(
            "x", lifepa, "isLocal", true
        ));
	}
}
