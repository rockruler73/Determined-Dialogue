using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Interactable
 * Pop this on GameObjects (in addition to a 2d collider trigger) to make things interactable in your game.
 * Also have to give it a Dialogue, which you set up by right-clicking->Dialogue->New Dialogue.
 */
public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;
    public bool interactedWith = false;
	bool playerInRange = false;

    private void FixedUpdate()
    {
		//If the player is in range of the interactable and presses space, the interactable will SAY SOMETHING using the DialogueSystem's TextHandler!
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            Speak();
        }
    }

	/*
	 * If the interactable has never been interacted with before, it loads normal dialogue.
	 * If it has, it loads the "EndOfConvo", or that little bit of extra text you get after talking to someone the first time.
	 */
    public void Speak()
    {
        if (interactedWith == false)
        {
            DialogueSystem.instance.textHandler.LoadDialogue(dialogue);
            interactedWith = true;
        }
        else
        {
			DialogueSystem.instance.textHandler.EndOfConvo(dialogue);
        }

    }

	//Sets playerInRange to TRUE if the player is in the interactable's collider.
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			playerInRange = true;
		}
	}

	//Sets playerInRange to FALSE if the player is NOT in the interactable's collider. Crazy, right?
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerInRange = false;
		}
	}
}
