using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : Singleton<DialogueManager> {

	private Queue<string> sentences;
	protected DialogueManager () {} // guarantee this will be always a singleton only - can't use the constructor!
	[SerializeField] private Text textName, textSentence;
	[SerializeField] private Animator dialogAnim;

	//callback
	public delegate void DialogClosed();
	private DialogClosed callback;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
	}

	//set callback
	public void SetDelegate(DialogClosed callback){
		this.callback = callback;
	}

	public void StartDialogue(Dialogue dialog){
	//	Debug.Log ("Starting conversation with: " + dialog.name);
		sentences.Clear ();

	
		//show dialog animation
		dialogAnim.SetBool("IsOpen", true);
		foreach(string sentence in dialog.sentences)
			sentences.Enqueue (sentence);
		textName.text = dialog.name;
		DisplayNextSentence ();
	}

	public void DisplayNextSentence(){
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}
		textSentence.text = sentences.Dequeue ();
	}

	private void EndDialogue(){
		Debug.Log ("conversation ended!");
		dialogAnim.SetBool("IsOpen", false);
		if (callback != null)
			callback.Invoke ();
	}

}
