using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
public class PlayerLife : MonoBehaviour {
	AdvantageShift    advantageshift;
	public float maxLife = 100;    //最大体力（readonlyは変数の変更ができなくなる）
	public float life = 100;    //現在体力
    public int hacgage = 0;
    public int MAXhacgage = 1000;
    private static bool isQuitting = false;
	private float gaugeMax;
	private float gaugeNow;
	Transform t;
	private GUIStyle style;
	private AudioSource sound01,sound02,sound03,sound04;
	float bruntime,brundamage2,time;
	float adsd = 1,adsh=1;
    AudioSource bgm_se;
    public GameObject explosion1, explosion2;
    public Image fede;
    bool gameoverbool = false;
    public GameObject maincamera;
    // Use this for initialization
    void Start () {
        GameObject ads = GameObject.Find ("PlayerMove");
		advantageshift = ads.GetComponent<AdvantageShift> ();
		style = new GUIStyle();
		style.fontSize = 100;
		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound01 = audioSources[1];
		sound02 = audioSources[2];
        sound03 = audioSources[3];
        sound04 = audioSources[4];
        if (life <= 0) {
			life = maxLife; //体力を全回復させる
			t = transform.FindChild("Controller");
		}
	}
	
	// Update is called once per frame

	void Update () {
        float horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        if (advantageshift.advantageshift == 0 || advantageshift.advantageshift == -1)
        {
            adsd = 1.2f;
            adsh = 1f;
        }
		else if (advantageshift.advantageshift == 1) {
			adsd = 1f;
            adsh = 1.5f;
		}else if (advantageshift.advantageshift == 2) {
			adsd = 0.7f;
            adsh = 1f;
        }
		time += Time.deltaTime;
		if (time >= 1) {
            if (horizontal == 0 && vertical == 0)
            {
                if (life < 30) {
                    life ++;
                }
                if (hacgage < 1000)
                {
                    hacgage += 10;
                }
                else
                {
                    hacgage = 1000;
                }
            }
			if (bruntime > 0) {
				life -= brundamage2/1.3f;
				bruntime -= 1;
			}
			time = 0;
		}
		//体力が0になったら
		if (life <= 0&&!gameoverbool) {
            gameoverbool = true;
            StartCoroutine("gameover");
		} else if (life >= maxLife) {
			life = maxLife;
		}
	}

	public void Damage (float damage) {
		sound01.PlayOneShot (sound01.clip);
        shake(damage);
		life -= Mathf.Round((damage * adsd)); //体力を減らす
	}
	public void heal (float heal) {
		sound02.PlayOneShot (sound02.clip);
		life += Mathf.Round(heal); //体力を増やす
        adsh = 1.5f;
	}
	public void brundamage ( float brundamage ) {
		bruntime = 3;
		brundamage2 = Mathf.Ceil(brundamage);
	}
    IEnumerator gameover()
    {
        GameObject obj = GameObject.Instantiate(explosion1) as GameObject;
        obj.transform.position = transform.position;
        sound03.PlayOneShot(sound03.clip);
        yield return new WaitForSeconds(1.0f);
        GameObject obj2 = GameObject.Instantiate(explosion1) as GameObject;
        obj2.transform.position = transform.position;
        sound03.PlayOneShot(sound03.clip);
        yield return new WaitForSeconds(1.3f);
        GameObject obj3 = GameObject.Instantiate(explosion2) as GameObject;
        obj3.transform.position = transform.position;
        sound04.PlayOneShot(sound04.clip);
        fede.enabled = true;
        float a = 0;
        while (a < 1)//開始時の暗転
        {
            a += 0.045f;
            fede.color = new Color(1, 1, 1, a);
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("title");
    }
    void shake(float Damage_)
    {
        iTween.ShakeRotation(maincamera, iTween.Hash("x", Damage_/10, "y", Damage_/10, "time", Damage_ / 8));
        
    }
}