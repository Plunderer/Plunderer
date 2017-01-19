using UnityEngine;
using System.Collections;

public class EnemyPattern : MonoBehaviour {
    /// <summary>
    /// 敵の行動パターンのスクリプト
    /// </summary>
    public enum Enemytype//敵の種類
    {
        Fixing,             //固定砲台
        Rotation,           //自動砲台
        TrackingWait,       //待機追跡型
        AwayWait,           //待機離反型
        Patrol,             //巡回追跡型
        PatrolAway,         //巡回離反型
        DestructPatrol,     //巡回自爆型
        DestructTracking,   //追跡自爆型
    };
    Vector3 enemytransform;
    public Enemytype enemytype;//敵の行動パターン
	public Transform player;//Topdownを入れる（プレイヤーの座標）
	EnemyMove enemyMove;
	Enemy enemy;
    NavMeshAgent agent;
    public GameObject bomb;//自爆のゲームオブジェクト
    public bool find = false;
    float time;
    public float rimittime;
    haikai Haikai;
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = transform.FindChild("easyenemy_v_007_LOD2").GetComponent<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        Haikai = GetComponent<haikai>();
        if (!Haikai.enabled && (enemytype == Enemytype.Fixing || enemytype == Enemytype.Rotation))
        {
            agent.enabled = false;
        }
        enemy = gameObject.GetComponent<Enemy>();
        enemytransform = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMove = gameObject.GetComponent<EnemyMove>();
    }
    public void patanhandan () {
        if (!enemyMove.shotPermit)
        {
            switch (enemytype)
            {
                //enumクラス名.文字列でアクセスする
                case Enemytype.Fixing:
                    StartCoroutine("Fixing");
                    break;
                case Enemytype.Rotation:
                    StartCoroutine("Rotation");
                    break;
                case Enemytype.Patrol:
                    StartCoroutine("Patrol");
                    break;
                case Enemytype.DestructPatrol:
                    StartCoroutine("DestructPatrol");
                    break;
                case Enemytype.TrackingWait:
                    StartCoroutine("TrackingWait");
                    break;
                case Enemytype.AwayWait:
                    StartCoroutine("AwayWait");
                    break;
                case Enemytype.DestructTracking:
                    StartCoroutine("DestructTracking");
                    break;
                case Enemytype.PatrolAway:
                    StartCoroutine("PatrolAway");
                    break;
                default:

                    break;
            }
        }
	}
    IEnumerator Fixing()
    {
        //固定砲台
        anim.SetBool("enemymove", false);
        enemyMove.shotPermit = true;//射撃を開始させる（ただenemyMoveをすこし改変しているためこのままでは動かない）
        yield return new WaitForSeconds(5.0f);
        enemyMove.shotPermit = false;//射撃を停止させる（ただenemyMoveをすこし改変しているためこのままでは動かない）
        if (find)
        {
            StartCoroutine("Fixing");
        }
    }
    IEnumerator Rotation()
    {
        //自動砲台
        anim.SetBool("enemymove", false);
        enemyMove.shotPermit = true;//射撃を開始させる（ただenemyMoveをすこし改変しているためこのままでは動かない）
        for (int i = 0; i < rimittime*60; i++)//設定した時間（rimittime）分だけ繰り返す
        {
            Vector3 newRotation = Quaternion.LookRotation(player.position - transform.position).eulerAngles;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), agent.angularSpeed / 180);
            yield return null;
            //transform.LookAt(new Vector3 (player.position.x,transform.position.y,player.position.z));   //プレイヤーの方を向き続ける
        }
        enemyMove.shotPermit = false;//射撃を停止させる（ただenemyMoveをすこし改変しているためこのままでは動かない）
        if (find)
        {
            StartCoroutine("Rotation");//まだプレイヤーが視覚にいた場合再度射撃を開始
            yield break;
        }
    }
    IEnumerator Patrol()
    {
        //巡回追跡型
        anim.SetBool("enemymove", true);
        gameObject.GetComponent<haikai>().enabled = false;//巡回のスクリプトの停止
        enemyMove.shotPermit = true;//射撃を開始する（ただenemyMoveをすこし改変しているためこのままでは動かない）
        int j = 0;
        while (j< rimittime * 60)//設定した時間（rimittime）分だけ繰り返す
        {
            agent.SetDestination(player.position);//navimeshagentを利用して壁や落下を回避してプレイヤーを追跡
            if (!find) {
                j++;
            }
            else
            {
                j = 0;
            }
            yield return null;
        }
        enemyMove.shotPermit = false;//射撃を停止させる（ただenemyMoveをすこし改変しているためこのままでは動かない）
        gameObject.GetComponent<haikai>().enabled = true;//巡回のスクリプトを再起動する
    }
    /*IEnumerator DestructPatrol()
    {
        //追跡自爆型
        for (;;)
        {
            agent.SetDestination(player.position);//navimeshagentを利用して壁や落下を回避してプレイヤーを追跡
            //自爆のとこ
            if (Vector3.Distance(transform.position, player.position) > 1.5f)
            {
                //自爆のとこ
                bomb.transform.position = enemytransform;
                Destroy(gameObject);
            }
            yield return null;
        }
    }*/
    IEnumerator TrackingWait(){
        //待機追跡型
        anim.SetBool("enemymove", true);
        enemyMove.shotPermit = true;//射撃を開始する（ただenemyMoveをすこし改変しているためこのままでは動かない）
        int k = 0;
        while (k < rimittime * 60)//設定した時間（rimittime）分だけ繰り返す
        {
            agent.SetDestination(player.position);//navimeshagentを利用して壁や落下を回避してプレイヤーを追跡
            if (!find)
            {
                k++;
            }
            else
            {
                k = 0;
            }
            yield return null;
        }
        enemyMove.shotPermit = false;//射撃を停止させる（ただenemyMoveをすこし改変しているためこのままでは動かない）
        while (Vector3.Distance(transform.position, enemytransform) > 1.5f)//元の配置に戻る
        {
            agent.SetDestination(enemytransform);//navimeshagentを利用して壁や落下を回避してプレイヤーを追跡
            if (find)//途中でプレイヤーを発見した場合、再度射撃へ移行
            {
                StartCoroutine("TrackingWait");
                yield break;
            }else
            {
                anim.SetBool("enemymove", false);
            }
        }
    }
    IEnumerator AwayWait() {
        //待機離反型
        enemyMove.shotPermit = true;//た(ry
        anim.SetBool("enemymove", true);
        int l = 0;
        while (l < rimittime * 60)//設定した時間（rimittime）分だけ繰り返す
        {
            //transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));   //プレイヤーの方を向き続ける;   //プレイヤーの方を向く
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(player.position - transform.position), agent.angularSpeed/180);
			this.transform.position -= transform.forward * (Time.deltaTime*agent.speed);//プレイヤーから距離を取る
            if (!find) {
                l++;
            }
            else
            {
                l = 0;
            }
            yield return null;
        }
        enemyMove.shotPermit = false;//射撃を停止させる（ただenemyMoveをすこし改変しているためこのままでは動かない）
        while (Vector3.Distance(transform.position, enemytransform) > 1.5f)//元の場所へ移動
        {
            agent.SetDestination(enemytransform);//navimeshagentを利用して壁や落下を回避してプレイヤーを追跡
            if (find)//プレイヤーを発見した場合再度射撃へ移行
            {
                StartCoroutine("AwayWait");
                yield break;
            }else
            {
                anim.SetBool("enemymove", false);
            }
        }
    }
    IEnumerator DestructTracking()
    {
        //巡回自爆型
        anim.SetBool("enemymove", true);
        gameObject.GetComponent<haikai>().enabled = false;//巡回を停止
        for (; ;)//死ぬまで追いかける自爆モード
        {
            if (Vector3.Distance(transform.position, player.position) > 1.0f)//プレイヤーが近い場合自爆
            {
                //自爆のとこ
                bomb.transform.position = enemytransform;
                Destroy(gameObject);
            }
            yield return null;
        }
    }
    IEnumerator PatrolAway()
    {
        //巡回離反型
        anim.SetBool("enemymove", true);
        gameObject.GetComponent<haikai>().enabled = true;
        enemyMove.shotPermit = true;//た(ry
        int m = 0;
        while (m < rimittime * 60)//設定した時間（rimittime）分だけ繰り返す
        {
            time += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(player.position - transform.position), agent.angularSpeed / 180);
            this.transform.position -= transform.forward * (agent.speed * Time.deltaTime);//プレイヤーから距離を取る
            if (!find)
            {
                m++;
            }
            else
            {
                m = 0;
            }
            yield return null;
        }
        enemyMove.shotPermit = false;//射撃を停止させる（ただenemyMoveをすこし改変しているためこのままでは動かない）
        gameObject.GetComponent<haikai>().enabled = true;
    }
}
