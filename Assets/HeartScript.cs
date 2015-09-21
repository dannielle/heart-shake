using UnityEngine;
using System.Collections;

public class HeartScript : MonoBehaviour {

	public enum State {
		Punch, Shake, Squeeze, Idle
	}

	public static State needs;
	public static State feels;

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		feels = State.Idle;
		needs = State.Punch;
	}
	
	void Update () {
		switch (feels) {
		case State.Idle:
			anim.SetInteger ("feelsState", 0);
			break;
		case State.Punch:
			anim.SetInteger("feelsState", 1);
			break;
		case State.Shake:
			anim.SetInteger("feelsState", 2);
			break;
		case State.Squeeze:
			anim.SetInteger("feelsState", 3);
			break;
		default:
			anim.SetInteger ("feelsState", 0);
			break;
		}

	}

	public static void punch(){
		print ("PUNCH");
		feels = State.Punch;
	}

	public static void shake(){
		print ("SHAKE");
		feels = State.Shake;
	}
}
