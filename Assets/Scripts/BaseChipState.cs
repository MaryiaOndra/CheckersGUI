using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseChipState : MonoBehaviour
{
    [SerializeField]
    Image chipImg;

    Button button;

    public  abstract ChipsState ChipState { get; }
    public Action<ChipsState> NextStateAction { get; internal set; }
    protected abstract void OnButtonPressed();

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonPressed);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonPressed);
    }

    public void Setup(Sprite _sprite, Button _button) 
    {
        chipImg.sprite = _sprite;
        button = _button;
    }

    internal void Activate()
    {
        gameObject.SetActive(true);
    }

    internal void Diactivate()
    {
        gameObject.SetActive(false);
    }
}

