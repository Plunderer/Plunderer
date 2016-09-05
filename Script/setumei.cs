using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class setumei : MonoBehaviour {
    public Image setumeiimage;
    public Image setumeiimage2;
    public GameObject text;
    public GameObject text2;
    public float readtyme = 2f;
    public bool a = true;
    float i = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (a)
            {
                a = false;
                StartCoroutine("setumeikaisi");
            }
        }
    }
    IEnumerator setumeikaisi()
    {
        i = 0;
        while(i <= 1){
            setumeiimage.fillAmount = i;
            i += 0.1f;
            yield return null;
        }
        text.SetActiveRecursively(true);

        yield return new WaitForSeconds(readtyme);
        text.SetActiveRecursively(false);
        while(i >= 0){
            setumeiimage.fillAmount = i;
            i -= 0.1f;
            yield return null;
        }
        if (setumeiimage2 != null && text2 != null)
        {
            i = 0;
            while (i <= 1)
            {
                setumeiimage2.fillAmount = i;
                i += 0.1f;
                yield return null;
            }
            text2.SetActiveRecursively(true);

            yield return new WaitForSeconds(readtyme);
            text2.SetActiveRecursively(false);
            while (i >= 0)
            {
                setumeiimage2.fillAmount = i;
                i -= 0.1f;
                yield return null;
            }
        }
    }
    
}
