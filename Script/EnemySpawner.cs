using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
　　//ボス戦で武器を所持したザコ敵をスポーンさせるためのもの。
    public Transform[] spawnpoint;
    public GameObject[] spawnenemy;
    int rd,erd,prd;
	// Use this for initialization
	void Start () {
        StartCoroutine("enemyspawner");
	}
	IEnumerator enemyspawner()
    {
        for(;;) {
            rd = UnityEngine.Random.Range(0, 7);
            yield return new WaitForSeconds(10f);
            if (rd == 0)
            {
                prd = UnityEngine.Random.Range(0, spawnpoint.Length + 1);
                erd = UnityEngine.Random.Range(0, spawnenemy.Length+1);
                GameObject obj = GameObject.Instantiate(spawnenemy[erd]) as GameObject;
                obj.transform.position = spawnpoint[prd].position;
                obj.SetActive(true);
            }
        }
    }
	// Update is called once per frame
}
