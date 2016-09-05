using UnityEngine;
using System.Collections;

public class OpenBlock : MonoBehaviour {
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
