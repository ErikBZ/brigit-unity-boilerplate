using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Brigit;
// need this for DialogSinglet and Descision
using Brigit.Structure.Exchange;
using Demo.Library;

namespace Demo
{
    public class ConversationDisplay : MonoBehaviour
    {
        // for no just this is fine
        public GameObject dialogParent;
        public GameObject choicesParent;
        public GameObject choiceButtonPrefab;

        Text dialogBox;
        private int choice = -1;
        Info.Type currentBox = Info.Type.Dialog;

        public void Start()
        {
            dialogBox = dialogParent.GetComponentInChildren<Text>();
        }

        // sets all it's gameobjects to Off so they aren't displayed
        public void Deactivate()
        {
            dialogParent.SetActive(false);
            choicesParent.SetActive(false);
			foreach(Transform child in choicesParent.transform)
			{
				Destroy(child.gameObject);
			}
        }

        // Update is called once per frame
        public void Show(Info info)
        {
            currentBox = info.type;
            switch (info.type)
            {
                case Info.Type.Descision:
                    choicesParent.SetActive(true);
                    ShowChoice(info.Descision);
                    break;
                case Info.Type.Dialog:
                    dialogParent.SetActive(true);
                    ShowDialog(info.Dialog);
                    break;
            }
        }

        private void ShowDialog(DialogSinglet dialog)
        {
            StringBuilder sb = new StringBuilder();
            // the first half
            sb.Append(dialog.Character);
            sb.Append(":\n");
            sb.Append(dialog.Text.Text);
            dialogBox.text = sb.ToString();
        }

        private int ConfirmDialog()
        {
            // TODO change this to "Confirm Button" or something like that
            return Input.GetMouseButtonDown(0) ? 0 : -1;
        }

        // this shows the choices
        private void ShowChoice(Descision descision)
        {
            choice = -1;
            // create the buttons
            for(int i=0; i<descision.Choices.Count; i++)
            {
                Choice ch = descision.Choices[i];

                // just using Instantiate for now, since this is just a prototype
                // but we should be using some sort of object pool
                GameObject button = Instantiate(choiceButtonPrefab);
                button.transform.SetParent(choicesParent.transform);
                button.transform.localPosition = new Vector3(0, (i-2)*85, 0);
                button.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
                button.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 600);
                button.GetComponent<Button>().onClick.AddListener(
                    () =>
                    {
                        choice = ch.NextNode;
                        Deactivate();
                    }
                );
                button.GetComponentInChildren<Text>().text = ch.Text;
            }
        }

        // I can just use buttons and sutff
        private int ConfirmChoice()
        {
            return choice;
        }

        public int CheckConfirm()
        {
            int confirm = -1;
            switch(currentBox)
            {
                case Info.Type.Dialog:
                    confirm = ConfirmDialog();
                    break;
                case Info.Type.Descision:
                    confirm = ConfirmChoice();
                    break;
            }
            return confirm;
        }
    }
}
