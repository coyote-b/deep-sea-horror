using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BubbleUI : MonoBehaviour
{
    private Sprite _originalImage;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private Sprite _bubblePop;

    [SerializeField]
    private Sprite _bubbleAdd;

    private void Start()
    {
        _originalImage = _image.sprite;
    }

    public IEnumerator Pop()
    {
        // This is yucky compared to using the animator, but...
        // I want to avoid making 6 different animations, and I can't use the sprite renderer for UI.
        _image.sprite = _bubblePop;

        yield return new WaitForSeconds(0.25f);

        _image.enabled = false;
    }

    public IEnumerator Blow()
    {
        _image.sprite = _bubbleAdd;
        _image.enabled = true;

        yield return new WaitForSeconds(0.25f);

        _image.sprite = _originalImage;
    }
}
