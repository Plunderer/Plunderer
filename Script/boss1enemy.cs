using UnityEngine;
using System.Collections;

public class boss1enemy : MonoBehaviour 
{
    // ボスのライフ関係の処理
    //武器の所持状況なども取扱い、武器がなくなると撃破と同じ演出を行う
    //Enemy.csをベースにしている
    public int st = 0;
    // st=2:武器無傷　=1:武器奪われずみ
    public int dropCount = 2;
    // =2:奪われてない　=1:奪われた
    public int hit = 2;
    boss1_new boss;
    AdvantageShift advantageshift;
    public float enemyspeed = 3; // 移動速度
    public GameObject explosion; // 爆発エフェクト
    public GameObject ScraoIrip;
    public GameObject Gato;
    private bool isQuitting = false;
    public float life = 30; // 敵の体力
    public float stunlife = 30; // 敵の怯み体力
    public float maxstunlife = 30; // 敵の怯み体力
    public float speed;
    public float scoredrop = 0;
	public int find;
    float bruntime, brundamage2, time, q, stunmax;
    float adsd = 1;
    float adss = 1;
    float Drop = 1;
    int rd;
    public GameObject wgato;
    void Start()
    {
        boss = GetComponent<boss1_new>();
    }
    void Update()
    {
        GameObject ads = GameObject.Find("PlayerMove");
        advantageshift = ads.GetComponent<AdvantageShift>();
        if(advantageshift.advantageshift == 1)
        {
            adss = 1.2f;
            adsd = 0.8f;
        }
        else if(advantageshift.advantageshift == 3)
        {
            adss = 1.1f;
            adsd = 1.1f;
        }
        else if(advantageshift.advantageshift == 5)
        {
            adsd = 1.3f;
        }
        else
        {
            adss = 1;
            adsd = 1;
        }
        time += Time.deltaTime;

        if(time >= 1)
        {
            if(bruntime > 0)
            {
                life -= brundamage2;

                if(life <= 0)
                {
                    // 体力が0以下になった時
                    Dead(); // 死亡処理
                }
                else if (life > 0)
                {
                    if (boss.find == 0 && boss.a == 0)
                    {
                        boss.find = 1;
                    }

                    hit = 1;
                    
                    iTween.ColorFrom(gameObject, iTween.Hash(
                    "color", new Color(100, 100, 100),
                    "time", 0.1f));
                    //被ダメージ処理 白点滅 
                }
                bruntime -= 1;
            }
            time = 0;
        }
    }

    public void Damage(float damage)
    {
        life -= damage * adsd; // 体力から差し引く

        if (life <= 0)
        {
            // 体力が0以下になった時
            Dead(); // 死亡処理
        }
        else if (life > 0)
        {
            if (boss.find == 0 && boss.a == 0)
            {
                boss.find = 1;
            }
            iTween.ColorFrom(gameObject, iTween.Hash(
            "color", new Color(100, 100, 100),
            "time", 0.1f));
        }
    }

    public void stunDamage(float stundamage)
    {
        stunlife -= stundamage * adss; // スタンライフから差し引く
        
        if(stunlife <= 0)
        {
            stunlife = maxstunlife;
            // 体力が0以下になった時
            drop(); // 武器ドロップ
        }
        else if (stunlife > 0)
        {
            if (boss.find == 0 && boss.a == 0)
            {
                boss.find = 1;
            }
        }
    }

    public void brundamage(float brundamage)
    {
        bruntime = 5;
        brundamage2 = brundamage;
    }

    // 死亡処理
    public void Dead()
    {
        if(q == 0)
        {
            q = 1;
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity); // 爆発パーティクルを生成
            Destroy(this.gameObject); // 自身を削除
        }
    }
    
    void dropwepon()
    {
        wgato.SetActive(false);
        Instantiate(Gato, transform.position, transform.rotation);
        boss = GetComponent<boss1_new>();
        boss.a = 40; // 行動パターン武器ドロップ時の隙を呼び出す(現在不安定)
        dropCount = 1;
        StartCoroutine("stop");
    }
    
    public void drop()
    {
        dropCount -= 1;

        if (dropCount == 1)
        {
            dropwepon();
        }
        else if (dropCount == 0)
        {
            Dead(); // 死亡処理
        }
    }

    IEnumerator stop()
    {
        Debug.Log("START");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("3秒経過");
        // プレイヤーの方を向く
        st = 1;
    }
}
