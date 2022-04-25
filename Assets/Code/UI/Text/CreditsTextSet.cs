using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class CreditsTextSet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI creditsText;
    [SerializeField] private TextMeshProUGUI creditsButtonText;

    [SerializeField] private LocalizedString localizedText;
    [SerializeField] private LocalizedString localizedButtonText;
    
    // Start is called before the first frame update
    private void Start()
    {
        SetTexts();
    }

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
    }

    private void OnLocaleChanged(Locale obj)
    {
        SetTexts();
    }

    private void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }
    private void SetTexts()
    {
        creditsText.text = localizedText.GetLocalizedString();
        creditsButtonText.text = localizedButtonText.GetLocalizedString();
    }
}
