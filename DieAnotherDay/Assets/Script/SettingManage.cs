using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManage : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    public GameObject Menu;
    public GameObject Settings;

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
    public void DisplaySetting()
    {
        Menu.SetActive(false);
        Settings.SetActive(true);
    }
    public void ReturnMenu()
    {
        Settings.SetActive(false);
        Menu.SetActive(true);
    }
}
