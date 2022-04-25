using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class GameScreenTextSet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI helpPageOneTop;
    [SerializeField] private TextMeshProUGUI helpPageOneBottom;
    [SerializeField] private TextMeshProUGUI helpPageOneBtn1;
    [SerializeField] private TextMeshProUGUI helpPageOneBtn2;
    [SerializeField] private TextMeshProUGUI helpPageOneBtn3;
    [SerializeField] private TextMeshProUGUI helpPageTwoText;
    [SerializeField] private TextMeshProUGUI helpPageTwoBtn1;
    [SerializeField] private TextMeshProUGUI helpPageTwoBtn2;
    [SerializeField] private TextMeshProUGUI helpPageTwoBtn3;
    [SerializeField] private TextMeshProUGUI helpPageThreeText;
    [SerializeField] private TextMeshProUGUI helpPageThreeBtn1;
    [SerializeField] private TextMeshProUGUI helpPageThreeBtn2;
    [SerializeField] private TextMeshProUGUI helpPageThreeBtn3;
    [SerializeField] private TextMeshProUGUI optionsLanguage;
    [SerializeField] private TextMeshProUGUI optionsMusic;
    [SerializeField] private TextMeshProUGUI optionsSfx;
    [SerializeField] private TextMeshProUGUI optionsCredits;
    [SerializeField] private TextMeshProUGUI optionsRestart;
    [SerializeField] private TextMeshProUGUI exitText;
    [SerializeField] private TextMeshProUGUI exitQuit;
    [SerializeField] private TextMeshProUGUI exitContinue;
    [SerializeField] private TextMeshProUGUI resetText;
    [SerializeField] private TextMeshProUGUI resetYes;
    [SerializeField] private TextMeshProUGUI resetNo;
    [SerializeField] private TextMeshProUGUI endOfGameText;
    [SerializeField] private TextMeshProUGUI endOfGameBtn;
    [SerializeField] private TextMeshProUGUI upgradeReadyText;

    [SerializeField] private LocalizedString localizedHelpPageOneTop;
    [SerializeField] private LocalizedString localizedHelpPageOneBottom;
    [SerializeField] private LocalizedString localizedHelpPageBtn1;
    [SerializeField] private LocalizedString localizedHelpPageBtn2;
    [SerializeField] private LocalizedString localizedHelpPageBtn3;
    [SerializeField] private LocalizedString localizedHelpPageTwoText;
    [SerializeField] private LocalizedString localizedHelpPageThreeText;
    [SerializeField] private LocalizedString localizedOptionsLanguage;
    [SerializeField] private LocalizedString localizedOptionsMusic;
    [SerializeField] private LocalizedString localizedOptionsSfx;
    [SerializeField] private LocalizedString localizedOptionsCredits;
    [SerializeField] private LocalizedString localizedOptionsRestart;
    [SerializeField] private LocalizedString localizedExitText;
    [SerializeField] private LocalizedString localizedExitQuit;
    [SerializeField] private LocalizedString localizedExitContinue;
    [SerializeField] private LocalizedString localizedResetText;
    [SerializeField] private LocalizedString localizedResetYes;
    [SerializeField] private LocalizedString localizedResetNo;
    [SerializeField] private LocalizedString localizedEndOfGameText;
    [SerializeField] private LocalizedString localizedEndOfGameBtn;
    [SerializeField] private LocalizedString localizedUpgradeReadyText;

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
        helpPageOneTop.text = localizedHelpPageOneTop.GetLocalizedString();
        helpPageOneBottom.text = localizedHelpPageOneBottom.GetLocalizedString();
        helpPageOneBtn1.text = localizedHelpPageBtn1.GetLocalizedString();
        helpPageOneBtn2.text = localizedHelpPageBtn2.GetLocalizedString();
        helpPageOneBtn3.text = localizedHelpPageBtn3.GetLocalizedString();
        helpPageTwoText.text = localizedHelpPageTwoText.GetLocalizedString();
        helpPageTwoBtn1.text = localizedHelpPageBtn1.GetLocalizedString();
        helpPageTwoBtn2.text = localizedHelpPageBtn2.GetLocalizedString();
        helpPageTwoBtn3.text = localizedHelpPageBtn3.GetLocalizedString();
        helpPageThreeText.text = localizedHelpPageThreeText.GetLocalizedString();
        helpPageThreeBtn1.text = localizedHelpPageBtn1.GetLocalizedString();
        helpPageThreeBtn2.text = localizedHelpPageBtn2.GetLocalizedString();
        helpPageThreeBtn3.text = localizedHelpPageBtn3.GetLocalizedString();
        optionsLanguage.text = localizedOptionsLanguage.GetLocalizedString();
        optionsMusic.text = localizedOptionsMusic.GetLocalizedString();
        optionsSfx.text = localizedOptionsSfx.GetLocalizedString();
        optionsCredits.text = localizedOptionsCredits.GetLocalizedString();
        optionsRestart.text = localizedOptionsRestart.GetLocalizedString();
        exitText.text = localizedExitText.GetLocalizedString();
        exitQuit.text = localizedExitQuit.GetLocalizedString();
        exitContinue.text = localizedExitContinue.GetLocalizedString();
        resetText.text = localizedResetText.GetLocalizedString();
        resetYes.text = localizedResetYes.GetLocalizedString();
        resetNo.text = localizedResetNo.GetLocalizedString();
        endOfGameText.text = localizedEndOfGameText.GetLocalizedString();
        endOfGameBtn.text = localizedEndOfGameBtn.GetLocalizedString();
        upgradeReadyText.text = localizedUpgradeReadyText.GetLocalizedString();
    }
}
