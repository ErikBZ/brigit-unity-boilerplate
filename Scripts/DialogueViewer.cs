using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brigit;
using Demo;

public class DialogueViewer : MonoBehaviour {

    private enum State { Waiting, Update, Done }
    State state = State.Update;
    Conversation conv;
    ConversationDisplay convDisplay;
	Action postExecution = null;

    // Use this for initialization
    void Start () {
        convDisplay = gameObject.GetComponent<ConversationDisplay>();
	}

    public void Run(String tome, Action postExecution=null)
    {
        conv = ConversationLoader.CreateConversation(tome);
        state = State.Update;

        // activate itself so it can start running
        gameObject.SetActive(true);

		if(postExecution != null)
		{
			this.postExecution = postExecution;
		}
    }
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.Update:
                var info = conv.GetInfo();
                convDisplay.Show(info);
                state = State.Waiting;
                break;
            case State.Waiting:
                int next = WaitForConfirm();
                if (next != -1)
                {
                    Debug.Log(next);

                    if(!conv.Next(next))
                    {
                        throw new Exception("Could not go forward, next is " + next.ToString());
                    }
                    state = conv.Complete ? State.Done : State.Update;
                    // will be activated on the next update
                    convDisplay.Deactivate();
                }
                break;
			case State.Done:

				if(postExecution != null)
				{
					postExecution();
				}

				gameObject.SetActive(false);
				break;
        }
	}

    private int WaitForConfirm()
    {
        return convDisplay.CheckConfirm();
    }
}
