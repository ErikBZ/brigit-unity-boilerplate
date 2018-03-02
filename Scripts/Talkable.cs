using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Talkable : MonoBehaviour {

	public string TomeScript;
	private string root;

	public string FullPath
	{
		get
		{
			return Path.Combine(root, TomeScript);
		}
	}

	// Use this for initialization
	void Start () {
		root = Path.Combine(Directory.GetCurrentDirectory(), @"Assets\BrigitScripts");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
