using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicVolumeUI : MonoBehaviour
{
    public AudioClip track1;
    public AudioClip track2;
    public AudioClip track3;
    public AudioSource sfxf;
    public AudioSource hoorayyay;
    public Slider volumeSlider;
    public Button muteButton;
    public float globalVolume = 1f;
    public AudioSource source;
    //bool using1 = true;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.loop = true;
        source.playOnAwake = true;

        source.clip = track1;
        source.Play();

        if (volumeSlider != null)
        {
            volumeSlider.minValue = 0f;
            volumeSlider.maxValue = 1f;
            volumeSlider.value = 1f;
            volumeSlider.onValueChanged.AddListener(SetSliderVolume);
        }

        if (muteButton != null)
        {
            muteButton.onClick.AddListener(Mute);
        }

        SetSliderVolume(volumeSlider != null ? volumeSlider.value : 1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OnTheLevel();
        }
    }

    //void SwitchTrack()
    //{
    //    using1 = !using1;
    //    source.clip = using1 ? track1 : track2;
    //    source.Play();
    //    SetSliderVolume(volumeSlider != null ? volumeSlider.value : 1f);
    //}

    void OnTheLevel()
    {
        if (source.clip != track2)
        {
            source.clip = track2;
            source.Play();
            SetSliderVolume(volumeSlider != null ? volumeSlider.value : 1f);
        }
    }

    public void back() {
        if (source.clip != track1)
        {
            source.clip = track1;
            source.Play();
            SetSliderVolume(volumeSlider != null ? volumeSlider.value : 1f);
        }
    }
    public void scary()
    {
        if (source.clip != track3)
        {
            source.clip = track3;
            source.Play();
            SetSliderVolume(volumeSlider != null ? volumeSlider.value : 1f);
        }
    }


    void SetSliderVolume(float v)
    {
        source.volume = Mathf.Clamp01(v) * globalVolume;
        sfxf.volume = Mathf.Clamp01(v) * globalVolume;
        hoorayyay.volume = Mathf.Clamp01(v) * globalVolume;
    }

    void Mute()
    {
        if (volumeSlider != null) volumeSlider.value = 0f;
        source.volume = 0f;
        sfxf.volume = 0f;
        hoorayyay.volume = 0f;
    }

    public void sfx()
    {
        sfxf.Play();
    }
    
    public void hooray()
    {
        hoorayyay.Play();
    }
}

