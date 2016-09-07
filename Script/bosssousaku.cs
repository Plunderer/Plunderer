using UnityEngine;
using System.Collections;
//ボス版プレイヤー捜索用スクリプト
//プレイヤーの座標に向かって移動し、視界にプレイヤーが入ったら攻撃パターンを開始する
public class sousaku : MonoBehaviour 
{
	float enemyspeed; //移動速度
	float time,pattern;
	Enemy enemy;
    boss1enemy boss;
	public float Anglebend = 180f;//曲がる角度(+-)
	//Hashtable table = new Hashtable();
	EnemyMove enemyMove;
    boss1_new bossMove;
	// Use this for initialization
	void Start () 
    {
		enemy = GetComponent<Enemy>();
        boss = GetComponent<boss1enemy>();
        enemyspeed = enemy.enemyspeed;
        enemyspeed = boss.enemyspeed;
		Hashtable table = new Hashtable();
	}
	
	// Update is called once per frame
	void Update ()
	{
		enemyMove = GetComponent<EnemyMove>();
        bossMove = GetComponent<boss1_new>();
        if (bossMove.find != 1)
        {
            this.transform.position += transform.forward * (enemyspeed * Time.deltaTime);
            if (pattern == 0)
            {
                pattern = 1;
                StartCoroutine("sosaku");
            }
        }
        
	}
	IEnumerator sosaku()
    {
        float x = Random.Range(-1 * Anglebend, Anglebend);
        iTween.RotateTo(this.gameObject, iTween.Hash("y", x, "time", 4.5f));
        yield return new WaitForSeconds(5f);
        float t = Random.Range(2f, 4.5f);
        yield return new WaitForSeconds(t);
        pattern = 0;
	}

}
