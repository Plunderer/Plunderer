using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class misionstart : MonoBehaviour {
	GameObject camera,p1,p2,subcamera,wepon,button1,button2,s;
	PlayerController playerController;
    setumei Setumei;
	float a = 0;
	int i;
	public float camerapositionY = 15f;
	public float camerapositionZ = -9f;
	public float camerarotationX = 60f;
    public Image fede;
	Hashtable table = new Hashtable();

	// Use this for initialization
	void Start () {
        if(fede!=null){
            fede.color = new Color(0, 0, 0, 1);
        }
        camera = GameObject.Find("Main Camera");
        StartCoroutine("start");
        Setumei=gameObject.GetComponent<setumei>();
	}
	IEnumerator start(){
        iTween.RotateTo(camera, iTween.Hash("x", camerarotationX, "time", 0.6f));
        Vector3 pos = camera.transform.position;
        pos.y += camerapositionY;
        pos.z += camerapositionZ;
        iTween.MoveTo(camera, pos, 3f);
        if (fede != null)
        {
            while (a <= 1)//開始時の暗転
            {
                a += 0.02f;
                fede.color = new Color(0, 0, 0, 1 - a);
                yield return null;
            }
        }
		yield return new WaitForSeconds(2.0f);
        fede.enabled = false;
        Setumei.StartCoroutine("setumeikaisi");
        this.GetComponent<misionstart>().enabled = false;
    }
}