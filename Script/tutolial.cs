using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tutolial : MonoBehaviour {
    public int mode = 0;
    public Image[] img = new Image[1];
    public GameObject obj;
    public GameObject chaya;
	public GameObject[] enemy = new GameObject[1];
    public Transform target;
    public bool talkbool = true;
    public bool talkeve = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (enemy.Length != 0){
            if (mode == 3&&enemy[0] == null)
            {
                if (talkeve == true)
                {
					obj.SetActive(true);
                    GetComponent<talk>().talkstart();
                    talkbool = false;
                    talkeve = false;
                }
                else if (talkbool == true)
                {
                    chaya.SetActive(false);
                    Destroy(this);
                }
            }
            else if (mode == 5&&enemy[0] == null && enemy[1] == null &&
                   enemy[2] == null)
            {
                if (talkeve == true)
                {
					obj.SetActive(true);
					GameObject.Find("adsrevo").GetComponent<revoads2>().tutolial = 1;
                    GetComponent<talk>().talkstart();
                    talkbool = false;
                    talkeve = false;
                }
                else if (talkbool == true)
                {
                    enemy[3].SetActive(true);
                    Destroy(this);
                }
            }
            else if ((mode == 6 || mode == 7)&&enemy[0] == null && enemy[1] == null &&
                   enemy[2] == null && enemy[3] == null )
            {
                if (talkeve == true)
                {
					if (mode == 6) {
						obj.SetActive (true);
						GameObject.Find ("adsrevo").GetComponent<revoads2> ().tutolial = 2;
					}
                    GetComponent<talk>().talkstart();
                    talkbool = false;
                    talkeve = false;
                }
                else if (talkbool == true)
                {
                    enemy[4].SetActive(true);
                    Destroy(this);
                }
            }
            else if (mode == 8&&enemy[0] == null )
            {
                if (talkeve == true)
                {
                    GetComponent<talk>().talkstart();
                    talkbool = false;
                    talkeve = false;
                }
                else if (talkbool == true)
                {
                    Destroy(this);
                }
            }
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player"){
            if (GetComponent<talk>() != false) GetComponent<talk>().talkstart();
            if (target != null) GameObject.Find("compustarget").GetComponent<mokutekiti>().target = target;
            switch (mode)
            {
                case 0:
                    for (int i = 0; i < img.Length; i++) img[i].enabled = true;
                    break;
                case 1:
                    obj.SetActive(true);
                    break;
                case 2:
                    obj.SetActive(true);
                    enemy[0].SetActive(true);
                    break;
                case 3:
                    obj.SetActive(true);
                    break;
                case 4:
                    //変形
                    obj.SetActive(true);
                    enemy[1].SetActive(true);
                    GameObject.Find("adsrevo").GetComponent<revoads2>().tutolial = 0;
                    break;
                case 5:
                    //タンク表示
                    obj.SetActive(true);
                    GameObject.Find("adsrevo").GetComponent<revoads2>().tutolial = 1;
                    break;
                case 6:
                    //ラピッド表示
                    obj.SetActive(true);
                    GameObject.Find("adsrevo").GetComponent<revoads2>().tutolial = 2;
                    break;
                case 7:
                    //最後
                    GameObject.Find("adsrevo").GetComponent<revoads2>().tutolial = 3;
                    break;
            }
        }
    }
}
