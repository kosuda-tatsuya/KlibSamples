﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kosu.UnityLibrary
{
    [RequireComponent(typeof(Toggle))]
    public class DebugUIToggle : MonoBehaviour
    {
        [SerializeField]
        private string _label = "Label";

        [SerializeField]
        private Text _labelText = null;

        [SerializeField]
        private bool _defaultValue = false;

        private Toggle _toggle;

        public System.Action<bool> onValueChanged;

        private bool _setLabel;

        private bool _setDefaultValue;

        private void Awake()
        {
            if (_setLabel == false) { _labelText.text = _label; }

            if (_setDefaultValue == false)
            {
                _toggle = GetComponent<Toggle>();
                _toggle.isOn = _defaultValue;
            }
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveAllListeners();
        }

        private void OnToggleValueChanged(bool isOn)
        {
            onValueChanged.SafeInvoke(isOn);
        }

        public void SetLabel(string label)
        {
            _setLabel = true;
            _labelText.text = label;
        }

        public void SetDefaultValue(bool defaultValue)
        {
            _setDefaultValue = true;

            if (_toggle == null) { _toggle = GetComponent<Toggle>(); }

            _toggle.isOn = defaultValue;
        }

    }
}
