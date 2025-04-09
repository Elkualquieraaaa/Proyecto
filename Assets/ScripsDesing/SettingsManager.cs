using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider sliderMusica;
    public Slider sliderAudio;
    public AudioSource musicaSource;
    public AudioSource[] efectosSources;

    public Toggle toggleFullScreen;

    void Start()
    {
        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderAudio.onValueChanged.AddListener(CambiarVolumenAudio);
        toggleFullScreen.onValueChanged.AddListener(CambiarPantallaCompleta);

        sliderMusica.value = PlayerPrefs.GetFloat("VolumenMusica", 1f);
        sliderAudio.value = PlayerPrefs.GetFloat("VolumenAudio", 1f);
        toggleFullScreen.isOn = PlayerPrefs.GetInt("PantallaCompleta", 1) == 1;

        CambiarVolumenMusica(sliderMusica.value);
        CambiarVolumenAudio(sliderAudio.value);
        CambiarPantallaCompleta(toggleFullScreen.isOn);
    }

    public void CambiarVolumenMusica(float valor)
    {
        musicaSource.volume = valor;
        PlayerPrefs.SetFloat("VolumenMusica", valor);
    }

    public void CambiarVolumenAudio(float valor)
    {
        foreach (AudioSource sfx in efectosSources)
        {
            sfx.volume = valor;
        }
        PlayerPrefs.SetFloat("VolumenAudio", valor);
    }

    public void CambiarPantallaCompleta(bool esCompleta)
    {
        Screen.fullScreen = esCompleta;
        PlayerPrefs.SetInt("PantallaCompleta", esCompleta ? 1 : 0);
    }
}