using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class CheckSavedLocale : MonoBehaviour
{
    [SerializeField] private Locale finnish;
    [SerializeField] private Locale english;

    private int languageValue;
    private void Awake()
    {
        languageValue = PlayerPrefs.GetInt("Language", 0);
        DefaultLocale();
    }

    private void DefaultLocale()
    {
        if (languageValue == 0)
        {
            LocalizationSettings.SelectedLocale = finnish;
            return;
        }

        LocalizationSettings.SelectedLocale = english;
    }

    public void ChangeLocale()
    {
        if (LocalizationSettings.SelectedLocale == finnish)
        {
            LocalizationSettings.SelectedLocale = english;
            PlayerPrefs.SetInt("Language", 1);
            return;
        }

        LocalizationSettings.SelectedLocale = finnish;
        PlayerPrefs.SetInt("Language", 0);
    }
}
