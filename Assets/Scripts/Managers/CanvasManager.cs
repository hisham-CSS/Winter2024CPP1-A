using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [Header("Button")]
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;
    public Button backButton;
    public Button pauseButton;
    public Button resumeButton;
    public Button returnToMenuButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    [Header("Text")]
    public TMP_Text livesText;
    public TMP_Text volSliderText;

    [Header("Slider")]
    public Slider volSlider;

    // Start is called before the first frame update

    void Start()
    {
        if (quitButton)
            quitButton.onClick.AddListener(Quit);

        if (playButton)
            playButton.onClick.AddListener(() => GameManager.Instance.ChangeScene(1));

        if (settingsButton)
            settingsButton.onClick.AddListener(() => SetMenus(settingsMenu, mainMenu));

        if (backButton)
            backButton.onClick.AddListener(() => SetMenus(mainMenu, settingsMenu));

        if (resumeButton)
            resumeButton.onClick.AddListener(() => SetMenus(null, pauseMenu));

        if (volSlider)
        {
            volSlider.onValueChanged.AddListener(OnSliderValueChanged);
            if (volSliderText)
                volSliderText.text = volSlider.value.ToString();
        }

        if (livesText)
        {
            GameManager.Instance.OnLivesValueChanged.AddListener(UpdateLifeText);
            livesText.text = "Lives: " + GameManager.Instance.lives.ToString();
        }
    }

    void UpdateLifeText(int value)
    {
        livesText.text = "Lives: " + value.ToString();
    }

    void SetMenus(GameObject menuToActivate, GameObject menuToInactivate)
    {
        if (menuToActivate)
            menuToActivate.SetActive(true);

        if (menuToInactivate)
            menuToInactivate.SetActive(false);
    }

    void OnSliderValueChanged(float value)
    {
        volSliderText.text = value.ToString();
    }

    void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu) return;

        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            //hints for the lab
            if (pauseMenu.activeSelf)
            {
                //do something to pause
            }
            else
            {
                //do something else
            }
        }
    }
}
