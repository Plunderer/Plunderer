using UnityEngine;
using System.Collections;

public class revoads2 : MonoBehaviour {
    /// <summary>
    /// アドバンテージシフトの新しい切り替え方法です。
    /// リボルバーを横にスライドさせることで形態が変更する仕組みになっています。
    /// "60度"画像が回り、形態が変わります。
    /// "0=機動型＜ーー＞1=攻撃型＜ーー＞2=防御型"
    /// という流れで形態を変更します。
    /// </summary>
    float[] touchposition = new float[3];
    AdvantageShift advantageshift;
    int touchcode = -1,id = -1;
    Animator animator;
    public GameObject plunderer;
    PlayerController pl;
    public int tutolial = 3;
	bool revoanim =false;
	int oldads = 1;
    void Start()
    {
        pl = GameObject.Find("Player").GetComponent<PlayerController>();
        animator = plunderer.GetComponent<Animator>();
        GameObject ads = GameObject.Find("PlayerMove");
        advantageshift = ads.GetComponent<AdvantageShift>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch t in Input.touches)
        {
            id = t.fingerId;
            switch (t.phase)
            {
                case TouchPhase.Began:
                    if ((Input.touches[id].position.x >= gameObject.transform.position.x - 300 && Input.touches[id].position.x <= gameObject.transform.position.x + 300) &&
                        (Input.touches[id].position.y >= gameObject.transform.position.y - 300 && Input.touches[id].position.y <= gameObject.transform.position.y + 300))
                    {
                        touchposition[0] = Input.touches[id].position.x;
                        touchcode = id;
                    }
                    touchposition[2] = touchposition[1];
                    break;
            }
        }
        if (touchcode != -1)
        {
            switch (Input.GetTouch(touchcode).phase)
            {
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    touchmove();
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    StartCoroutine(touchend());
                    break;
            }
        }
      /*
        if (Input.GetMouseButtonDown(0))
        {
            if ((Input.mousePosition.x >= gameObject.transform.position.x - 300 && Input.mousePosition.x <= gameObject.transform.position.x + 300) &&
                (Input.mousePosition.y >= gameObject.transform.position.y - 300 && Input.mousePosition.y <= gameObject.transform.position.y + 300))
            {
                touchposition[0] = Input.mousePosition.x;
                touchcode = id;
            }
            touchposition[2] = touchposition[1];
            
            touchcode = id;
        }
        if (Input.GetMouseButton(0))
        {
            touchmove();
        }
        if (Input.GetMouseButtonUp(0))
        {
            touchend();
        }*/
    }
    void touchmove()
    {
        if (!pl.stop&&!revoanim){
            //押されている間
            touchposition[1] = ((touchposition[0] - Input.touches[touchcode].position.x) / 2.5f) + touchposition[2];
            //touchposition[1] = ((touchposition[0] - Input.mousePosition.x) / 2.5f) + touchposition[2];
            touchposition[1] = Mathf.Clamp(touchposition[1], -90, 90);
            transform.rotation =
                Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y,
                touchposition[1]
            );
        }
    }
    IEnumerator touchend()
    {
		if (!pl.stop&&!revoanim)
        {
            //離した時
            if (touchposition[1] < -30 && tutolial >= 2)
            {
				revoanim = true;
                //形態が0（機動型）
                
                iTween.RotateTo(this.gameObject, iTween.Hash(
                    "z", -60, "time", 0.3f
                ));
                touchposition[1] = -60;
				if (oldads != advantageshift.advantageshift) {
					animator.SetInteger("ads_code", 0);
					advantageshift.advantageshift = -1;//一度変形中形態にする
					////////ここに変形モーションを入れる////////
					yield return new WaitForSeconds(2);
					advantageshift.advantageshift = 0;
				}

				revoanim = false;
				oldads = 0;
            }
            else if (touchposition[1] > 30 && tutolial >= 1)
            {
				revoanim = true;
                //形態が2（防御型）

				iTween.RotateTo(this.gameObject, iTween.Hash(
					"z", 60, "time", 0.3f
				));
				touchposition[1] = 60;
				if (oldads != advantageshift.advantageshift) {
					animator.SetInteger("ads_code", 2);
					advantageshift.advantageshift = -1;//一度変形中形態にする
					////////ここに変形モーションを入れる////////
					yield return new WaitForSeconds(2);
					advantageshift.advantageshift = 2;
				}
				revoanim = false;
				oldads = 1;
            }
            else
            {
				revoanim = true;

				iTween.RotateTo(this.gameObject, iTween.Hash(
					"z", 0, "time", 0.3f
				));
				touchposition[1] = 0;
				//形態が1（攻撃型）
				if (oldads != advantageshift.advantageshift) {
					animator.SetInteger("ads_code", 1);
					advantageshift.advantageshift = -1;//一度変形中形態にする
					////////ここに変形モーションを入れる////////
					yield return new WaitForSeconds (2);
					advantageshift.advantageshift = 1;
				}
                
				revoanim = false;
				oldads = 2;
            }
            if (touchcode != -1)
            {
                touchcode = -1;
                id = -1;
                touchposition[0] = 0;
            }
        }
    }
}
