using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {

	int punchCount;

	void Start () {
		punchCount = 0;
	}
	
	void Update () {
		if (checkForSqueeze()) {
			squeeze();
			return;
		} else if (checkForShaken (punchCount)) {
			punchCount = 0;
			shake ();
			return;
		} else if (checkForPunch ()) {
			punchCount ++;
			punch ();
		}
	}

	bool checkForSqueeze(){
		if (Input.GetKeyDown (KeyCode.S)) {
			return true;
		}
		return false;
	}

	bool checkForPunch(){
		if (Input.GetKeyDown(KeyCode.P)) {
			return true;
		}
		return false;
	}

	bool checkForShaken(int punchCount) {
		if (punchCount > 2) {
			return true;
		}
		return false;
	}

	void squeeze() {
		HeartScript.squeeze ();
	}

	void punch() {
		HeartScript.punch ();
	}
	
	void shake() {
		HeartScript.shake ();
	}

}
