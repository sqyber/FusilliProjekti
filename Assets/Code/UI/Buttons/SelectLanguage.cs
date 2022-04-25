using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class SelectLanguage : MonoBehaviour
{
    [SerializeField] private Locale language;

    public void SetLanguage()
    {
        LocalizationSettings.SelectedLocale = language;
    }
}