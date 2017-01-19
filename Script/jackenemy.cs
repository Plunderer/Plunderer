using UnityEngine;
using System.Collections;

public class jackenemy : MonoBehaviour {
    EnemyPattern enemyPattern;
    haikai Haikai;
    Enemy en;
    EnemyMove enemyMove;
    NavMeshAgent agent;
    Transform enemy;
    public hac Hac;
    AdvantageShift ads;
    bool haikai = false, patan = false,agiento = false;
	// Use this for initialization
	void Start () {
        en = gameObject.GetComponent<Enemy>();
        if (en == null) gameObject.GetComponent<boss1enemy>(); 
        enemyPattern = gameObject.GetComponent<EnemyPattern>();
        ads = GameObject.Find("PlayerMove").GetComponent<AdvantageShift>();
        if (gameObject.GetComponent<EnemyPattern>())
        {
            patan = true;
        }
        //this.tag = ("Player");
        enemyPattern.player = serchTag(gameObject, "Enemy").transform;
	}
	
	// Update is called once per frame
    void Update()
    {
        enemyPattern.find = true;
        if (en.stunlife >1&&UnityEngine.Random.Range(0, 10) == 0) gameObject.SendMessage("stunDamage", 1); 
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
