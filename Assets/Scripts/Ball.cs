using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{
	public Rigidbody Rigidbody;
	public Color color = Color.green;
	public Material Material;
	public float brightness;
	public Coroutine fade;
	public float initialSpeed = 15f;
	public float speedMultiplier = 1.1f;

	// Use this for initialization
	public void Start(){
		Rigidbody = GetComponent<Rigidbody>();
		Rigidbody.velocity = Vector3.left*initialSpeed;
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnCollisionEnter(){
		if(fade != null){
			StopCoroutine(fade);
		}
		fade = StartCoroutine(Fade());
		Rigidbody.velocity *= speedMultiplier;
	}

	public IEnumerator Fade(){
		brightness = 1f;
		while(brightness > 0f){
			yield return null;
			brightness -= Time.deltaTime;
			Material.SetColor("_EmissionColor", Material.color = Color.Lerp(color, Color.white, brightness));
		}

		brightness = 1f;
	}
}
