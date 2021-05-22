using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;

    private float music_volume = 1f;

    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = music_volume;
        PlayerPrefs.SetFloat("volume", music_volume);
    }

    public void updateVolume(float volume)
    {
        music_volume = volume;
    }
}
