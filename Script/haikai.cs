using UnityEngine;
using System.Collections;

public class haikai: MonoBehaviour {

	public Transform[] wayPoints;

	NavMeshAgent agent = null;

	public int currentRoot;
    Animator anim;
    // Use this for initialization
    void Start () {
		agent = GetComponent<NavMeshAgent>();
        anim = transform.FindChild("easyenemy_v_007_LOD2").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = wayPoints[currentRoot].position;
        anim.SetBool("enemymove", true);
        if (Vector3.Distance(transform.position, pos) < 2f)
		{

			currentRoot = (currentRoot < wayPoints.Length - 1) ? currentRoot + 1 : 0;
            
		}

		agent.SetDestination(pos);

		//GetComponent<NavMeshAgent>().SetDestination(pos);
	}
}
