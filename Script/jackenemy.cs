using UnityEngine;
using System.Collections;

//デトネーター形態の時、タップされた敵を一時的に味方につけるスクリプト
//発動中はタップした敵のtagをEnemyからPlayerに切り替え、他の敵からも狙われるようにし、
//さらに攻撃対象をPlayerから発動時一番近いEnemyをターゲットとすることで同士討ちを狙わせる。
public class jackenemy : MonoBehaviour {
    EnemyPattern enemyPattern;
    haikai Haikai;
    EnemyMove enemyMove;
    NavMeshAgent agent;
    Transform enemy;
    public hac Hac;
    AdvantageShift ads;
    bool haikai = false, patan = false,agiento = false;
	// Use this for initialization
	void Start () {
        enemyPattern = gameObject.GetComponent<EnemyPattern>();
        ads = GameObject.Find("PlayerMove").GetComponent<AdvantageShift>();
        if (gameObject.GetComponent<EnemyPattern>())
        {
            patan = true;
        }
        this.tag = ("Player");
        enemyPattern.player = serchTag(gameObject, "Enemy").transform;
	}
	
	// Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<EnemyPattern>().find = true;
        if (!Hac.haconoff || ads.advantageshift != 1)
        {
            enemyPattern.find = false;
            enemyPattern.player = GameObject.FindGameObjectWithTag("Player").transform;
            this.tag = ("Enemy");
            Destroy(this);
        }
    }
    
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}
