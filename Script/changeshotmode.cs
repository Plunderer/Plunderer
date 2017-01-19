using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
public class changeshotmode : MonoBehaviour {
	/// <summary>
	/// スティックモードかボタンボードに射撃方法を切り替えるスクリプト
	/// </summary>
	public Joystick st;//スティックのスクリプトを参照
    public Sprite[] image = new Sprite[2];
    public Image sitae;
	bool i = true;
	// Use this for initialization
	public void change(){
		if (i) {
			st.stickmode = false;
            st.GetComponent<Image>().sprite = image[1];
            sitae.enabled = false;
			i = false;
			transform.localPosition = new Vector2(20,transform.localPosition.y);
		} else {
			st.stickmode = true;
            st.GetComponent<Image>().sprite = image[0];
            sitae.enabled = true;
			i = true;
			transform.localPosition = new Vector2(-20,transform.localPosition.y);
		}
	}
}
