using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TomeLoader : MonoBehaviour {
    public GameObject tomeRunner;
    public GameObject errorBox;
    InputField input;

	// Use this for initialization
	void Start () {
        input = gameObject.GetComponentInChildren<InputField>();
	}
    
    public void FinishEdit()
    {
        string path = input.text;
        if (!File.Exists(path))
        {
            string msg = String.Format("File Path: {0} does not exist. Make sure this path leads to a tome file" +
                                       "\n A path looks like: C:\\some\\folders\\add\\stuff\\text.file", path);
            Text errorConsole = errorBox.GetComponentInChildren<Text>();
            errorConsole.text = msg;
        }
        else
        {
            DialogueViewer viewer = tomeRunner.GetComponent<DialogueViewer>();
            viewer.Run(path);
            gameObject.SetActive(false);
        }
    }
}
