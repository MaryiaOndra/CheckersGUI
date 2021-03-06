using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckersGUi
{
    public abstract class BasePanel : MonoBehaviour
    {
        readonly int CLOSE_TRIGGER = Animator.StringToHash("Close");
        Animator panelAnimator;

        protected virtual void Awake()
        {
            panelAnimator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            var _closePanelListener = panelAnimator.GetBehaviour<ClosePanelListener>();
            _closePanelListener.ClosePanelAction = DiactivatePanel;
        }

        public virtual void CloseWithAnimation()
        {
            panelAnimator.SetTrigger(CLOSE_TRIGGER);
            AppPrefs.Save();
        }

        public virtual void DiactivatePanel()
        {
            gameObject.SetActive(false);
            AppPrefs.Save();
        }

        public virtual void ActivatePanel()
        {
            gameObject.SetActive(true);
        }
    }
}
