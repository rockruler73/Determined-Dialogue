using System.Collections;
using UnityEngine;

/*
 * TextHandler 
 * Manipulates the instance of DialogueSystem in the game, making it appear and disappear as needed;
 * Loads and displays the appropriate text and portrait sprites based on NPC and whether player has spoken to the NPC before.
 * Plays dialogue sounds based on sound given to the Dialogue.
 */
public class TextHandler : MonoBehaviour
{
    Dialogue dialogue;

	//Make the textBox disappear at startup
    private void Start()
    {
        DialogueSystem.instance.textBox.SetActive(false);
    }

	//Loads dialogue of NPC interacted with and loads their first dialogue text
    public void LoadDialogue(Dialogue d)
    {
        dialogue = d;

		StartCoroutine(LoadText(0));
    }

	/*
	 * Loads appropriate dialogue based on ID.
	 * Loads appropriate sprite based on sprite specified in the Dialogue scriptable object.
	 * Loads text into a character array and prints out text one character at a time with appropriate sound (like in Undertale!).
	 * Waits for response from player (spacebar default).
	 */
    public IEnumerator LoadText(int dialogueID)
    {
		//Sets the text to blank before adding the new text
        DialogueSystem.instance.UIText.text = "";
        char[] textArray;

		//Sets the appropriate sprite and makes the text box visible
        DialogueSystem.instance.portrait.sprite = dialogue.sprite;
        DialogueSystem.instance.textBox.SetActive(true);

		//creates character array out of the text
		textArray = dialogue.messages[dialogueID].text.ToCharArray();

		//Prints each character in the array out one at a time with the given sound
		//(Sounds are recommended to be .035 seconds long, I've just had good luck with that)

		//Slow message
		if (dialogue.messages[dialogueID].messageSpeed == Message.MessageSpeed.Slow)
		{
			StartCoroutine(PrintText(textArray, Message.MessageSpeed.Slow));
			
			yield return null;
		}

		//Medium Speed message...
		if (dialogue.messages[dialogueID].messageSpeed == Message.MessageSpeed.Medium)
		{
			StartCoroutine(PrintText(textArray, Message.MessageSpeed.Medium));
			
			yield return null;
		}

		//FAST MESSAGE
		if (dialogue.messages[dialogueID].messageSpeed == Message.MessageSpeed.Fast)
		{
			StartCoroutine(PrintText(textArray, Message.MessageSpeed.Fast));
			
			yield return null;
		}

		

		//wait for a response from the player
        StartCoroutine(WaitForResponse(dialogueID));
    }

	IEnumerator PrintText(char[] textArray, Message.MessageSpeed speed)
	{
		float wait = 0.02f;
		//DialogueSystem.instance.UIText.GetComponent<VertexShakeA>().enabled = false;

		if(speed == Message.MessageSpeed.Slow)
		{
			//DialogueSystem.instance.UIText.GetComponent<VertexShakeA>().enabled = true;
			DialogueSystem.instance.audioSource.pitch = 0.5f;
			wait = 0.04f;
		}
		if (speed == Message.MessageSpeed.Medium)
		{
			DialogueSystem.instance.audioSource.pitch = 1f;
			wait = 0.02f;
		}
		if (speed == Message.MessageSpeed.Fast)
		{
			DialogueSystem.instance.audioSource.pitch = 1.5f;
			wait = 0.01f;
		}

		for (int i = 0; i < textArray.Length; i++)
		{
			DialogueSystem.instance.UIText.text += textArray[i];
			DialogueSystem.instance.audioSource.PlayOneShot(dialogue.sound);
			yield return new WaitForSeconds(wait);
		}
		//set it back to normal
		//DialogueSystem.instance.UIText.GetComponent<VertexShakeA>().enabled = false;
		DialogueSystem.instance.audioSource.pitch = 1f;
	}

	/*
	 * Waits for a response (default spacebar) from the player.
	 * Once response is received, either loads the next line of text if there is one, or 
	 * sets the UIText to blank and deactivates the text box.
	 */
    IEnumerator WaitForResponse(int currID)
    {
        bool responded = false;

        while (!responded) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                responded = true;
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }

		//if "next" is > 0 in the first "responses" field, load the next text
		//if not, set the text to "" and deactivate the textBox window (default is to set it to -1)
		if (dialogue.messages[currID].responses[0].next > 0)
		{
			StartCoroutine(LoadText(dialogue.messages[currID].responses[0].next));
		}
		else
		{
			DialogueSystem.instance.UIText.text = "";
			DialogueSystem.instance.textBox.SetActive(false);
		}

		yield return null;
    }

	/*
	 * Does that cool little extra-bit-of-dialogue-after-first-talking-to-the-character thing.
	 * I love that.
	 * Sets dialogue to the dialogue that's passed in; if UIText is "" (meaning it's empty), it loads the last message in the dialogue.
	 */
    public void EndOfConvo(Dialogue d)
    {
		dialogue = d;

        if(DialogueSystem.instance.UIText.text.CompareTo("") == 0)
        {
            StartCoroutine(LoadText(dialogue.messages.Length-1));
        }
    }
}
