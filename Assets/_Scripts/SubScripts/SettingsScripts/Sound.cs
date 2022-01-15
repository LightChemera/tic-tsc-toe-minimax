using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Sound : MonoBehaviour
{

    [SerializeField]
    private Sprite _enableSprite;

    [SerializeField]
    private Sprite _disableSprite;

    private bool _audioEnabled = true;
    public bool AudioEnabled { get { return _audioEnabled; } set { SetAudio(value); } }

    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    void SetAudio(bool enabled)
    {
        if (enabled)
        {
            AudioListener.volume = 1f;
            _image.sprite = _enableSprite;
        }
        else
        {
            AudioListener.volume = 0f;
            _image.sprite = _disableSprite;
        }
        _audioEnabled = enabled;
    }

    public void SwitchAudio()
    {
        AudioEnabled = !AudioEnabled;
    }
}

