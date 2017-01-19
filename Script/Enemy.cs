using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    EffekseerEmitter effekseerEmitter;
    // 障壁へのダメージ関数
    public int n = 25;
	AdvantageShift    advantageshift;
	public float enemyspeed = 3; //移動速度
	public GameObject explosion;    //爆発エフェクト
	public GameObject ScraoIrip;
	private bool isQuitting = false;
	public float life = 30; //敵の体力
	public float stunlife = 30; //敵の怯み体力
	EnemyMove    enemyMove;
	public    float    speed;
    EnemyPattern enemyPattern;
	public float scrapdrop = 0;
	float bruntime,brundamage2,time,q;
	float adsd = 1;
	float adss = 1;
	float Drop = 1;
	public GameObject machingun;
	public GameObject Laser;
	public GameObject misa;
	public GameObject shotgun;
	public GameObject EagleEye;
	public GameObject Pulsemisa;
	public GameObject BounceRevolver;
	public GameObject UCrifle;
	public GameObject burner;
	public GameObject Gasogre;
	public GameObject Gato;
	public GameObject Voltaic;
	public GameObject sctum;
	public GameObject rapid;
	public GameObject next;
	public GameObject Tetla;
	public GameObject bazz;
	public GameObject moa;
	public GameObject heby;
	public GameObject roke;
	public GameObject loki;
	public GameObject reale;
	public GameObject pile;
    public GameObject highcanon;
    public GameObject surabure;
	int rd;
    GameObject ads;
    Color preColor, color;
    public GameObject syouheki;
    private AudioSource sound01;
    
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[5];
        
        ads = GameObject.Find("PlayerMove");
        advantageshift = ads.GetComponent<AdvantageShift>();
        enemyPattern = GetComponent<EnemyPattern>();
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
        /*iTween.ColorFrom(gameObject, iTween.Hash(
        "color", new Color(100, 100, 100),
        "time", 0.01f));*/
        //被ダメージ処理 白点滅
		life -= damage * adsd; //体力から差し引く
        rd = UnityEngine.Random.Range(0, 4);
        sound01.Play();
        if (rd == 0)
        {
            enemyPattern.find = true;//発見状態
            enemyPattern.patanhandan();
        }
		if(life <= 0)
        {
			//体力が0以下になった時
			Dead(); //死亡処理
		}
	}
	public void stunDamage ( float stundamage ) 
    {
        if (stunlife > 0) {
            stunlife -= stundamage * adss; //体力から差し引く
            if (stunlife <= 0 && stunlife != -1)
            {
                //体力が0以下になった時
                drop(); //死亡処理
            }
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
            if (syouheki != null)
            {
                syouheki.gameObject.SendMessage("Damage", n);   //相手のDamage関数を実行する
            }
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
		}
	}
	void dropwepon ()
    {
        enemyMove = GetComponent<EnemyMove>();
        if(enemyMove.wepontype == 1)
        {
            switch (enemyMove.insidegun)
            {
                case 0:
                    Instantiate(machingun, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 1:
                    Instantiate(Laser,  new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 2:
                    Instantiate(misa,  new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                default:
                    break;
            }
            /*
            if (enemyMove.insidegun == 0)
            {
                Instantiate (machingun,transform.position,transform.rotation);
            }
            else if (enemyMove.insidegun == 1)
            {
                Instantiate (Laser,transform.position,transform.rotation);
            }
            else if (enemyMove.insidegun == 2)
            {
                Instantiate (misa,transform.position,transform.rotation);
            }
            */
            Dead(); //死亡処理
        }
        
        else
        {
            switch (enemyMove.outsidegun)
            {
                case 1:
                    Instantiate(shotgun, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 2:
                    Instantiate(EagleEye, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 3:
                    Instantiate(Pulsemisa, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 4:
                    Instantiate(BounceRevolver, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 5:
                    Instantiate(UCrifle, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 6:
                    Instantiate(burner, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 7:
                    Instantiate(Gasogre, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 8:
                    Instantiate(Gato, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 9:
                    Instantiate(Voltaic, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 10:
                    Instantiate(sctum, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 11:
                    Instantiate(rapid, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 12:
                    Instantiate(next, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 13:
                    Instantiate(Tetla, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 14:
                    Instantiate(bazz, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 15:
                    Instantiate(moa, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 16:
                    Instantiate(heby, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 17:
                    Instantiate(roke, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 18:
                    Instantiate(loki, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 19:
                    Instantiate(highcanon, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                case 20:
                    Instantiate(surabure, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                    break;
                default:
                    break;

            }
            /*
            if (enemyMove.outsidegun == 1)
            {
                Instantiate(shotgun, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 2)
            {
                Instantiate(EagleEye, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 3)
            {
                Instantiate(Pulsemisa, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 4)
            {
                Instantiate(BounceRevolver, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 5)
            {
                Instantiate(UCrifle, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 6)
            {
                Instantiate(burner, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 7)
            {
                Instantiate(Gasogre, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 8)
            {
                Instantiate(Gato, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 9)
            {
                Instantiate(Voltaic, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 10)
            {
                Instantiate(sctum, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 11)
            {
                Instantiate(rapid, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 12)
            {
                Instantiate(next, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 13)
            {
                Instantiate(Tetla, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 14)
            {
                Instantiate(bazz, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 15)
            {
                Instantiate(moa, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 16)
            {
                Instantiate(heby, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 17)
            {
                Instantiate(roke, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 18)
            {
                Instantiate(loki, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 19)
            {
                Instantiate(reale, transform.position, transform.rotation);
            }
            else if (enemyMove.outsidegun == 20)
            {
                Instantiate(pile, transform.position, transform.rotation);
            }
            */
        }
	}
	public void drop () 
    {
		if (Drop == 1) 
        {
			enemyMove = GetComponent<EnemyMove> ();
			if (enemyMove.wepontype == 0)
            {
				dropwepon();
			}
			enemyMove.wepontype = 1;
		}
		Drop = 0;
	}
}