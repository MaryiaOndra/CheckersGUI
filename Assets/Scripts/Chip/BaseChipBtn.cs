using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CheckersGUi
{
    public abstract class BaseChipBtn : MonoBehaviour
    {
        [SerializeField]
        Image chipSprite;

        Button button;

        protected abstract string PrefsKey { get; }
        protected abstract int DefoultIndx { get; }

        public int Index
        {
            get
            {
                int _index;
                if (!AppPrefs.HasKey(PrefsKey))
                    _index = DefoultIndx;
                else
                    _index = AppPrefs.GetInt(PrefsKey);

                return _index;
            }
            set
            {
                AppPrefs.SetInt(PrefsKey, value);
            }
        }

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public void SetSprite(Sprite _sprite)
        {
            chipSprite.sprite = _sprite;
        }

        public void ResetChipIndex()
        {
            Index = DefoultIndx;
        }
    }
}
