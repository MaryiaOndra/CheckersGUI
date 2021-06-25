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

    public Sprite ChipSprite => chipImg.sprite;
    public int Index { get; private set; }
    public  abstract ChipsState ChipState { get; }
    public Action<ChipsState> NextStateAction { get; internal set; }
    public Action ChooseChipAction { get; internal set; }
    public Action ChangeChipState { get; internal set; }

    protected abstract void OnButtonPressed();

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonPressed);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonPressed);
    }

    public void Setup(Sprite _sprite, Button _button, int _index) 
    {
        chipImg.sprite = _sprite;
        button = _button;
        Index = _index;
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    internal void Diactivate()
    {
        gameObject.SetActive(false);
    }
}


