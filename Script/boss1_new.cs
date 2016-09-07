using UnityEngine;
using System.Collections;

public class boss1_new : MonoBehaviour 
{
	//ボス専用の行動パターン
　  	//プレイヤーを見つけてはチャージを行いガトリングを掃射するだけの単純なもの
　  	//基本的に各行動のあと硬直が発生する
　  	//3回に1回掃射後に硬直無しでそのまま回転しながらガトリングを掃射するフェイントを行う。
    	// 変数
    	// a=0:捜索,移動 5:硬直 10:プレイヤーの方を向く 20:射撃 30:射撃後の隙 40:武器ドロップ&隙
    	// 45:W処理射撃準備 50:W処理中の射撃 60:W処理中の射撃後の隙 70:W処理中の硬直
    	public int a = 0;
    	public int N = 0;   // 同じ処理を行った回数
    	public int W;       // 回った回数
    	Animator anim;
    	int i, mainas;
    	bool c = true;
	float time, time2, X, Y, chagesound;
    	GameObject player;
	public float Smashdamage = 20;
	public GameObject Gato;
	public Transform spawn;
	public Transform spawn2;
	public Transform rifle;
	public Transform playerposition;
	public AudioSource sound01;
    	public AudioSource sound02;
    	sousaku sousaku;
    	boss1enemy enemy;
    	public float speed = 500;
    	public float find;
    	NavMeshAgent agent;
    
    	void Start () 
    	{
        	player = GameObject.Find("PlayerMove");
        	AudioSource[] audioSources = GetComponents<AudioSource>();
        	sound01 = audioSources[0];
        	sound02 = audioSources[1];
        	enemy = GetComponent<boss1enemy>();
        	agent = gameObject.GetComponent<NavMeshAgent>();
        	anim=transform.FindChild("bossenemy_unity_LOD1").GetComponent<Animator>();
    	}
	
    	void Update () 
    	{
        	playerposition = player.transform;
		// プレイヤーが視界に入る
        	if(find == 0&&N !=-1)
        	{
            		agent.SetDestination(player.transform.position);
            		anim.SetBool("bossmove", true);
            		a = 0;
        	}
        	else
        	{
            		anim.SetBool("bossmove", false);
            		agent.SetDestination(gameObject.transform.position);
            		if (N != -1)
            		{
                		StartCoroutine("wait");
            		}
            		if (a == 10 && W == 0)
            		{
                		StopCoroutine("wait");
		                // 5回ループ
                		StartCoroutine("loop", 5);
                		// 射撃に移行
                		a = 20;
            		}
            		if (a == 20)
            		{
            			//射撃
                		StopCoroutine("loop");
                		c = true;
                		time += Time.deltaTime;
                		time2 += Time.deltaTime;
                		if (time >= 0.07f)
                		{
                    			GameObject obj = GameObject.Instantiate(Gato) as GameObject;
			                GameObject obj2 = GameObject.Instantiate(Gato) as GameObject;
                    			for (int ri = 0; ri < enemy.dropCount; ri++)
                    			{
                        			if (N == -1)
                        			{
                            				gameObject.transform.eulerAngles += new Vector3(0f, 6f, 0f);
                        			}
                        			if (ri == 0)
                        			{
                        				obj.transform.position = spawn.position;
                        			}
                        			else
                        			{
                            				obj2.transform.position = spawn2.position;
                        			}

                        			X = UnityEngine.Random.Range(1, 5);
                        			mainas = UnityEngine.Random.Range(0, 2);
                        			if (mainas == 0)
                        			{
                            				mainas = -1;
                        			}
                        			else
                        			{
                            				mainas = 1;
                        			}
                        			if (ri == 0)
                        			{
                            				obj.GetComponent<Rigidbody>().AddForce(
                                				(rifle.forward + rifle.right / (X * mainas)) * 800 * 2);
                        			}
                        			else
                        			{
                            				obj2.GetComponent<Rigidbody>().AddForce(
                            					(rifle.forward + rifle.right / (X * mainas)) * 800 * 2);
                        			}

                        			Y = UnityEngine.Random.Range(1, 3);
                        			mainas = UnityEngine.Random.Range(0, 2);
                        			if (mainas == 0)
                        			{
                            				mainas = -1;
                        			}
                        			else
                        			{
                            				mainas = 1;
                        			}
                        			if (ri == 0)
                        			{
                            				obj.GetComponent<Rigidbody>().AddForce(
                            					(rifle.forward + rifle.up / (Y * mainas)) * 800 * 2);
                        			}
                        			else
                        			{
                            				obj2.GetComponent<Rigidbody>().AddForce(
                                				(rifle.forward + rifle.up / (Y * mainas)) * 800 * 2);
                        			}
                        			// 初期化
                        			time = 0f;
                        			sound01.PlayOneShot(sound01.clip);
                        			// ここまで射撃の処理
                    			}

                    			if (time2 >= 5)
                    			{
                        			time = 0;
                        			time2 = 0;
                        			// 5秒掃射
                        			N++;
                        			if (N == 3)
                        			{
                            				N = -1;
                            				a = 20;
                        			}
                        			else if(N != 3)
                        			{
                            				// 射撃後の隙に移行
                            				a = 30;
                            				StartCoroutine("wait");
                        			}
                    			}
                		}
            		}            
        	}
　　	}

    	IEnumerator wait()
    	{
		if (a == 0)
        	{
        		a = 5;
            		if (c)
            		{
                		c = false;
                		sound02.PlayOneShot(sound02.clip);
            		}
            		for (int i = 0; i < 200; i++)
            		{
                		// プレイヤーの方を向く
                		transform.LookAt(playerposition);
                		yield return null;
            		}
        		a = 10;
        	} 
		else if (a == 30) 
		{
			// 射撃後の隙
			return new WaitForSeconds(3.0f);
            		find = 0;
            		a = 0;
		}
		else if (a == 40)
		{
			// 武器ドロップ
			yield return new WaitForSeconds(4.0f);
            		a = 0;
		}
        	else if (a == 60)
        	{
        		//W処理後の隙
            		yield return null;
            		a = 70;
        	}
        	else if (a == 70)
        	{
        		//W処理中の硬直
            		Debug.Log("START");
            		yield return new WaitForSeconds(5.0f);
        	 	Debug.Log("5秒経過");
            		// プレイヤーの方を向く
            		a = 0;
        	}
    	}
    
    	IEnumerator loop()
    	{
        	if (a == 10)
        	{
            		for (int n = 0; n < 10; n++)
            		{
                		Debug.Log("n:" + n);
                		// プレイヤーの方を向く
                		transform.LookAt(playerposition);
                		yield return new WaitForSeconds(1.0f);

                		if (n == 5)
                		{
                    			Debug.Log("LoopStop");
                		}
            		}
        	}
    	}
}
