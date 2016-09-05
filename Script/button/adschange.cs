using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class adschange : MonoBehaviour {
	AdvantageShift    advantageshift;
	PlayerController    playerController;
	PlayerLife    playerLife;
	public int AdvantageShiftCode = 0;
	int i;	// Use this for initialization
	void start (){

	}

	public void buttonpush(){
        GameObject obj = GameObject.Find("PlayerMove");
        playerLife = obj.GetComponent<PlayerLife>();
        GameObject obj2 = GameObject.Find("Player");
        playerController = obj2.GetComponent<PlayerController>();
        GameObject ads = GameObject.Find("PlayerMove");
        advantageshift = ads.GetComponent<AdvantageShift>();
        advantageshift.advantageshift = AdvantageShiftCode;
        playerController.MAXammo2 = playerController.MAXammo;
        if (AdvantageShiftCode == 3)
        {
            playerController.MAXammo = Mathf.Round(playerController.MAXammo * 0.9f);
        }
        else if (AdvantageShiftCode == 4)
        {
            playerController.MAXammo = Mathf.Round(playerController.MAXammo * 1.5f);
        }
        else if (AdvantageShiftCode == 8)
        {
            playerController.MAXammo = Mathf.Round(playerController.MAXammo * 0.8f);
        }
	}

}
