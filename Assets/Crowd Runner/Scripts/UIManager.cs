using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mainGame;
    [SerializeField] private GameObject retryPanel;
    [SerializeField] private GameObject successPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject coinBadge;
    [SerializeField] private Slider slider;
    [SerializeField] private Text levelText;
    [SerializeField] private Text coinText;

    private int coinPoints;

    void Start()
    {
        levelText.text = "Level " + (ChunkManager.Instance.GetLevel() + 1);

        coinPoints = PlayerPrefs.GetInt("Coin", 0);
        coinText.text = coinPoints.ToString();

        GameManager.OnGameStateChanged += OnGameStateChanged;
        Coin.onCoinCollected += OnCoinCollected;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
        Coin.onCoinCollected -= OnCoinCollected;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
    }

    public void PlayButtonPressed()
    {
        GameManager.Instance.ChangeGameState(GameManager.GameState.Game);

        mainMenu.SetActive(false);
        mainGame.SetActive(true);
    }

    public void RetryButtonPressed()
    {
        GameManager.Instance.ChangeGameState(GameManager.GameState.Menu);
        GameManager.Instance.ReloadGame();

        mainMenu.SetActive(true);
        mainGame.SetActive(false);
        retryPanel.SetActive(false);
    }

    public void NextLevelButtonPressed()
    {
        GameManager.Instance.ChangeGameState(GameManager.GameState.Menu);
        GameManager.Instance.ReloadGame();
    }


    public void SettingButtonPressed()
    {
        settingPanel.SetActive(true);
    }

    public void PopupBackgroundPressed()
    {
        settingPanel.SetActive(false);
    }

    private void UpdateSlider()
    {
        slider.value = PlayerController.Instance.transform.position.z / ChunkManager.Instance.GetFinhisLineZ();
    }

    private void OnGameStateChanged(GameManager.GameState gameState)
    {
        switch (gameState)
        {
            case GameManager.GameState.Menu:
                mainMenu.SetActive(true);
                mainGame.SetActive(false);
                retryPanel.SetActive(false);
                successPanel.SetActive(false);
                break;
            case GameManager.GameState.Game:
                mainMenu.SetActive(false);
                mainGame.SetActive(true);
                retryPanel.SetActive(false);
                successPanel.SetActive(false);
                break;
            case GameManager.GameState.LevelCompleted:
                successPanel.SetActive(true);
                break;
            case GameManager.GameState.GameOver:
                retryPanel.SetActive(true);
                break;
        }
    }


    private void OnCoinCollected()
    {
        coinText.text = (coinPoints += 1).ToString();
        PlayerPrefs.SetInt("Coin", coinPoints);

        LeanTween.scale(coinText.gameObject, Vector3.one * 1.5f, .1f).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
        {
            LeanTween.scale(coinText.gameObject, Vector3.one, .1f).setEase(LeanTweenType.easeInQuad);
        });
    }
}
