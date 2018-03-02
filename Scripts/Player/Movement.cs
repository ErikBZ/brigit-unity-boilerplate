using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float Speed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}

	private void Update()
	{
	}

	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		var raw = new Vector3(x, 0, z);
		var adjusted = Vector3.Normalize(raw) * Speed;
		gameObject.GetComponent<Rigidbody>().velocity = adjusted;
	}

	public void OnDisable()
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
