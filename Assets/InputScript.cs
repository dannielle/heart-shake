using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class InputScript : MonoBehaviour {

	SerialPort stream = new SerialPort("/dev/cu.usbserial-DN00BXVG", 9600);
	int PUNCH_INT = 1;

	int punchCount;

	void Start () {
		punchCount = 0;
		stream.Open ();
		stream.ReadTimeout = 1;
	}
	
	void Update () {
		int inp = 0;

		if (stream.IsOpen) {
			try {
				inp = stream.ReadByte();
				//print (inp);
			} catch (System.Exception) {

			}
		}

		if (checkForShaken (punchCount)) {
			punchCount = 0;
			shake ();
			return;
		} else if (checkForPunch (inp)) {
			punchCount ++;
			punch ();
		}
	}

	bool checkForPunch(int input){
		if (input == PUNCH_INT || Input.GetKeyDown(KeyCode.P)) {
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

	void punch() {
		HeartScript.punch ();
	}
	
	void shake() {
		HeartScript.shake ();
	}

}
