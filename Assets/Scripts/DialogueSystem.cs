using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * DialogueSystem. The engine that makes this little Dialogue System purr like a Egyptian cat-god.
 * Make an AudioSource in your scene. Plug it into audioSource.
 * In the Canvas instance in your scene, under TextBox, there is a Portrait. Plug 'er into the Portrait thing here.
 * Also drag the whole TextBox from the Canvas instance in your scene into the textBox field.
 * UIText? That's called "TextMeshPro Text" under your Canvas. Drag it swiftly and true!
 * Lastly, drag the TextHandler script from your Scripts folder on this bad boy, and you should be good to go!
 * (Whew, I'm tired from all this dragging...)
 */
public class DialogueSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public Image portrait;
    public GameObject textBox;
    public TextMeshProUGUI UIText;
	public TextHandler textHandler;

    static DialogueSystem _instance;
    public static DialogueSystem instance
    {
        get
        {
            return _instance;
        }
    }

    public void Awake()
    {
        if (_instance != null)
            Debug.LogError("You somehow have two dialogue systems in your scene at once");
        _instance = this;
    }
}