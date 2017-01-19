
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public Sprite[] rockonsprite = new Sprite[2];
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
						if(UnityEngine.Random.Range(0, 3) == 0)playerlife.hacgage-- ;
                        if (shildarmbool)
                        {
                            shildarmbool = false;
                            shild.SetActive(false);
                        }
                        rockon();
                        break;
                    case 1:
					if(UnityEngine.Random.Range(0, 3) == 0)playerlife.hacgage-- ;
                        if (shildarmbool)
                        {
                            shildarmbool = false;
                            shild.SetActive(false);
                        }
                        AIhac();
                        break;
                    case 2:
					if(UnityEngine.Random.Range(0, 3) == 0)playerlife.hacgage-- ;
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
            Debug.Log(hit);
            obj = hit.collider.gameObject;
            if (obj.tag == "Enemy")
            {
                switch (ads.advantageshift)
                {
                    case 0:
                        rock.sprite = rockonsprite[0];
                        break;
                    case 1:
                        rock.sprite = rockonsprite[1];
                        break;
                    case 2:
                        rock.sprite = rockonsprite[2];
                        break;
                    default:
                        break;
                }
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
            enemy.AddComponent<jackenemy>().Hac = this;
        }
    }
    void rockon()
    {
        player.transform.LookAt(enemy.transform);
    }
    void baria()
    {
        shildarmbool = true;
        shild.SetActive(true);
        shild.transform.LookAt(enemy.transform);
    }
}
