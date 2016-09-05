using UnityEngine;
using System.Collections;

public class shild : MonoBehaviour {
    PlayerLife playerlife;
    AdvantageShift ads;
    GameObject obj;
    public float mainusdamage = 1.3f;//ダメージ量をここの数値で減らす
	// Use this for initialization
	void Start () {
        obj=GameObject.Find("PlayerMove");
        playerlife = obj.GetComponent<PlayerLife>();//ライフのスクリプトを取得
        ads = obj.GetComponent<AdvantageShift>();//ライフのスクリプトを取得
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Damage (float attack) {
        if(ads.advantageshift == 2)//もし防御形態なら
        {
            attack /= mainusdamage;//設定したダメージ量ぶんダメージを減らし
        }
        playerlife.gameObject.SendMessage("Damage", attack);   //Damage関数を実行する
	}
}
