using UnityEngine;
using System.Collections;

public class shouheki : MonoBehaviour {

	public GameObject explosion;    //爆発エフェクト
	public GameObject item;
	private bool isQuitting = false;
	public float life = 100; //敵の体力
	float bruntime, brundamage2, time;
    // 固定ダメージ
    //public int n = 15;
    atari_Enemy atari;

    GameObject refObj;
    
    public int hit = 0;
	
	//float Drop = 1;
	
	
	//Dmage関数
	
	void start()
    {
        //refObj = GameObject.Find("atari_enemy");
	}
	
	void Update () 
    {
		time += Time.deltaTime;
		if (time >= 1) 
        {
			if (bruntime > 0) 
            {
				life -= brundamage2;
				if(life <= 0)
                {
					//体力が0以下になった時
					Dead(); //死亡処理
				}
				bruntime -= 1;
			}
			time = 0;
		}
        /*
        if(hit == 10)
        {
            life -= n;
        }*/
	}
	
	public void Damage ( float damage ) 
    {
		life -= damage; //体力から差し引く
		if(life <= 0)
        {
			//体力が0以下になった時
			Dead(); //死亡処理
		}
	}
	public void stunDamage ( float stundamage ) 
    {

	}
	public void brundamage ( float brundamage ) 
    {
		bruntime = 5;
		brundamage2 = brundamage;
	}
	
	
	//死亡処理
	public void Dead () 
    {
		if (item != null)
        {
			Instantiate (item,transform.position,transform.rotation);
		}
		GameObject Player = GameObject.Find("PlayerMove");
		GameObject.Instantiate(explosion, transform.position, Quaternion.identity); //爆発パーティクルを生成
		Destroy(this.gameObject);   //自身を削除
	}
    /*
    //連動処理
    public void rendou()
    {
        life -= 15;
    }

	void OnApplicationQuit () 
    {
		isQuitting = true;
	}*/
	
	void OnDestroy () 
    {
		if(!isQuitting)
        {
			GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
		}
	}
}
