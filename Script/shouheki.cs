using UnityEngine;
using System.Collections;

public class shouheki : MonoBehaviour 
{
	//プレイヤーを進ませすぎないための障害となる障壁システム
	//一部の対応した敵を倒すか直接攻撃することで破壊できる
	public GameObject explosion;    //爆発エフェクト
	public GameObject item;
	private bool isQuitting = false;
	public float life = 100;	//敵の体力
	float bruntime, brundamage2, time;
	
    	GameObject refObj;
    
    	public int hit = 0;
    	
	void start()
    	{
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
	
	void OnDestroy () 
    	{
		if(!isQuitting)
        	{
			GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
		}
	}
}
