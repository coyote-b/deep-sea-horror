using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleUI : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Sprite _bubblePop;

    public IEnumerator Pop()
    {
        // This is yucky compared to using the animator, but...
        // I want to avoid making 6 different animations, and I can't use the sprite renderer for UI.
        _image.sprite = _bubblePop;

        yield return new WaitForSeconds(0.25f);

        _image.enabled = false;
    }
}
