using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Sprite toggleOnImage;
    [SerializeField] private Sprite toggleOffImage;
    [SerializeField] private Button musicToggle;
    [SerializeField] private Button soundToggle;
    [SerializeField] private SoundsManager soundManager;

    private bool isMusicOn = true;
    private bool isSoundOn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMusicOn = PlayerPrefs.GetInt("SettingMusic", 1) == 1;
        isSoundOn = PlayerPrefs.GetInt("SettingSound", 1) == 1;
        MusicHandler();
        SoundHandler();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MusicTogglePressed()
    {
        isMusicOn = !isMusicOn;
        MusicHandler();
    }

    private void MusicHandler()
    {
        soundManager.EnableMusic(isMusicOn);
        musicToggle.image.sprite = isMusicOn ? toggleOnImage : toggleOffImage;
        PlayerPrefs.SetInt("SettingMusic", isMusicOn ? 1 : 0);
    }

    public void SoundTogglePressed()
    {
        isSoundOn = !isSoundOn;
        SoundHandler();
    }

    private void SoundHandler()
    {
        soundManager.EnableSounds(isSoundOn);
        soundToggle.image.sprite = isSoundOn ? toggleOnImage : toggleOffImage;
        PlayerPrefs.SetInt("SettingSound", isSoundOn ? 1 : 0);
    }
}
