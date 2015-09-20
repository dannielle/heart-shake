using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class InputScript : MonoBehaviour {

	SerialPort stream = new SerialPort("/dev/cu.usbserial-DN00BXVG", 9600);
	int PUNCH_INT = 1;
	int SHAKE_INT = 2;

	int punchCount;

	GUIText journalText;

	void Start () {
		journalText = GameObject.Find ("Journal").guiText;

		punchCount = 0;
		stream.Open ();
		stream.ReadTimeout = 1;
	}
	
	void Update () {
		journalText.text = "LOL CHANGED";

		int inp = 0;

		if (stream.IsOpen) {
			try {
				inp = stream.ReadByte();
				//print (inp);
			} catch (System.Exception) {

			}
		}
			
		bool isPunched = checkForPunch (inp);
		if (isPunched) {
			punchCount ++;
			punch();
		}

		bool isShaken = checkForShaken (punchCount);
		if (isShaken) {
			punchCount = 0;
			shake();
		}
	}

	bool checkForPunch(int input){
		if (input == PUNCH_INT) {
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
		print ("PUNCH");
	}
	
	void shake() {
		print ("SHAKE");
	}

}
