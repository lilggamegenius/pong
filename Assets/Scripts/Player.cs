using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	public Vector3 startPos;
	public float speed;
	public KeyCode upKey, downKey;

	// Use this for initialization
	void Start(){
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update (){
		bool up = Input.GetKey(upKey), down = Input.GetKey(downKey);
		if(up ^ down){
			if(up){ transform.position += Vector3.up * speed * Time.deltaTime; }

			if(down){ transform.position -= Vector3.up * speed * Time.deltaTime; }
		}
	}

	public void ResetPos(){transform.position = startPos;}
}
