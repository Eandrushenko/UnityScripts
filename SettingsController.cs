using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour {

    public AudioMixer SFX;
    public AudioMixer Music;

    public Text CursorText;

    public void SetGameSFX(float volume)
    {
        SFX.SetFloat("Volume", Mathf.Log(volume) * 20);
    }

    public void SetGameMusic(float volume)
    {
        Music.SetFloat("Volume", Mathf.Log(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetCursor()
    {
        if (GameControl.control.Cursor == 1)
        {
            GameControl.control.Cursor = 0;
            CursorText.text = "Custom Cursor\n ON";
        }
        else if (GameControl.control.Cursor == 0)
        {
            GameControl.control.Cursor = 1;
            CursorText.text = "Custom Cursor\n OFF";
        }
    }

    public void GetCursor()
    {
        if (GameControl.control.Cursor == 0)
        {
            CursorText.text = "Custom Cursor\n ON";
        }
        else if (GameControl.control.Cursor == 1)
        {
            CursorText.text = "Custom Cursor\n OFF";
        }
    }

}
