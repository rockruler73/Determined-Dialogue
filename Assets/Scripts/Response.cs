using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Response
 * "Next" is the big one here. In order for the next MESSAGE to show up, your RESPONSE's "Next" field needs to be the ID of the next MESSAGE.
 * e.g. if MESSAGE 0 (computery stuff starts at 0) is "Hey, you! You suck egg whites!" and MESSAGE 1 is "Just kidding. Man, that was rude. Wanna get some ice cream?",
 * MESSAGE 0's "next" field would need to be set to 1 in order for you to hear the much-deserved apology.
 * **IMPORTANT!** At the end of a "Messages" array, the "next" field needs to be -1 in order for things not to get super buggy.
 */
[System.Serializable]
public class Response
{
    public int next;
    public string reply;
    public string prereq;
    public string trigger;
}
