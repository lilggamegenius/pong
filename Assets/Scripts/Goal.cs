using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour{
	public delegate void Trigger();
	public event Trigger OnTrigger;


	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider other){
		if(!other.CompareTag("ball")){ return; }

		if(OnTrigger != null){ OnTrigger(); }
	}
}
