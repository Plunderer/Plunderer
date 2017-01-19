using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
public class Playermove: MonoBehaviour 
{
	AdvantageShift    advantageshift;
	PlayerLife    playerLife;
	public float speed = 187.5f;
	Vector3 lookPos;
	public float rotationSpeed = 450,kasokup=1.01f;
	private Quaternion targetRotation;
    EffekseerEmitter[] efk = new EffekseerEmitter[2];
    bool efkplay = false;
    PlayerController pl;
    float life, life2, ads, kasokuads, kasokugenkai, kasoku, horizontal, vertical;
	// Use this for initialization
	void Start () {
		GameObject ads = GameObject.Find ("PlayerMove");
        pl = GameObject.Find("Player").GetComponent<PlayerController>();
		advantageshift = ads.GetComponent<AdvantageShift> ();
    }

	void Update(){
		if (advantageshift.advantageshift == 0) {
			ads = 1f;
		} else if (advantageshift.advantageshift == 1) {
			ads = 0.8f;
		} else {
			ads = 0.6f;
		}
	}
	// Update is called once per frame

	void FixedUpdate (){
        
        horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        
        if (!pl.stop) GetComponent<Rigidbody>().AddForce(movement * (speed * ads * kasoku) / Time.deltaTime);
        if (!pl.stop &&kasoku < 1.8f && (horizontal != 0 || vertical != 0))
        {
            kasoku *=kasokup;
        } if (!pl.stop && (horizontal <= 0.4f && horizontal >= -0.4f) && (vertical <= 0.4f && vertical >= -0.4f))
        {
            kasoku = 1;
        }
    }
}