using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Dialogue is where you make dialogues. Not all facets are fully built out yet, sorry.
 * you can give your NPCs IDs, which I assume will have some significance in the future.
 * IMPORTANT! Give your Dialogues the appropriate Sprites! This is used for portraits in the textHandler, so if you wanna see your pretty portraits, put them here!
 * NPC's can also have names. Might be worth something later on, but for now, it's just cute.
 * Drag your audio clips (preferably ogg) under "sound" and you'll hear your pretty NPCs speaking! (0.035s duration of clips recommended. Use Audacity for quick and dirty editing)
 * MESSAGES! This is when your dudes start speakin', my dude! Add Messages via the inspector, and you can make your NPCs say
 * literally
 * anything
 * you
 * want.
 */
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]
public class Dialogue : ScriptableObject
{
    public int npcID;
    public Sprite sprite;
    public string npcName;
	public AudioClip sound;
	public Message[] messages;
	
}
