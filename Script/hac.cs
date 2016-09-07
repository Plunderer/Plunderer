
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//画面をタップした際、その場所に敵がいればその敵にマーカーを付加させ、
//形態ごとの効果を発動するスクリプト
//何もない場所をタップした場合かエネルギーゲージがなくなった時は効果が切れる。
public class hac : MonoBehaviour
{
    /// <summary>
    /// カメラをタッチしたかの判定のスクリプト
    /// </summary>
    Quaternion armrotate;
    bool shildarmbool=false;
    PlayerLife playerlife;
    AdvantageShift ads;
    PlayerController playercontroller;
    Ray ray;
    public Camera thiscamera;
    string rayobj;
    GameObject playermove;
    GameObject player;
    public Image rock;
    public GameObject enemy;
    public Vector3 enemyposition;
    public GameObject obj;
    public GameObject shild;
    public bool haconoff = false;
    bool jack = false;
    void Start()
    {
        playermove = GameObject.Find("PlayerMove");
        player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerController>();
        ads = playermove.GetComponent<AdvantageShift>();
        playerlife = playermove.GetComponent<PlayerLife>();
    }
    void Update()
    {
        if (haconoff) {
            if (!obj||playerlife.hacgage<=0)
            {
                playercontroller.rockon = false;
                haconoff = false;
                jack = false;
            }
            else
            {
                enemyposition = thiscamera.WorldToScreenPoint(obj.transform.position);
                rock.enabled = true;
                playercontroller.rockon = true;
                rock.transform.position = new Vector3(enemyposition.x, enemyposition.y, enemyposition.z * -1);
                switch (ads.advantageshift)
                {
                    case 0:
                        playerlife.hacgage -= UnityEngine.Random.Range(0, 3);
                        if (shildarmbool)
                        {
                            shildarmbool = false;
                            shild.SetActive(false);
                        }
                        rockon();
                        break;
                    case 1:
                        playerlife.hacgage -= UnityEngine.Random.Range(0, 4);
                        if (shildarmbool)
                        {
                            shildarmbool = false;
                            shild.SetActive(false);
                        }
                        AIhac();
                        break;
                    case 2:
                        playerlife.hacgage -= UnityEngine.Random.Range(0, 3);
                        baria();
                        break;
                }
            }
        }
        else {
            if (shildarmbool)
            {
                shildarmbool = false;
                shild.SetActive(false);
            }
            playercontroller.rockon = false;
            jack = false;
            rock.enabled = false;
        }
    }
    public void ButtonClick() {
        jack = false;
        ray = thiscamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            obj = hit.collider.gameObject;
            if (obj.tag == "Enemy")

            {
                enemy = obj;
                haconoff = true;
                playercontroller.rockon = true;
            }
            else
            {
                haconoff = false;
                playercontroller.rockon = false;
            }
        }
    }
    void AIhac()
    {
        if(!jack){
            jack = true;
            //ドミネーター形態だった場合、敵を一時的に味方につけるスクリプトを起動する
            enemy.AddComponent<jackenemy>().Hac = this;
        }
    }
    void rockon()
    {
        //ラピッド形態だった場合、自機の向きが敵を向き続けるようになる
        player.transform.LookAt(enemy.transform);
    }
    void baria()
    {
        //タンク形態だった場合、シールドを敵に向け、シールドのスクリプトを起動する。
        shildarmbool = true;
        shild.SetActive(true);
        shild.transform.LookAt(enemy.transform);
    }
}
