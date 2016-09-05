using UnityEngine;
using System.Collections;

public class eria : MonoBehaviour {
    GameObject topdown;
    // Use this for initialization
    void Start () {

            topdown = GameObject.Find("PlayerMove");
            Vector3 m_pos = transform.localPosition;
            m_pos.x = this.transform.position.x;
            m_pos.y = this.transform.position.y;
            m_pos.z = this.transform.position.z;
            topdown.transform.localPosition = m_pos;
        Destroy(gameObject);
        // Update is called once per frame
    }
}
