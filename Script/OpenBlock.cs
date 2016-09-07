using UnityEngine;
using System.Collections;

public class OpenBlock : MonoBehaviour {
    //フィールドに敵を出し過ぎない為、
    //エリアを抜けるとそれまでの敵を非表示にし、新しく敵を表示する。
    public GameObject openblock;
    public GameObject closeblock;
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            if (closeblock != null)closeblock.SetActive(false);
            if (openblock != null) openblock.SetActive(true);
            Destroy(gameObject);
        }
    }
}
