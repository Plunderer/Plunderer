using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//0.11~0.625~0.75
public class bulletbar : MonoBehaviour {
	//以前までは残弾ゲージだったが、
    //途中から残弾数の表示に切り替わった為bulletbarという名前のまま
    Image image;
	PlayerController    playerController;
	float ammopa;
    Text text;
	void Start () {
		image = GetComponent<Image>();
		GameObject obj = GameObject.Find ("Player");
		playerController = obj.GetComponent<PlayerController> ();
        text = GetComponent<Text>();
	}

    void Update()
    {
        text.text = playerController.ammo.ToString()+"/"+ playerController.MAXammo.ToString();
    }
}