using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mokutekiti : MonoBehaviour {
	public Transform target;
	public Camera maincamera;
	public Transform playerposision;
	Vector3 gamen,pla;
    bool mainus =false;
    Vector2 vec;
    Quaternion heading;
    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		gamen =target.position;
		pla = playerposision.position;
        vec.x = gamen.x-pla.x;
        vec.y = gamen.z - pla.z;
        heading = Quaternion.FromToRotation(Vector2.up, vec);/*
        if (vec.x < 0)
        {
            heading = Quaternion.FromToRotation(Vector2.down, vec);
        }
        else
        {
            heading = Quaternion.FromToRotation(Vector2.up, vec);
        }*/
        gameObject.transform.rotation = heading;
    }
}
