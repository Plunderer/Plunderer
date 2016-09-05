using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boss1start : MonoBehaviour {
	GameObject p1,p2,subcamera,wepon,button1,button2,s;
	PlayerController playerController;
    PlayerLife pl;
    setumei Setumei;
	float a = 0;
	int i;
    public GameObject moviecamera;
    public GameObject zako;
    public GameObject boss;
    Vector3 cameraposi1;
    boss1_new bosscon;
    float camerapositionY = 23f;
	float camerapositionZ = -13f;
	float camerarotationX = 60f;
    Image fede;
    float time,time2,b;
	Hashtable table = new Hashtable();
    NavMeshAgent agent;
    public GameObject camera;
    public GameObject bossposi1;
    public GameObject fedeobj;
    GameObject adsrevo;
    AudioSource[] BGM;
    bool gatomode = false;
	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(917.59f, -28.71f, 2138.7f);
        camera = GameObject.Find("Main Camera");
        BGM = camera.GetComponents<AudioSource>();
        //gameObject.transform.localPosition = new Vector3(-9.8f, -7f, 107f);
        GameObject.Find("life").GetComponent<Image>().enabled = false;
        GameObject.Find("lifehari").GetComponent<Image>().enabled = false;
        GameObject.Find("ENEvar").GetComponent<Image>().enabled = false;
        GameObject.Find("Change").GetComponent<Image>().enabled = false;
        GameObject.Find("wepontext").GetComponent<Text>().enabled = false;
        GameObject.Find("MobileJoystick").GetComponent<Image>().enabled = false;
        GameObject.Find("MobileJoystick2").GetComponent<Image>().enabled = false;
        GameObject.Find("hacpanel").GetComponent<Image>().enabled = false;
        adsrevo = GameObject.Find("adsrevo");
        adsrevo.SetActive(false);
        StartCoroutine("syutugen");
    }
    void Update()
    {
        cameraposi1 = new Vector3(gameObject.transform.position.x+1, gameObject.transform.position.y+1, gameObject.transform.position.z-3);
        if (gatomode)
        {
            time += Time.deltaTime;
            time2 += Time.deltaTime;
            if (time2 >= 5)
            {
                gatomode = false;
            }
            if (time >= 0.07f)
            {
                time = 0;
                gato();
            }
        }
    }
    IEnumerator syutugen()
    {
        yield return new WaitForSeconds(1.5f);
        camera.SetActive(false);
        while (b <= 1)
        {
            b += 0.01f;
            GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 1.5f, ForceMode.VelocityChange);
            moviecamera = GameObject.Find("MoivieCamera");
            moviecamera.transform.LookAt(gameObject.transform.position);
            fedeobj = GameObject.Find("fede");
            fede = fedeobj.GetComponent<Image>();
            fede.color = new Color(0, 0, 0, 1 - b);
            yield return null;
        }
        for (int i = 0; i <60 ; i++)
        {
            GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 1.5f, ForceMode.VelocityChange);
            moviecamera.transform.LookAt(gameObject.transform.position);
            yield return null;
        }
        iTween.MoveTo(moviecamera, cameraposi1, 3f);
        zako = GameObject.Find("zako");
        for (int i = 0; i < 270; i++)
        {
            moviecamera.transform.LookAt(zako.transform.position);
            yield return null;
        }
        boss = GameObject.Find("boss");
        Vector3 pos = boss.transform.position;
        pos.x -= 13;
        agent = boss.GetComponent<NavMeshAgent>();
        bossposi1 = GameObject.Find("bossposi1");
        agent.SetDestination(bossposi1.transform.position);
        Camera camerrua = moviecamera.GetComponent<Camera>();
        yield return new WaitForSeconds(2.8f);
        agent.SetDestination(boss.transform.position);
        for (int i = 0; i < 10; i++)//ボス見つつズームイン
        {
            moviecamera.transform.LookAt(boss.transform.position);
            camerrua.fieldOfView -= 2.5f;
            yield return null;
        }
        for (int i = 0; i < 90; i++)
        {
            moviecamera.transform.LookAt(boss.transform.position);
            Vector3 relativePos = gameObject.transform.position - boss.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            boss.transform.rotation = Quaternion.Slerp(boss.transform.rotation, rotation, Time.deltaTime * 15f);
            yield return null;
        }
        bosscon = boss.GetComponent<boss1_new>();
        bosscon.sound02.PlayOneShot(bosscon.sound02.clip);
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 2; i++)
        {
            camerrua.fieldOfView += 12.5f;//カメラがズームアウトする（早）
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().AddForce(gameObject.transform.right * 400, ForceMode.VelocityChange);
        gatomode = true;
        yield return new WaitForSeconds(4f);
        iTween.MoveTo(moviecamera, cameraposi1, 3f);
        moviecamera.SetActive(false);
        camera.SetActive(true);
        BGM[0].Stop();
        BGM[1].Play();
        StartCoroutine("start");
    }
    IEnumerator start(){
        boss.GetComponent<boss1_new>().enabled = true;
        iTween.RotateTo(camera, iTween.Hash("x", camerarotationX, "time", 0.6f));
        Vector3 pos = camera.transform.position;
        pos.y += camerapositionY;
        pos.z += camerapositionZ;
        iTween.MoveTo(camera, pos, 3f);
        fede.enabled = false;
        GetComponent<PlayerLife>().enabled = true;
        yield return new WaitForSeconds(3.5f);
        GameObject.Find("life").GetComponent<Image>().enabled = true;
        GameObject.Find("lifehari").GetComponent<Image>().enabled = true;
        GameObject.Find("ENEvar").GetComponent<Image>().enabled = true;
        GameObject.Find("Change").GetComponent<Image>().enabled = true;
        GameObject.Find("wepontext").GetComponent<Text>().enabled = true;
        GameObject.Find("MobileJoystick").GetComponent<Image>().enabled = true;
        GameObject.Find("MobileJoystick2").GetComponent<Image>().enabled = true;
        GameObject.Find("hacpanel").GetComponent<Image>().enabled = true;
        adsrevo.SetActive(true);
        this.GetComponent<boss1start>().enabled = false;
    }
    void gato()
    {
        GameObject obj = GameObject.Instantiate(bosscon.Gato) as GameObject;
        GameObject obj2 = GameObject.Instantiate(bosscon.Gato) as GameObject;
        obj.transform.position = bosscon.spawn.position;
        obj2.transform.position = bosscon.spawn2.position;
        float X = UnityEngine.Random.Range(1, 2);
        int mainas = UnityEngine.Random.Range(0, 2);
        if (mainas == 0)
        {
            mainas = -1;
        }
        else
        {
            mainas = 1;
        }
        obj.GetComponent<Rigidbody>().AddForce(
            (bosscon.rifle.forward + bosscon.rifle.right / (X * mainas)) * 500 * 2);
        obj2.GetComponent<Rigidbody>().AddForce(
            (bosscon.rifle.forward + bosscon.rifle.right / (X * mainas)) * 500 * 2);
        float Y = UnityEngine.Random.Range(1, 3);
        mainas = UnityEngine.Random.Range(0, 2);
        if (mainas == 0)
        {
            mainas = -1;
        }
        else
        {
            mainas = 1;
        }
        obj.GetComponent<Rigidbody>().AddForce(
            (bosscon.rifle.forward + bosscon.rifle.right / (Y * mainas)) * 500 * 2);
        obj2.GetComponent<Rigidbody>().AddForce(
            (bosscon.rifle.forward + bosscon.rifle.right / (Y * mainas)) * 500 * 2);
        bosscon.sound01.PlayOneShot(bosscon.sound01.clip);
    }
}