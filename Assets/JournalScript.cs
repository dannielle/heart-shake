using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JournalScript : MonoBehaviour {

	Text journalText;
	string[] journalTextArray;
	bool hasPressedSpace;
	int journalTextIndex;

	void Start () {
		journalText = GameObject.Find ("Journal").GetComponent<Text>();
		hasPressedSpace = false;
		journalTextIndex = 0;
		journalTextArray = new string[]{ "For some reason, love for me doesn’t seem to work like how it works for everyone else",
		                   "Love comes easily for me (squeeze)",
		                   "I’m serious!",
		                   "I have friends that I am in love with",
		                   "I have friends that I am in love with",
		                   "I have friends that I am in love with",
		                   "It sucks",
		                   "I want to be the person that stays up all night with them",
		                   "and talks about science and romance with them",
		                   "and all our life philosophies",
		                   "and listens to our favorite movie soundtracks",
		                   "You",
		                   "and you",
		                   "and you",
		                   "Punch to proceed.",
"and you punch",
"and you punch",
"and you punch",
"and you punch",
"and you punch",
"and you punch",
"Am I just an egomaniac?",
"//Drawing of me in high school, Me ->",
			"//one class <<visual break slide>>",
"* Why do I keep imagining myself kissing all of my friends",
"You",
"and you",
"and you punch",
"and you punch",
"and you punch",
"and you punch",
"and you punch",
"and you punch",
"and you punch",
"<<visual break slide>>",
"* in march 2015 i conducted a phone interview with an older woman and it was so beautiful",
"our conversation was so full of joy and i couldn’t stop smiling",
"we had chemistry",
"and she told me, “i can tell that you and i would be very close if we lived near each other”",
"and my heart felt so tight",
"in april 2015 i met the most intelligent and charming woman",
"and she was so cute and wore red lipstick and tilted her head",
"and she blushed and she asked me if i had a crush on her",
"in july 2015 I went to the grocery store once and saw the most beautiful woman",
"and i couldn’t stop thinking about her",
"i looked at salsa and i couldn’t stop thinking about her",
"she was just so beautiful"};
	}

	void Update() {
		changeText(journalTextArray[journalTextIndex], 1);
	}

	void changeText(string text, int fulfillment){
		journalText.text = text;
	}

	bool checkIfFulfilled() {
		return false;
	}
}
