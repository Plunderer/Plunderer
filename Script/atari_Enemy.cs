using UnityEngine;
using System.Collections;

public class atari_Enemy : MonoBehaviour 
{
	AdvantageShift    advantageshift;
	public float enemyspeed = 3; //移動速度
	public GameObject explosion;    //爆発エフェクト
	public GameObject ScraoIrip;
	private bool isQuitting = false;
	public float life = 30; //敵の体力
	public    float    speed;
	public float scrapdrop = 0;
	float bruntime,brundamage2,time,q;
	float adsd = 1;
	float adss = 1;
	float Drop = 1;
	int rd;
    
    public GameObject shouheki;
    public int yobidasi = 0;

    GameObject refObj;

	//Dmage関数

    void start()
    {
        refObj = GameObject.Find("shouheki");
    }

	void Update () 
    {
		GameObject ads = GameObject.Find ("PlayerMove");
		advantageshift = ads.GetComponent<AdvantageShift> ();
		if (advantageshift.advantageshift == 1) 
        {
			adss = 1.2f;
			adsd = 0.8f;
		} 
        else if (advantageshift.advantageshift == 3) 
        {
			adss = 1.1f;
			adsd = 1.1f;
		} 
        else if (advantageshift.advantageshift == 5) 
        {
			adsd = 1.3f;
		} 
        else 
        {
			adss = 1;
			adsd = 1;
		}
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

        if(life <= 0)
        {
            shouheki d2 = refObj.GetComponent<shouheki>();
            //d2.rendou();
            d2.hit = 10;
        }
	}

	public void Damage ( float damage ) 
    {
		life -= damage * adsd; //体力から差し引く
		if(life <= 0)
        {
			//体力が0以下になった時
			Dead(); //死亡処理
		}
        else if(life > 0)
        {
            iTween.ColorFrom(gameObject, iTween.Hash(
            "color", new Color(100, 100, 100),
            "time", 0.1f));
            //被ダメージ処理 白点滅
        }
	}
	public void brundamage ( float brundamage ) 
    {
		bruntime = 5;
		brundamage2 = brundamage;
	}


	//死亡処理
	public void Dead () 
    {
		if (q == 0) 
        {
			q = 1;
			GameObject Player = GameObject.Find ("PlayerMove");
			if (ScraoIrip != null)
            {
				rd = UnityEngine.Random.Range (0, 5);
				for (int i = rd; i < 6; i++)
				{
					Instantiate (ScraoIrip,transform.position,transform.rotation);
				}
			}
			GameObject.Instantiate (explosion, transform.position, Quaternion.identity); //爆発パーティクルを生成
			Destroy (this.gameObject);   //自身を削除

            //shouheki d2 = refObj.GetComponent<shouheki>();
            //d2.rendou();
		}
	}
}