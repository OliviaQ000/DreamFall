using UnityEngine;
using UnityEngine.Audio; //AudioMixer
using UnityEngine.UI;   //Slider

public class SoundSetting : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider ambientSlider;
    [SerializeField] Slider sfxSlider;

    [Header("Audio Mixer")]
    [SerializeField] AudioMixer mainMixer;

    private void Start()
    {
        float music = PlayerPrefs.GetFloat("MusicVolume", 100f);  //read the saved volume settings, if no saved value, use the default value.
        float ambient = PlayerPrefs.GetFloat("AmbientVolume", 50f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 50f);

        musicSlider.value = music;  // update slider position to display the same volume setting
        ambientSlider.value = ambient;
        sfxSlider.value = sfx;

        SetMusicVolume(music);  //apply the saved volume settings to AudioMixer
        SetAmbientVolume(ambient);
        SetSFXVolume(sfx);
        
    }

    public void SetMusicVolume(float value) //keep music volume setting the same when switch to another scene and after restart the game
    {                                      
       SetVolume("MusicVolume", value);
       PlayerPrefs.SetFloat("MusicVolume", value);  
    }

     public void SetAmbientVolume(float value)
    {
       SetVolume("AmbientVolume", value);
       PlayerPrefs.SetFloat("AmbientVolume", value);
    }

     public void SetSFXVolume(float value)
    {
       SetVolume("SFXVolume", value);
       PlayerPrefs.SetFloat("SFXVolume", value);
    }

    private void SetVolume(string mixerParameter, float value)
    {
        // Convert the slider value into decibels
        float volume;
        if (value <= 0f)
        {
            volume = -80f; //Set volume to min when slider is at 0
        }
        else
        {
            volume = Mathf.Log10(value/100f) * 20f; //convert linear slider to decibels

        }
        
        mainMixer.SetFloat(mixerParameter, volume);  //Apply the volume to corresponding AudioMixer group
    }
}
