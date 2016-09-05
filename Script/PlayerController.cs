using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
/// <summary>
/// 若かりし頃の過ちであった。
/// 主人公の向きと射撃を行います。
/// </summary>
public class PlayerController : MonoBehaviour {
    public GameObject muzzleflash1;    //マズルフラッシュ
    public GameObject muzzleflash2;    //マズルフラッシュ
    public float rotationSpeed = 450;
	private Quaternion targetRotation;
	public float insidegun = 0;
	public float outsidegun = 0;
	public float wepontype = 1;
	public GameObject riflebullet;
	public GameObject shotbullet;
	public GameObject Laser;
	public GameObject EagleEye;
	public GameObject misa;
	public GameObject Pulsemisa;
	public GameObject BounceRevolver;
	public GameObject UCriflebullet;
	public GameObject burner;
	public GameObject Gasogre;
	public GameObject Gato;
	public GameObject Voltaic;
	public GameObject Machinbullet;
	public GameObject nextbullet;
	public GameObject Tetlabullet;
	public GameObject bazz;
	public GameObject moa;
	public GameObject heby;
	public GameObject roke;
	public GameObject loki;
	public GameObject Railgun;
	public GameObject PileBunker;
    public GameObject Shockwave;
    public GameObject comet;
    public GameObject canon;
    public GameObject heatknife;
    public GameObject takedown;
    public GameObject heatjunk;
    public GameObject barista;
    public GameObject flugG;
    public GameObject ribettgun;
    public GameObject surabure;
    public Transform spawn;
	public Transform spawn2;
	public float speed = 1000f;
	private AudioSource sound01;
	private AudioSource sound02;
	private AudioSource sound03;
	private AudioSource sound04;
	private AudioSource sound05;
    private AudioSource sound06;
    private AudioSource sound07;
    public GameObject wmachingun;
	public GameObject wLaser;
	public GameObject wshotgun;
	public GameObject wEagleEye;
	public GameObject wmisa;
	public GameObject wPulsemisa;
	public GameObject wBounceRevolver;
	public GameObject wUCriflebullet;
	public GameObject wburner;
	public GameObject wGasogre;
	public GameObject wGato;
	public GameObject wVoltaic;
	public GameObject wScutum;
	public GameObject wrapid;
    public GameObject wHighcanon;
    public GameObject wSurabure;
    Vector3 armrotate;
    public float ammo;
	public float MAXammo;
	public float MAXammo2;
	private GUIStyle style;
    public bool rockon = false;
    
	//以下修正された変数
	public Transform rifle; //搭載兵器（弾無限の方の武器）
    public Transform rifle2; //状況兵器（弾に限ろがある方の武器）
	private float time = 0f;    //経過時間
	private float time2 = 0f;    //経過時間
	private float time3 = 0f;    //経過時間
	public float interval = 0.2f;   //何秒おきに発砲するか
	public float getgun;
    int mainas;
	float a, b ,c,revot,X,Y,adsr, chagesound;
	AdvantageShift    advantageshift;
    GameObject ads;
    int revo = 0;
    EffekseerEmitter effekseerEmitter1, effekseerEmitter2;
    Animator animator;
    public GameObject plunderer;
    // Use this for initialization
    void Start () {
        animator = plunderer.GetComponent<Animator>();
        effekseerEmitter1 = muzzleflash1.GetComponent<EffekseerEmitter>();
        effekseerEmitter2 = muzzleflash2.GetComponent<EffekseerEmitter>();
        ads = GameObject.Find ("PlayerMove");
		advantageshift = ads.GetComponent<AdvantageShift> ();
		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound01 = audioSources[0];
		sound02 = audioSources[1];
		sound03 = audioSources[2];
		sound04 = audioSources[3];
		sound05 = audioSources[4];
        sound06 = audioSources[5];
        sound07 = audioSources[6];

    }
	
	// Update is called once per frame
	void Update () {
		if (a != wepontype) {
			a = wepontype;
			b = insidegun;
			c = outsidegun;
			weponDisplay ();
		}
		if (b != insidegun) {
			a = wepontype;
			b = insidegun;
			c = outsidegun;
			weponDisplay ();
		}
		if (c != outsidegun) {
			a = wepontype;
			b = insidegun;
			if (c != 0){
				getgun += 1;
			}else{
				getgun = 0;
			}
			c = outsidegun;
			weponDisplay ();
		}
		if (ammo <= 0){
			outsidegun = 0;
			wepontype = 1;
			ammo = 0;
			a = wepontype;
			b = insidegun;
			c = outsidegun;
			weponDisplay ();
		}
        if (wepontype == 1)
        {
            animator.SetBool("outside", false);
        }
        else
        {
            animator.SetBool("outside", true);
        }
		if (advantageshift.advantageshift == 3) {
			adsr = 0.8f;
		} else {
			adsr = 1;
		}
		if (ammo >= MAXammo) {
			ammo = MAXammo;
		}
		time += Time.deltaTime;
		Vector3 input = new Vector3 (CrossPlatformInputManager.GetAxisRaw ("Horizontal2"), 0, CrossPlatformInputManager.GetAxisRaw ("Vertical2"));
		Vector3 input2 = new Vector3 (CrossPlatformInputManager.GetAxisRaw ("Horizontal"), 0, CrossPlatformInputManager.GetAxisRaw ("Vertical"));
		if (input != Vector3.zero) {
			time2 += Time.deltaTime;
            if (rockon == false || advantageshift.advantageshift != 0)
            {
			    targetRotation = Quaternion.LookRotation (input);
			    transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
            }
			if (time2 >= 0.3f) {
				time3 += Time.deltaTime;
                if (wepontype == 1)
                {
                    animator.SetBool("outside",false);
                    if (insidegun == 0)
                    {
                        //インサイドガン
                        if (time >= 0.35f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(riflebullet) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 1.7f);
                            effekseerEmitter1.Play();
                            time = 0f;  //初期化
                            sound01.PlayOneShot(sound01.clip);
                        }
                    }
                    else if (insidegun == 1)
                    {
                        //レーザーライフル
                        if (time >= 0.7f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(Laser) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 3f);
                            time = 0f;  //初期化
                            sound04.PlayOneShot(sound04.clip);
                            effekseerEmitter1.Play();
                        }
                    }
                    else if (insidegun == 2)
                    {
                        //モスミサイル
                        if (time >= 1.2f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(misa) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 0.2f);
                            time = 0f;  //初期化
                            sound02.PlayOneShot(sound02.clip);
                            effekseerEmitter1.Play();
                        }
                    }
                    else if (insidegun == 3)
                    {
                        //キャノン
                        if (time >= 10f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(canon) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 1.5f);
                            time = 0f;  //初期化
                            sound02.PlayOneShot(sound02.clip);
                        }
                    }
                    else if (insidegun == 4)
                    {
                        //溶断チェーンソウ
                        if (time >= 0.1f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(heatknife) as GameObject;
                            obj.transform.position = spawn.position;
                            time = 0f;  //初期化
                            sound06.PlayOneShot(sound06.clip);
                        }
                    }
                    else if (insidegun == 5)
                    {
                        //テイクダウン
                        if (time >= 1.3f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(takedown) as GameObject;
                            obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 1f);
                            obj.transform.position = spawn.position;
                            time = 0f;  //初期化
                            sound01.PlayOneShot(sound01.clip);
                        }
                    }
                    else if (insidegun == 6)
                    {
                        //ヒートジャンク
                        if (time >= 0.9f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(heatjunk) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 0.8f);
                            time = 0f;  //初期化
                            sound05.PlayOneShot(sound05.clip);
                        }
                    }
                    else if (insidegun == 7)
                    {
                        //バリスタ
                        if (time3 >= 2.5f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(barista) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce((rifle.forward + rifle.up / 1.2f) * speed * 0.6f);
                            time3 = 0f;  //初期化
                            sound06.PlayOneShot(sound06.clip);
                        }
                    }
                    else if (insidegun == 8)
                    {
                        //フラググレネード
                        if (time >= 2f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(flugG) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce((rifle.forward + rifle.up / 2) * speed * 2.2f);
                            time = 0f;  //初期化
                            sound05.PlayOneShot(sound05.clip);
                        }
                    }
                    else if (insidegun == 9)
                    {
                        //リベットガン
                        if (time >= 0.27f * adsr)
                        {
                            GameObject obj = GameObject.Instantiate(ribettgun) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 0.4f);
                            time = 0f;  //初期化
                            sound01.PlayOneShot(sound01.clip);
                        }
                    }
                }
                else {
                    if (outsidegun == 1)
                    {
                        if (ammo > 0)
                        {
                            //ショットキャノン
                            if (time >= 1.1f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(shotbullet) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 0.8f);
                                obj.transform.rotation = transform.rotation;
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound01.clip);
                                effekseerEmitter2.Play();
                            }
                        }
                    }
                    else if (outsidegun == 2)
                    {
                        if (ammo > 0)
                        {
                            //イーグルアイ
                            if (time >= 1.8f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(EagleEye) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 7f);
                                time = 0f;  //初期化
                                sound04.PlayOneShot(sound04.clip);
                                effekseerEmitter2.Play();
                            }
                        }
                    }
                    else if (outsidegun == 3)
                    {
                        if (ammo > 0)
                        {
                            //パルスミサイル
                            if (time >= 2f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(Pulsemisa) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed / 5f);
                                time = 0f;  //初期化
                                sound02.PlayOneShot(sound02.clip);
                                effekseerEmitter2.Play();
                            }
                        }
                    }
                    else if (outsidegun == 4)
                    {
                        if (ammo > 0)
                        {
                            //バウンスリボルバー
                            if (revo <= 4)
                            {
                                revot = 0.25f;
                            }
                            else {
                                revot = 2f;
                            }
                            if (time >= revot * adsr)
                            {
                                if (revo <= 4)
                                {
                                    revo += 1;
                                }
                                else {
                                    revo = 0;
                                }
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(BounceRevolver) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 1.5f);
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound01.clip);
                                effekseerEmitter2.Play();
                            }
                        }
                    }
                    else if (outsidegun == 5)
                    {
                        if (ammo > 0)
                        {
                            //アンコモンライフル
                            if (time >= 0.22f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(UCriflebullet) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 3f);
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound01.clip);
                            }
                        }
                    }
                    else if (outsidegun == 6)
                    {
                        if (ammo > 0)
                        {
                            //バーナー
                            if (time >= 0.1f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(burner) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 10f);
                                time = 0f;  //初期化
                                sound05.PlayOneShot(sound05.clip);
                                effekseerEmitter2.Play();
                            }
                        }
                    }
                    else if (outsidegun == 7)
                    {
                        if (ammo > 0)
                        {
                            //ガソリングレネード
                            if (time >= 2f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(Gasogre) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce((rifle2.forward + rifle.up / 2) * speed);
                                time = 0f;  //初期化
                                sound05.PlayOneShot(sound05.clip);
                                effekseerEmitter2.Play();
                            }
                        }
                    }
                    else if (outsidegun == 8)
                    {
                        if (ammo > 0)
                        {
                            if (time3 >= 2f * adsr)
                            {
                                //トパーズ30mmガトリング
                                if (time >= 0.1f * adsr)
                                {
                                    ammo -= 1;
                                    GameObject obj = GameObject.Instantiate(Gato) as GameObject;
                                    obj.transform.position = spawn2.position;
                                    X = UnityEngine.Random.Range(1, 5);
                                    mainas = UnityEngine.Random.Range(0, 2);
                                    if (mainas == 0)
                                    {
                                        mainas = -1;
                                    }
                                    else {
                                        mainas = 1;
                                    }
                                    obj.GetComponent<Rigidbody>().AddForce((rifle2.forward + rifle2.right / (X * mainas)) * speed * 2);
                                    Y = UnityEngine.Random.Range(4, 7);
                                    mainas = UnityEngine.Random.Range(0, 2);
                                    if (mainas == 0)
                                    {
                                        mainas = -1;
                                    }
                                    else {
                                        mainas = 1;
                                    }
                                    obj.GetComponent<Rigidbody>().AddForce((rifle2.forward + rifle2.up / (Y * mainas)) * speed * 2);
                                    time = 0f;  //初期化
                                    sound01.PlayOneShot(sound01.clip);
                                    effekseerEmitter2.Play();
                                }
                            }
                            else if (chagesound == 0)
                            {
                                chagesound = 1;
                                sound06.PlayOneShot(sound06.clip);
                            }
                        }
                    }
                    else if (outsidegun == 9)
                    {
                        if (ammo > 0)
                        {
                            //ボルテック
                            if (time >= 0.3f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(Voltaic) as GameObject;
                                obj.transform.position = spawn2.position;
                                //obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 10f);
                                time = 0f;  //初期化
                                sound05.PlayOneShot(sound05.clip);
                                //effekseerEmitter2.Play();
                            }
                        }
                    }
                    else if (outsidegun == 10)
                    {
                        if (ammo > 0)
                        {
                            //スクトゥム
                            if (time >= 0.37f * adsr)
                            {
                                GameObject obj = GameObject.Instantiate(riflebullet) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 1.6f);
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound01.clip);
                            }
                        }
                    }
                    else if (outsidegun == 11)
                    {
                        if (ammo > 0)
                        {
                            //ラピッドマシンガン
                            if (time >= 0.08f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(Machinbullet) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 2.7f);
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound01.clip);
                            }
                        }
                    }
                    else if (outsidegun == 12)
                    {
                        if (ammo > 0)
                        {
                            //ネクストライフル
                            if (time >= 0.4f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(nextbullet) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 2.7f);
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound01.clip);
                            }
                        }
                    }
                    else if (outsidegun == 13)
                    {
                        if (ammo > 0)
                        {
                            //テトラ
                            if (time >= 0.45f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj1 = GameObject.Instantiate(Tetlabullet) as GameObject;
                                obj1.transform.position = spawn2.position;
                                obj1.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed);
                                sound01.PlayOneShot(sound04.clip);
                                GameObject obj2 = GameObject.Instantiate(Tetlabullet) as GameObject;
                                obj2.transform.position = spawn2.position + new Vector3(0, -1, 0);
                                obj2.GetComponent<Rigidbody>().AddForce((rifle2.forward + rifle.right / 1.2f) * speed);
                                sound01.PlayOneShot(sound04.clip);
                                GameObject obj3 = GameObject.Instantiate(Tetlabullet) as GameObject;
                                obj3.transform.position = spawn2.position + new Vector3(0, -1, 0);
                                obj3.GetComponent<Rigidbody>().AddForce((rifle2.forward + -rifle.right / 1.2f) * speed);
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound04.clip);

                            }
                        }
                    }
                    else if (outsidegun == 14)
                    {
                        if (ammo > 0)
                        {
                            //ルビーバズ
                            if (time >= 1.55f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(bazz) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed);
                                time = 0f;  //初期化
                                sound02.PlayOneShot(sound02.clip);
                            }
                        }
                    }
                    else if (outsidegun == 15)
                    {
                        if (ammo > 0)
                        {
                            //エメラルドモア
                            if (time >= 4.5f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(moa) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce((rifle2.forward + rifle.up / 1.5f) * speed * 200);
                                time = 0f;  //初期化
                                sound05.PlayOneShot(sound05.clip);
                            }
                        }
                    }
                    if (outsidegun == 16)
                    {
                        if (ammo > 0)
                        {
                            //ヘビーライフル
                            if (time >= 0.5f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(heby) as GameObject;
                                obj.transform.position = spawn.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 2.2f);
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound01.clip);
                            }
                        }
                    }
                    if (outsidegun == 17)
                    {
                        if (ammo > 0)
                        {
                            //ロケット
                            if (time >= 0.5f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(roke) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward);
                                time = 0f;  //初期化
                                sound01.PlayOneShot(sound01.clip);
                            }
                        }
                    }
                    if (outsidegun == 18)
                    {
                        if (ammo > 0)
                        {
                            //ロキ
                            if (time >= 2.3f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(loki) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce((rifle2.forward + rifle.up / 2) * speed * 1.4f);
                                time = 0f;  //初期化
                                sound05.PlayOneShot(sound05.clip);
                            }
                        }
                    }
                    else if (outsidegun == 19)
                    {
                        if (ammo > 0)
                        {
                            //レールガン
                            if (time >= 10f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(Railgun) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 6f);
                                time = 0f;  //初期化
                                sound04.PlayOneShot(sound04.clip);
                            }
                        }
                    }
                    else if (outsidegun == 20)
                    {
                        if (ammo > 0)
                        {
                            //パイルバンカー
                            if (time3 >= 1f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(PileBunker) as GameObject;
                                obj.transform.position = spawn2.position;
                                time3 = 0f;  //初期化
                                sound02.PlayOneShot(sound02.clip);
                            }
                        }
                    }
                    else if (outsidegun == 21)
                    {
                        if (ammo > 0)
                        {
                            //ショックウェーブ
                            if (time >= 0.1f * adsr)
                            {
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(Shockwave) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 10f);
                                time = 0f;  //初期化
                                sound05.PlayOneShot(sound05.clip);
                            }
                        }
                    }
                    else if (outsidegun == 22)
                    {
                        if (ammo > 0)
                        {
                            if (chagesound == 0)
                            {
                                chagesound = 1;
                                sound06.PlayOneShot(sound06.clip);
                            }
                            if (time3 >= 3.8f * adsr)
                            {
                                //コメット
                                if (time3 <= 7f * adsr)
                                {
                                    ammo -= 1;
                                    GameObject obj = GameObject.Instantiate(comet) as GameObject;
                                    obj.transform.position = spawn2.position;
                                    obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 10f);
                                    sound07.PlayOneShot(sound07.clip);
                                }
                            }
                        }
                    }
                    else if (outsidegun == 23) {
                        if (ammo > 0)
                        {
                            if (time >= 1.3f * adsr)
                            {
                                //高反動キャノン
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(canon) as GameObject;
                                obj.transform.position = spawn2.position;
                                obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 6f);
                                time = 0f;  //初期化
                                sound02.PlayOneShot(sound02.clip);
                                ads.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * -5f);
                                effekseerEmitter2.Play();
                            }
                        }
                    }
                    else if (outsidegun == 24)
                    {
                        if (ammo > 0)
                        {
                            if (time >= 5f * adsr)
                            {
                                //スラスターブレード
                                ammo -= 1;
                                GameObject obj = GameObject.Instantiate(surabure) as GameObject;
                                obj.transform.position = new Vector3(spawn2.position.x, spawn2.position.y, spawn2.position.z + 3);
                                //obj.GetComponent<Rigidbody>().AddForce(rifle2.forward * speed * 6f);
                                time = 0f;  //初期化
                                sound05.PlayOneShot(sound05.clip);
                                effekseerEmitter2.Play();
                            }
                        }
                    }
                }
			}
		} else {
			time2 = 0;
			time3 = 0;
            chagesound = 0;
            if (input2 != Vector3.zero) {
                if (rockon == false || advantageshift.advantageshift != 0)
                {
                    targetRotation = Quaternion.LookRotation(input2);
                    transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
                }
			}
		}
	}
	public void PlayAudio(){
		sound03.PlayOneShot(sound03.clip);
	}
	public void Scutumammo(){

	}

	void weponDisplay(){
		wmachingun.SetActiveRecursively(false);
		wLaser.SetActiveRecursively(false);
		wshotgun.SetActiveRecursively(false);
		wEagleEye.SetActiveRecursively(false);
		wmisa.SetActiveRecursively(false);
		wPulsemisa.SetActiveRecursively(false);
		wScutum.SetActiveRecursively(false);
		wrapid.SetActiveRecursively(false);
		wBounceRevolver.SetActiveRecursively(false);
		wUCriflebullet.SetActiveRecursively(false);
		wburner.SetActiveRecursively(false);
		wGasogre.SetActiveRecursively(false);
		wGato.SetActiveRecursively(false);
		wVoltaic.SetActiveRecursively(false);
        wGato.SetActiveRecursively(false);
        wVoltaic.SetActiveRecursively(false);
        if (insidegun == 0)
        {
            wmachingun.SetActiveRecursively(true);
        }
        else if (insidegun == 1)
        {
            wLaser.SetActiveRecursively(true);
        }
        else if (insidegun == 2)
        {
            wmisa.SetActiveRecursively(true);
        }
        if (outsidegun == 1)
        {
            wshotgun.SetActiveRecursively(true);
        }
        else if (outsidegun == 2)
        {
            wEagleEye.SetActiveRecursively(true);
        }
        else if (outsidegun == 3)
        {
            wPulsemisa.SetActiveRecursively(true);
        }
        else if (outsidegun == 4)
        {
            wBounceRevolver.SetActiveRecursively(true);
        }
        else if (outsidegun == 5)
        {
            wUCriflebullet.SetActiveRecursively(true);
        }
        else if (outsidegun == 6)
        {
            wburner.SetActiveRecursively(true);
        }
        else if (outsidegun == 7)
        {
            wGasogre.SetActiveRecursively(true);
        }
        else if (outsidegun == 8)
        {
            wGato.SetActiveRecursively(true);
        }
        else if (outsidegun == 9)
        {
            wVoltaic.SetActiveRecursively(true);
        }
        else if (outsidegun == 10)
        {
            wScutum.SetActiveRecursively(true);
        }
        else if (outsidegun == 11)
        {
            wrapid.SetActiveRecursively(true);
        }
        else if (outsidegun == 23)
        {
            wHighcanon.SetActiveRecursively(true);
        }
        else if (outsidegun == 24)
        {
            wSurabure.SetActiveRecursively(true);
        }
    }
}
