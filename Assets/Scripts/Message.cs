using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Basically used as a subset of Dialogue. An array of messages go into dialogues.
 * For now, I'm only supporting response arrays of size 1, but eventually more responses will be accepted!
 */
[System.Serializable]
public class Message
{
	public enum MessageSpeed { Medium, Slow, Fast };
	public MessageSpeed messageSpeed;
    public string text;
    public Response[] responses;
}
