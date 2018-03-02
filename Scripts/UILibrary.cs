using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Library{

    public static class UI {
        // Creates buttons, TODO add parameters for adding stuff like delegates and maybe settings parents
        public static GameObject CreateButton()
        {
            GameObject button = new GameObject();
            button.AddComponent<RectTransform>();
            button.AddComponent<Button>();
            return button;
        }

        public static GameObject CreateButton(Transform parent, Vector3 pos, UnityEngine.Events.UnityAction action)
        {
            GameObject button = CreateButton();
            button.transform.parent = parent;
            button.transform.position = pos;
            button.GetComponent<Button>().onClick.AddListener(action);
            return button;
        }
    }
}
