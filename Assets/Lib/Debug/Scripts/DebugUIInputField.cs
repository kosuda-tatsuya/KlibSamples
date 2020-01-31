﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kosu.UnityLibrary
{
    public class DebugUIInputField : MonoBehaviour
    {

        [SerializeField]
        private string _label = "Label";

        [SerializeField]
        private Text _labelText = null;

        private InputField _inputField;

        public System.Action<string> onEndEdit;

        private bool _setLabel;

        private void Awake()
        {
            if (_setLabel == false)
            {
                _labelText.text = _label;
            }

            _inputField = GetComponentInChildren<InputField>();
        }

        private void OnEnable()
        {
            _inputField.onEndEdit.AddListener(OnEndInputFieldEdit);
        }

        private void OnDisable()
        {
            _inputField.onEndEdit.RemoveAllListeners();
        }

        private void OnEndInputFieldEdit(string text)
        {
            onEndEdit.SafeInvoke(text);
        }

        public void SetLabel(string label)
        {
            _setLabel = true;
            _labelText.text = label;
        }

    }
}
