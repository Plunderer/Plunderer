using UnityEngine;
using System.Collections;

public class sokusizako : MonoBehaviour 
{
    public GameObject explosion;    //爆発エフェクト
    public void Damage ( float damage ) 
    {
        GameObject.Instantiate(explosion, transform.position, Quaternion.identity); //爆発パーティクルを生成
        Destroy(this.gameObject);   //自身を削除
    }
}