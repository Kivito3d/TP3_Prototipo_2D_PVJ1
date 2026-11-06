using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    //paneles
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider sliderBar;

    [SerializeField] private Animator animatorFade;

    [SerializeField] private Animation animFade;
    //referencia healthsystem
    [SerializeField] private HealthSystem healthSystemPlayer;


    private void Start()
    {
        if (GameManager.Instance != null)
        {
 
            GameManager.Instance.OnChangeState += StateChage;
            GameManager.Instance.OnEnemyChange += UpdateEnemiesHUD;
            GameManager.Instance.OnPointsChange+= UpdatePointsHUD;
            animatorFade.SetTrigger("FadeIn");
        }
        
        if (healthSystemPlayer != null)
        {
            healthSystemPlayer.OnChangeHealthPlayer += UpdateBar;
        }


        //UpdateUI();
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnChangeState -= StateChage;
            GameManager.Instance.OnEnemyChange -= UpdateEnemiesHUD;
            GameManager.Instance.OnPointsChange += UpdatePointsHUD;

        }

        if (healthSystemPlayer != null)
        {
            healthSystemPlayer.OnChangeHealthPlayer -= UpdateBar;
        }
    }


    private void StateChage(GameState newState)
    {
        if(PausePanel!=null) PausePanel.SetActive(false);
        /*VictoryPanel.SetActive(false);
        GameOverPanel.SetActive(false);*/


        switch (newState)
        {
            case GameState.Start:
                animatorFade.SetTrigger("FadeIn");
                break;
            case GameState.Paused:
                //PausePanel.SetActive(true);
                UnlockCursor();
                break;
            case GameState.Victory:
                //VictoryPanel.SetActive(true);
                UnlockCursor();
                break;
            case GameState.GameOver:
                //GameOverPanel.SetActive(true);
                UnlockCursor();
                animatorFade.SetTrigger("FadeOut");
                break;
            case GameState.Playing:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }
    }

   
    private void UpdateEnemiesHUD(int currentEnemies)
    {
        /*if (scoreText != null)
        {
            //textMesh.text = currentEnemies.ToString();
            scoreText.text = $"{currentEnemies}";
        }*/
    }

    public void UpdatePointsHUD(int value)
    {
        if (GameManager.Instance == null) return;
        if (scoreText != null) 
        {
            scoreText.text = value.ToString() +" / "+ GameManager.Instance.RequiredPoints; 
        }
    }
    private void UpdateBar(float health)
    {
        if (sliderBar != null)
        {
            sliderBar.value = health;
        }
    }





    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //metodos para botones UI

    //exit

    //toggle panel
    public void ChangeScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
        //GameManager.Instance.
    }

    public void TogglePanel(GameObject panel)
    {
        if (panel != null)
        {
            bool toggle = panel.activeInHierarchy ? false : true;
            panel.SetActive(toggle);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }















    public void SetQuality(int qualityIndex)
    {
        
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int width, int height, bool isFullscreen)
    {
        Screen.SetResolution(width, height, isFullscreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed);
    }

    public void SetVSync(bool isEnabled)
    {
        QualitySettings.vSyncCount = isEnabled ? 1 : 0;
    }

    [SerializeField] private AudioMixer mainMixer;

    public void SetMasterVolume(float sliderValue)
    {
        // El AudioMixer usa decibelios (escala logaritmica), no valores lineales
        // Esta formula matematica convierte el valor del slider (0 a 1) a decibelios 
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    /*[Header ("UI Objects")]
    [SerializeField]private GameObject Pause_Panel;
    [SerializeField] private GameObject Hud_Panel;
    [SerializeField] private GameObject Victory_Panel;
    [SerializeField] private GameObject GameOver_Panel;
    [SerializeField]private TextMeshProUGUI enemiesText;
    [SerializeField] private Slider slider;


    [Header ("References")]
    [SerializeField] private HealthSystem playerHealth;



    private void OnDestroy()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.OnChangeState -= HandleStateChange;
            GameManager.Instance.OnEnemyCountChanged -= UpdateEnemyHUD;
        }
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnChangeState += HandleStateChange;
            GameManager.Instance.OnEnemyCountChanged += UpdateEnemyHUD;
        }

        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthBar;
        }

    }

    //metodo se ejecuta cada ves que cambia el estado
    private void HandleStateChange(GameManager.GameState newState)
    {
        Debug.Log("Entro");
        if (Pause_Panel) Pause_Panel.SetActive(false);
        if (Victory_Panel) Victory_Panel.SetActive(false);
        if(GameOver_Panel) GameOver_Panel.SetActive(false);

        switch (newState)
        {
            case GameManager.GameState.Paused:
                if (Pause_Panel) Pause_Panel.SetActive(true);
                break;
            case GameManager.GameState.Victory:
                if (Victory_Panel) Victory_Panel.SetActive(true);
                break;
            case GameManager.GameState.GameOver:
                if (GameOver_Panel) GameOver_Panel.SetActive(true);
                break;
            case GameManager.GameState.Playing:
                
                break;
        }
    }

    private void UpdateEnemyHUD(int currentEnemies)
    {
        if (enemiesText != null)
        {
            enemiesText.text = $"{currentEnemies}";
        }
    }


    private void UpdateHealthBar(float healthPercentage)
    {
        if (slider != null)
        {
            slider.value = healthPercentage;
        }
    }

    public void ChangeScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }
    public void TogglePanel(GameObject Panel)
    {
        if(Panel !=null)
        {
            bool toggle = Panel.activeInHierarchy ? false : true;
            Panel.SetActive(toggle);
        }
    }
    public void OpenPanel(GameObject panelToOpen)
    { 
        // Desactivamos todos los paneles
        // cargados en memoria 

        // Activamos solo el elgido
        panelToOpen.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
*/

}
