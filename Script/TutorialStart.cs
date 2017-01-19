using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialStart : MonoBehaviour {
    public Camera[] maincamera = new Camera[2];
    public GameObject image;
    public GameObject[] stage = new GameObject[2];
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("vrstart");
        }
    }
	// Update is called once per frame
    public IEnumerator vrstart(){
        maincamera[1].enabled = true;
        //image[1].enabled = true;
        stage[1].SetActive(true);
        RawImage imageraw =image.GetComponent<RawImage>();
        for (float i = 0; i < 1; i += 0.01f)
        {
            imageraw.color = new Color(1, 1, 1, 1 - i);
            yield return null;
        }
        GameObject imageobj = image as GameObject;
        imageobj.SetActive(false);
        maincamera[0].enabled = false;
        stage[0].SetActive(false);
    }
}
