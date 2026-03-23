using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;

    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle muteToggle;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);
        muteToggle.onValueChanged.AddListener(AudioManager.Instance.MuteAll);
    }

    public void OpenPanel()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false); // Oculta el menú
    }

    public void ClosePanel()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true); // Vuelve a mostrar el menú
    }
}
