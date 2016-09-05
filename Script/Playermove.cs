using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
public class Playermove: MonoBehaviour 
{
	AdvantageShift    advantageshift;
	PlayerLife    playerLife;
	public float speed = 187.5f;
    public GameObject[] boost;
	Vector3 lookPos;
	public float rotationSpeed = 450,kasokup=1.01f;
	private Quaternion targetRotation;
    EffekseerEmitter[] efk = new EffekseerEmitter[2];
    bool efkplay = false;
	float life, life2,ads,kasokuads,kasokugenkai,kasoku;
	// Use this for initialization
	void Start () {
		GameObject ads = GameObject.Find ("PlayerMove");
		advantageshift = ads.GetComponent<AdvantageShift> ();
        efk[0] = boost[0].GetComponent<EffekseerEmitter>();
        efk[1] = boost[1].GetComponent<EffekseerEmitter>();
    }

	void Update(){
		if (advantageshift.advantageshift == 0) {
			ads = 1.5f;
		} else if (advantageshift.advantageshift == 1) {
			ads = 1f;
		} else {
			ads = 0.8f;
		}
	}
	// Update is called once per frame

	void FixedUpdate () {
        
		float horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
		Vector3 movement = new Vector3(horizontal, 0 , vertical);
        if (horizontal != 0 || vertical != 0)
        {
            boost[0].transform.rotation = Quaternion.LookRotation(movement * -1);
            boost[1].transform.rotation = Quaternion.LookRotation(movement * -1);
            if (!efkplay)
            {
                efkplay = true;
                efk[0].Play();
                efk[1].Play();
            }
        }
        else
        {
            if (efkplay)
            {
                efkplay = false;
                efk[0].Stop();
                efk[1].Stop();
            }
        }
        GetComponent<Rigidbody>().AddForce(movement * (speed * ads * kasoku) / Time.deltaTime);
        if (kasoku < 1.8f&&(horizontal != 0 || vertical != 0))
        {
            kasoku *=kasokup;
        }if((horizontal <= 0.4f && horizontal >= -0.4f) && (vertical <= 0.4f && vertical >= -0.4f))
        {
            kasoku = 1;
        }
    }
}