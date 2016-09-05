using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
    public GameObject muzzleflash;    //マズルフラッシュ
    public float speed = 1000; //移動速度
	public float rotationSpeed = 170;
	//プレイヤーを代入
	public int outsidegun = 1;
	public int insidegun = 1;
	public int wepontype = 1;
	public Transform rifle;
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
    public GameObject highcanon;
    public GameObject surabure;
    public Transform spawn;
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
    float time  = 2;
	float a, b ,c,rd,X,Y,mainas;
	private AudioSource sound01;
	private AudioSource sound02;
	private AudioSource sound03;
	private AudioSource sound04;
	private AudioSource sound05;
	public Transform player;
    public bool shotPermit = false;
    Vector3 apos,arot;
    float time2;
    public GameObject boost;
    EffekseerEmitter effekseerEmitter;
    // enum insidegun { machingun, Laser, misa };
    // Use this for initialization
    void Start () {
		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound01 = audioSources[0];
		sound02 = audioSources[1];
		sound03 = audioSources[2];
		sound04 = audioSources[3];
		sound05 = audioSources[4];
        effekseerEmitter = muzzleflash.GetComponent<EffekseerEmitter>();
        arot = transform.localEulerAngles;
        apos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        time2 += Time.deltaTime;
        if (time2 >= 0.5f)
        {
            time2 = 0;
            arot = transform.localEulerAngles;
            apos = transform.position;
        }
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
			c = outsidegun;
			weponDisplay ();
		}

		time += Time.deltaTime;
		shot ();
	}
	
	void shot(){
		if (wepontype == 1) {
            if (shotPermit){
				if (insidegun == 0) {
					if (time >= 0.3f) {
						rd = UnityEngine.Random.Range (0, 2);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (riflebullet)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
							sound01.PlayOneShot (sound01.clip);
						}
						time = 0f;  //初期化
					}
				} else if (insidegun == 1) {
					if (time >= 1.1f) {
						rd = UnityEngine.Random.Range (0, 2);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (Laser)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 3f);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                            sound04.PlayOneShot (sound04.clip);
						}
						time = 0f;  //初期化
					}
				} else if (insidegun == 2) {
					//モスミサイル
					if (time >= 1.2f) {
						rd = UnityEngine.Random.Range (0, 3);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (misa)as GameObject;
                            if (GetComponent<jackenemy>())
                            {
                                obj.GetComponent<misaE>().target = "Enemy";
                            }
                            else
                            {
                                obj.GetComponent<misaE>().target = "Player";
                            }
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 0.5f);
							time = 0f;  //初期化
							sound02.PlayOneShot (sound02.clip);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
					}
				}
			}
		} else {
			if (outsidegun == 0) {
				//wepontype = 1;
            } 
            if (shotPermit){
				if (outsidegun == 1) {
					if (time >= 1.5f) {
                        rd = UnityEngine.Random.Range(0, 5);
                        if (rd == 0)
                        {
                            GameObject obj = GameObject.Instantiate(shotbullet) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce(rifle.forward * speed * 0.8f);
                            obj.transform.rotation = transform.rotation;
                            sound01.PlayOneShot(sound01.clip);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
                        time = 0f;  //初期化
                    }
				} else if (outsidegun == 2) {
					if (time >= 1.35f) {
						rd = UnityEngine.Random.Range (0, 8);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (EagleEye)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 7f);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
						time = 0f;  //初期化
					}
				} else if (outsidegun == 3) {
					//パルスミサイル
					if (time >= 2f) {
						rd = UnityEngine.Random.Range (0, 8);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (Pulsemisa)as GameObject;
                            if (GetComponent<jackenemy>())
                            {

                                obj.GetComponent<misaE>().target = "Enemy";
                            }
                            else
                            {
                                obj.GetComponent<misaE>().target = "Player";
                            }
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 0.3f);
							time = 0f;  //初期化
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                            sound02.PlayOneShot (sound02.clip);
						}
					}
				} else if (outsidegun == 4) {
					if (time >= 1.1f) {
						rd = UnityEngine.Random.Range (0, 8);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (BounceRevolver)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 1.5f);
							time = 0f;  //初期化
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                            sound01.PlayOneShot (sound01.clip);
						}
					}
				} else if (outsidegun == 5) {
					if (time >= 0.22f) {
						rd = UnityEngine.Random.Range (0, 5);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (UCriflebullet)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 3f);
							time = 0f;  //初期化
							sound01.PlayOneShot (sound01.clip);
						}
					}
				} else if (outsidegun == 6) {
					if (time >= 0.3f) {
						rd = UnityEngine.Random.Range (0, 3);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (burner)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 10f);
							time = 0f;  //初期化
							sound05.PlayOneShot (sound05.clip);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
					}
				} else if (outsidegun == 7) {
					if (time >= 2f) {
						rd = UnityEngine.Random.Range (0, 7);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (Gasogre)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce ((rifle.forward + rifle.up / 2) * speed * 1.9f);
							time = 0f;  //初期化
							sound05.PlayOneShot (sound05.clip);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
					}
				} else if (outsidegun == 8) {
					if (time >= 0.2f) {
						rd = UnityEngine.Random.Range (0, 5);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (Gato)as GameObject;
							obj.transform.position = spawn.position;
							X = UnityEngine.Random.Range (1, 5);
							mainas = UnityEngine.Random.Range (0, 1);
							if (mainas == 0) {
								mainas = -1;
							} else {
								mainas = 1;
							}
							obj.GetComponent<Rigidbody>().AddForce ((rifle.forward + rifle.right / X * mainas) * speed * 2);
							Y = UnityEngine.Random.Range (4, 7);
							mainas = UnityEngine.Random.Range (0, 1);
							if (mainas == 0) {
								mainas = -1;
							} else {
								mainas = 1;
							}
							obj.GetComponent<Rigidbody>().AddForce ((rifle.forward + rifle.up / Y * mainas) * speed * 2);
							time = 0f;  //初期化
							sound01.PlayOneShot (sound01.clip);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
					}
				} else if (outsidegun == 9) {
					if (time >= 0.25f) {
						rd = UnityEngine.Random.Range (0, 3);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (Voltaic)as GameObject;
                            if (GetComponent<jackenemy>())
                            {
                                obj.GetComponent<VoltecE>().target = "Enemy";
                            }
                            else
                            {
                                obj.GetComponent<VoltecE>().target = "Player";
                            }
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 10f);
							time = 0f;  //初期化
							sound05.PlayOneShot (sound05.clip);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
					}
				} else if (outsidegun == 10) {
					if (time >= 0.37f) {
						rd = UnityEngine.Random.Range (0, 5);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (riflebullet)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 1.6f);
							time = 0f;  //初期化
							sound01.PlayOneShot (sound01.clip);
						}
					}
				} else if (outsidegun == 11) {
					if (time >= 0.1f) {
						rd = UnityEngine.Random.Range (0, 4);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (Machinbullet)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 2.7f);
							time = 0f;  //初期化
							sound01.PlayOneShot (sound01.clip);
						}
					}
				} else if (outsidegun == 12) {
					//ネクストライフル
					if (time >= 0.4f) {
						rd = UnityEngine.Random.Range (0, 6);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (nextbullet)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 2.7f);
							time = 0f;  //初期化
							sound01.PlayOneShot (sound01.clip);
						}
					}
				} else if (outsidegun == 13) {
					//テトラ
					if (time >= 0.45f) {
						rd = UnityEngine.Random.Range (0, 6);
						if (rd == 0) {
							GameObject obj1 = GameObject.Instantiate (Tetlabullet)as GameObject;
							obj1.transform.position = spawn.position;
							obj1.GetComponent<Rigidbody>().AddForce (rifle.forward * speed);
							sound01.PlayOneShot (sound04.clip);
							GameObject obj2 = GameObject.Instantiate (Tetlabullet)as GameObject;
							obj2.transform.position = spawn.position + new Vector3 (0, -1, 0);
							obj2.GetComponent<Rigidbody>().AddForce ((rifle.forward + rifle.right / 1.2f) * speed);
							sound01.PlayOneShot (sound04.clip);
							GameObject obj3 = GameObject.Instantiate (Tetlabullet)as GameObject;
							obj3.transform.position = spawn.position + new Vector3 (0, -1, 0);
							obj3.GetComponent<Rigidbody>().AddForce ((rifle.forward + -rifle.right / 1.2f) * speed);
							time = 0f;  //初期化
							sound01.PlayOneShot (sound04.clip);
						}
					}
				} else if (outsidegun == 14) {
					//ルビーバズ
					if (time >= 1.55f) {
						rd = UnityEngine.Random.Range (0, 7);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (bazz)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed);
							time = 0f;  //初期化
							sound02.PlayOneShot (sound02.clip);
						}
					}
				} else if (outsidegun == 15) {
					//エメラルドモア
					if (time >= 4.5f) {
						rd = UnityEngine.Random.Range (0, 3);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (moa)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce ((rifle.forward + rifle.up / 1.5f) * speed * 200);
							time = 0f;  //初期化
							sound05.PlayOneShot (sound05.clip);
						}
					}
				}
				if (outsidegun == 16) {
					//ヘビーライフル
					if (time >= 0.5f) {
						rd = UnityEngine.Random.Range (0, 7);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (heby)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward * speed * 2.2f);
							time = 0f;  //初期化
							sound01.PlayOneShot (sound01.clip);
						}
					}
				}
				if (outsidegun == 17) {
					//ロケット
					if (time >= 0.5f) {
						rd = UnityEngine.Random.Range (0, 5);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (roke)as GameObject;
							obj.transform.position = spawn.position;
							obj.transform.rotation = spawn.rotation;
							obj.GetComponent<Rigidbody>().AddForce (rifle.forward);
							time = 0f;  //初期化
							sound01.PlayOneShot (sound01.clip);
						}
					}
				}
				if (outsidegun == 18) {
					//ロキ
					if (time >= 2.3f) {
						rd = UnityEngine.Random.Range (0, 22);
						if (rd == 0) {
							GameObject obj = GameObject.Instantiate (loki)as GameObject;
							obj.transform.position = spawn.position;
							obj.GetComponent<Rigidbody>().AddForce ((rifle.forward + rifle.up / 2) * speed * 1.4f);
							time = 0f;  //初期化
							sound05.PlayOneShot (sound05.clip);
						}
					}
				}
                if (outsidegun == 19)
                {
                    //高反動キャノン
                    if (time >= 1.6f)
                    {
                        rd = UnityEngine.Random.Range(0, 13);
                        if (rd == 0)
                        {
                            GameObject obj = GameObject.Instantiate(highcanon) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce((rifle.forward + rifle.up / 2) * speed * 1.4f);
                            time = 0f;  //初期化
                            sound05.PlayOneShot(sound05.clip);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
                    }
                }
                if (outsidegun == 20)
                {
                    //スラスターブレード
                    if (time >= 4f)
                    {
                        rd = UnityEngine.Random.Range(0, 13);
                        if (rd == 0)
                        {
                            GameObject obj = GameObject.Instantiate(surabure) as GameObject;
                            obj.transform.position = spawn.position;
                            obj.GetComponent<Rigidbody>().AddForce((rifle.forward + rifle.up / 2) * speed * 1.4f);
                            time = 0f;  //初期化
                            sound05.PlayOneShot(sound05.clip);
                            effekseerEmitter.Play();//マズルフラッシュのエフェクト
                        }
                    }
                }
            }
		}
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
        wHighcanon.SetActiveRecursively(false);
        wSurabure.SetActiveRecursively(false);
        if (wepontype == 1) {
			if(insidegun == 0){
				wmachingun.SetActiveRecursively(true);
			}else if(insidegun == 1){
				wLaser.SetActiveRecursively(true);
			}else if(insidegun == 2){
				wmisa.SetActiveRecursively(true);
			}
		} else {
			if(outsidegun == 1){
				wshotgun.SetActiveRecursively(true);
			}else if(outsidegun == 2){
				wEagleEye.SetActiveRecursively(true);
			}else if(outsidegun == 3){
				wPulsemisa.SetActiveRecursively(true);
			}else if(outsidegun == 4){
				wBounceRevolver.SetActiveRecursively(true);
			}else if(outsidegun == 5){
				wUCriflebullet.SetActiveRecursively(true);
			}else if(outsidegun == 6){
				wburner.SetActiveRecursively(true);
			}else if(outsidegun == 7){
				wGasogre.SetActiveRecursively(true);
			}else if(outsidegun == 8){
				wGato.SetActiveRecursively(true);
			}else if(outsidegun == 9){
				wVoltaic.SetActiveRecursively(true);
			}else if(outsidegun == 10){
				wScutum.SetActiveRecursively(true);
			}else if(outsidegun == 11){
				wrapid.SetActiveRecursively(true);
			}else if (outsidegun == 18){
                wHighcanon.SetActiveRecursively(true);
            }else if (outsidegun == 19){
                wSurabure.SetActiveRecursively(true);
            }
        }
	}
}