using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    readonly int CLOSE_TRIGGER = Animator.StringToHash("Close");
    Animator panelAnimator;

    private void Awake()
    {
        panelAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        var _closePanelListener = panelAnimator.GetBehaviour<ClosePanelListener>();
        _closePanelListener.ClosePanelAction = DisablePanel;
    }

    public void ClosePanel()
    {
        panelAnimator.SetTrigger(CLOSE_TRIGGER);
    }

    void DisablePanel()
    {
        gameObject.SetActive(false);
    }
}
