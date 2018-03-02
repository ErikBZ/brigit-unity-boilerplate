using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class Talk : MonoBehaviour {
	public DialogueViewer Viewer;
	private Talkable target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && Input.GetMouseButtonDown(0))
		{
			gameObject.GetComponentInParent<Movement>().enabled = false;
			Viewer.Run(target.FullPath, TurnOn);
			enabled = false;
		}
	}

	// call back to be sent into DialogueViewer
	public void TurnOn()
	{
		gameObject.GetComponentInParent<Movement>().enabled = true;
		enabled = true;
	}

	public void OnTriggerEnter(Collider collider)
	{
		target = collider.GetComponent<Talkable>();
	}
	public void OnTriggerExit(Collider collider)
	{
		target = null;
	}
}
