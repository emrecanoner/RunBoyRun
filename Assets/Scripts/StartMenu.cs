using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Player.Instance.gameplay = true;
        _button.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
         _button.onClick.RemoveListener(OnClick);
    }
}
