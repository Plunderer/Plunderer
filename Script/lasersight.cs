using UnityEngine;
using System.Collections;

public class lasersight : MonoBehaviour
{
    public LineRenderer lineRenderer = null;
    PlayerController playerController;
    public int wepontype = 0;//0なら搭載兵器1なら状況兵器
    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        if (null != lineRenderer)
        {
            lineRenderer.enabled = false;
            lineRenderer.SetVertexCount(2); // 点の数
        }
    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        if (playerController.wepontype == wepontype) {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
        RaycastHit hit;
        // 正規化して方向ベクトルを求める
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit))
        {

                if (null != lineRenderer)
            {
                //Instantiate(lineRenderer, hit.point, Quaternion.identity);
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
        }
    }
}