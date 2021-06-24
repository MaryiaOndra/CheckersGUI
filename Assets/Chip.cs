using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour
{
    [SerializeField]
    Image chipSprite;

   
    public void Setup(Sprite _chipSprite)
    {
        chipSprite.sprite = _chipSprite;
    }
}
