using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JournalScript : MonoBehaviour {

	public class Excerpt {
		public string text;
		public int needMapping;
		
		public Excerpt(string text, int needMapping){
			this.text = text;
			this.needMapping = needMapping;
		}
	}

	Text journalText;
	ArrayList jt = new ArrayList();
	int journalTextIndex;
	bool fulfilled;

	Text instructionsText;

	int PUNCH = 1;
	int SHAKE = 2;
	int SQUEEZE = 3;
	int END = 5;

	void Start () {
		journalText = GameObject.Find ("Journal").GetComponent<Text>();
		instructionsText = GameObject.Find ("Instructions").GetComponent<Text> ();
		fulfilled = false;
		journalTextIndex = 0;
		jt.Add(new Excerpt("Heart shake. Writing & Code by Dee. Art by Jeff MacDonald. Music by Jared Le Doux.", PUNCH));
		jt.Add(new Excerpt("For some reason, love for me doesn’t seem to work like how it works for everyone else", PUNCH));
		jt.Add (new Excerpt ("Love comes easily for me", PUNCH));
		jt.Add (new Excerpt ("I'm serious!", SHAKE));
		jt.Add (new Excerpt ("I have friends that I am in love with", SQUEEZE));
		jt.Add (new Excerpt ("I have friends that I am deeply, madly, terrifyingly in love with", SQUEEZE));
		jt.Add (new Excerpt ("I have many friends that I am deeply, madly, terrifyingly in love with", PUNCH));
		jt.Add (new Excerpt ("It scares me", PUNCH));
		jt.Add (new Excerpt ("I want to be the person that stays up all night with them", SQUEEZE));
		jt.Add (new Excerpt ("and talks about science and romance with them", SQUEEZE));
		jt.Add (new Excerpt ("and all our life philosophies", SQUEEZE));
		jt.Add (new Excerpt ("and listens to our favorite movie soundtracks", SQUEEZE));
		jt.Add (new Excerpt ("You. I'm in love with you", SQUEEZE));
		jt.Add (new Excerpt ("(friend with whom I bought gym shorts and oreos with)", SQUEEZE));
		jt.Add (new Excerpt ("and you (friend with whom we played Rock Band)", SQUEEZE));
		jt.Add (new Excerpt ("and you (friend who lent me a broom)", SQUEEZE));
		jt.Add (new Excerpt ("", PUNCH));
		jt.Add (new Excerpt ("and you (friend who needed help writing a cover letter)", PUNCH));
		jt.Add (new Excerpt ("and you (friend who hates me because I dumped his best friend)", PUNCH));
		jt.Add (new Excerpt ("and you (friend who told me about his mom)", PUNCH));
		jt.Add (new Excerpt ("and you (friend who taught me how to fold fitted sheets)", PUNCH));
		jt.Add (new Excerpt ("and you (friend who gave me mix cds)", PUNCH));
		jt.Add (new Excerpt ("and you (friend who left a toothbrush over at my place)", PUNCH));
		jt.Add (new Excerpt ("Nobody thinks I should be able to love this much and it scares me", SHAKE));
		jt.Add (new Excerpt ("Or am I just an ego maniac?", SHAKE));
		jt.Add (new Excerpt ("everyone thinks my feelings towards my friends are bad", SHAKE));
		jt.Add (new Excerpt ("why does everyone think my feelings towards my friends are bad", SHAKE));
		jt.Add (new Excerpt ("* in march 2015 i conducted a phone interview with an older woman and it was so beautiful", SQUEEZE));
		jt.Add (new Excerpt ("our conversation was so full of joy and i couldn’t stop smiling", SQUEEZE));
		jt.Add (new Excerpt ("we had chemistry", SQUEEZE));
		jt.Add (new Excerpt ("and she told me, “i can tell that you and i would be very close if we lived near each other”", SQUEEZE));
		jt.Add (new Excerpt ("and my heart felt so tight", PUNCH));
		jt.Add (new Excerpt ("in april 2015 i met the most intelligent and charming woman", SQUEEZE));
		jt.Add (new Excerpt ("and she was so cute and wore red lipstick and tilted her head", SQUEEZE));
		jt.Add (new Excerpt ("and she blushed and she asked me if i had a crush on her", SHAKE));
		jt.Add (new Excerpt ("of course I did", SHAKE));
		jt.Add (new Excerpt ("in july 2015 I went to the grocery store once and saw the most beautiful woman", PUNCH));
		jt.Add (new Excerpt ("and i couldn’t stop thinking about her", PUNCH));
		jt.Add (new Excerpt ("i walked around for hours and i couldn’t stop thinking about her", PUNCH));
		jt.Add (new Excerpt ("she was just so beautiful", PUNCH));
		jt.Add (new Excerpt ("I hope I never have to change how I feel.", PUNCH));
		jt.Add (new Excerpt ("I hope I never have to change how I feel. End.", END));
		changeText(((Excerpt) jt[journalTextIndex]).text);
	}

	void Update() {
		if (journalTextIndex >= jt.Count) {
			return;
		}

		fulfilled = checkIfFulfilled ();

		if (fulfilled) {
			journalTextIndex++;
			changeText(((Excerpt) jt[journalTextIndex]).text);
			changeNeeds(((Excerpt) jt[journalTextIndex]).needMapping);

			HeartScript.feels = HeartScript.State.Idle;
			fulfilled = false;
		}
	}

	void changeText(string text){
		journalText.text = text;
	}

	void changeNeeds(int needMapping){
		switch (needMapping) {
		case 1:
			HeartScript.needs = HeartScript.State.Punch;
			instructionsText.text = "Punch me again.";
			break;
		case 2:
			HeartScript.needs = HeartScript.State.Shake;
			instructionsText.text = "Shake me to advance.";
			break;
		case 3:
			HeartScript.needs = HeartScript.State.Squeeze;
			instructionsText.text = "Squeeze me to keep talking.";
			break;
		default:
			HeartScript.needs = HeartScript.State.Punch;
			instructionsText.text = "";
			break;
		}
	}

	bool checkIfFulfilled() {
		return (HeartScript.needs == HeartScript.feels);
	}
}
