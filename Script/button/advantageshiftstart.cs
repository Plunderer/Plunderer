using UnityEngine;
using System.Collections;

public class advantageshiftstart : MonoBehaviour {
	public GameObject advantageshift;
	public void ButtonPush() {
		advantageshift.SetActiveRecursively (true);
	}
}
