using UnityEngine;
using System.Collections;

public class find : MonoBehaviour
{
    GameObject enemy;
    EnemyPattern enemyPattern;
    EnemyMove enemymove;
    public bool sikakuhantei = true;
    GameObject player;
    int a;
    // Use this for initialization
    void Start()
    {   
        enemy = gameObject.transform.parent.gameObject;
        enemymove = enemy.GetComponent<EnemyMove> ();
        enemyPattern = enemy.GetComponent<EnemyPattern>();
        player = GameObject.Find("PlayerMove");
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemyPattern.find = false;//非発見状態
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if(sikakuhantei){
            if (col.gameObject.tag == "Player")
            {
                //agent.Resume();
                RaycastHit hit;
                // ターゲットオブジェクトとの差分を求め
                Vector3 temp = player.transform.position - enemy.transform.position;
                // 正規化して方向ベクトルを求める
                Vector3 normal = temp.normalized;
                if (Physics.Raycast(enemy.transform.position, normal, out hit))
                {
                    print(hit.collider.tag);
                    if (hit.collider.tag == "Player")
                    {
                        // TargetObjectを見つけた
                        if(!enemyPattern.find){
                            enemyPattern.find = true;//発見状態
                            enemyPattern.patanhandan();
                        }
                    }
                    else
                    {
                        enemyPattern.find = false;//非発見状態
                    }
                }
            }
        }
    }
}
