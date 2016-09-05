using UnityEngine;
using System.Collections;

public class back : MonoBehaviour {
	public GameObject advantageshift;
	public void ButtonPush() {
		advantageshift.SetActiveRecursively (false);
	}
}
