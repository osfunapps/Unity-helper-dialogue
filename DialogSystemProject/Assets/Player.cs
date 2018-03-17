using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DialogueManager.DialogClosed dal = DialogClosed;		
		DialogueManager.Instance.SetDelegate (dal);	
	}

		private void DialogClosed(){
		GetComponent<Animator> ().SetBool ("StartAnim", true);
	}

}
