using UnityEngine;
using System.Collections;

public class HeartScript : MonoBehaviour {

	public enum State {
		Punch, Shake, Squeeze, Idle
	}

	public static State needs;
	public static State feels;

	static Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		feels = State.Idle;
		needs = State.Punch;
		anim.SetInteger ("feelsState", 0);
	}
	
	void Update () {
		anim.SetBool ("squeezeBool", false);

	}

	public static void squeeze(){
		feels = State.Squeeze;
		animateSqueeze ();
	}

	static void animateSqueeze() {
		anim.SetBool ("squeezeBool", true);
	}

	public static void punch(){
		print ("PUNCH");
		feels = State.Punch;
		animatePunch ();
	}

	static void animatePunch(){
		anim.SetTrigger ("punchTrigger");
	}

	public static void shake(){
		print ("SHAKE");
		feels = State.Shake;
		animateShake ();
	}

	static void animateShake() {
		anim.SetTrigger ("shakeTrigger");
	}

}
