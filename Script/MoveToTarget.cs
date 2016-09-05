using UnityEngine;
using System.Collections;
/// <summary>
/// 壁を回避して追ってくるスクリプトです。
/// targetに追う対象を登録して使うです。
/// NavMeshAgentと床の焼き付け的なのを登録しないと意味がないです。
/// ｋｗｓｋは↓のURLにて
/// 参考URL　http://qiita.com/AuraOtsuka/items/f6738963644faae25919
/// </summary>
public class MoveToTarget : MonoBehaviour {
    public Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}