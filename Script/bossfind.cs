using UnityEngine;
using System.Collections;

public class bossfind : MonoBehaviour
{
    EnemyMove enemyMove;
    boss1_new bossMove;
    GameObject enemy;
    GameObject boss;
    // Use this for initialization
    void Start()
    {
        GameObject enemy = transform.root.gameObject;
        enemyMove = enemy.GetComponent<EnemyMove>();

        GameObject boss = transform.root.gameObject;
        bossMove = boss.GetComponent<boss1_new>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    //GameObject TragetObject = GameObject.FindGameObjectWithTag ("Player");
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            GameObject enemy = gameObject.transform.parent.gameObject;
            GameObject boss = gameObject.transform.parent.gameObject;
            RaycastHit hit;
            // ターゲットオブジェクトとの差分を求め
            Vector3 temp = player.transform.position - enemy.transform.position;
            // 正規化して方向ベクトルを求める
            Vector3 normal = temp.normalized;

            if (Physics.Raycast(enemy.transform.position, normal, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    bossMove.find = 1;
                }
                if (hit.collider.tag == "Playersub")
                {
                    bossMove.find = 1;
                }
            }
            if (Physics.Raycast(boss.transform.position, normal, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    bossMove = boss.GetComponent<boss1_new>();
                    bossMove.find = 1;
                }
                if (hit.collider.tag == "Playersub")
                {
                    bossMove = boss.GetComponent<boss1_new>();
                    bossMove.find = 1;
                }
            }
        }
    }
}
