using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
using System.Text.RegularExpressions;
public class Dash : MonoBehaviour {
    string inputCommands = "";
    public Transform playermove;
	public float Dashspeed = 10;
	public float Dashtime= 3;
    float horizontal, vertical;

    float time;
	Vector3 lookPos;
    int recCommandLength = 100;
    // Use this for initialization
    void Start () {
        inputCommands = inputCommands.PadLeft(100);
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        getAxis();
    }
    void getAxis()
    {

        if (vertical > 0.4)
        {
            if (horizontal > 0.4) { inputCommands += "9"; }
            else if (horizontal < -0.4) { inputCommands += "7"; }
            else{ inputCommands += "8"; }
        }

        else if (vertical < -0.4)
        {
            if (horizontal > 0.4) { inputCommands += "3"; }
            else if (horizontal < -0.5) { inputCommands += "1"; }
            else { inputCommands += "2"; }
        }
        else if (vertical < 0.4 && vertical > -0.4)
        {
            if (horizontal > 0.4) { inputCommands += "6"; }
            else if (horizontal < -0.4) { inputCommands += "4"; }
            else { inputCommands += "5"; }
        }
        else
        {

        }
        if (inputCommands.Length > recCommandLength)
        {
            inputCommands = inputCommands.Remove(0,1);
        }
        confirmCommand();
    }
    void confirmCommand()
    {
        string[] dashC = { "1.*9.*1", "2.*8.*2," ,"3.*7.*3","4.*6.*4","6.*4.*6","7.*3.*7","8.*2.*8","9.*1.*9"};
        int comLength = 30;
        //
        string checkframe = inputCommands.Remove(0, recCommandLength - comLength);
        //
        
        for (int a = 0; a < 8; a++)
        {
            if (Regex.IsMatch(checkframe, dashC[a]))
            {
                StartCoroutine("dash");
                break;
            }
        }
        //Debug.Log(checkframe);
    }
    IEnumerator dash()
    {
		if (time >= Dashtime) {
            time = 0;
            Debug.Log("dash");
            for (int i = 0; i < 60; i++)
            {
                Vector3 movement = new Vector3(horizontal, 0, vertical);
                playermove.GetComponent<Rigidbody>().AddForce(movement * Dashspeed, ForceMode.Acceleration);
                yield return null;
            }
            Debug.Log("end");
        }
	}
}
