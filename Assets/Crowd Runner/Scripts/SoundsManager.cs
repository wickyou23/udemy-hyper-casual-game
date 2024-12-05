using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource greenDoorDetectionSound;
    [SerializeField] private AudioSource redDoorDetectionSound;
    [SerializeField] private AudioSource levelCompletedSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource coinCollectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerDetection.onDoorDetected += OnPlayDoorDetectionSound;
        GameManager.OnGameStateChanged += OnGameStateChanged;
        Enemy.onRunnerDestroyed += OnRunnerDestroyed;
        Coin.onCoinCollected += OnCoinCollected;
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorDetected -= OnPlayDoorDetectionSound;
        GameManager.OnGameStateChanged -= OnGameStateChanged;
        Enemy.onRunnerDestroyed -= OnRunnerDestroyed;
        Coin.onCoinCollected -= OnCoinCollected;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnPlayDoorDetectionSound(Doors.BonusType bonusType)
    {
        switch (bonusType)
        {
            case Doors.BonusType.Addition:
            case Doors.BonusType.Multiplication:
                greenDoorDetectionSound.Play();
                break;
            case Doors.BonusType.Subtraction:
            case Doors.BonusType.Division:
                redDoorDetectionSound.Play();
                break;
        }
    }

    private void OnGameStateChanged(GameManager.GameState gameState)
    {
        switch (gameState)
        {
            case GameManager.GameState.LevelCompleted:
                levelCompletedSound.Play();
                break;
            case GameManager.GameState.GameOver:
                gameOverSound.Play();
                break;
        }
    }

    private void OnRunnerDestroyed()
    {
        runnerDieSound.Play();
    }

    private void OnCoinCollected()
    {
        coinCollectSound.Play();
    }

    public void DisableMusic()
    {
        backgroundMusic.mute = true;
    }

    public void EnableMusic(bool isEnable)
    {
        backgroundMusic.mute = !isEnable;
    }

    public void EnableSounds(bool isEnable)
    {
        greenDoorDetectionSound.mute = !isEnable;
        redDoorDetectionSound.mute = !isEnable;
        levelCompletedSound.mute = !isEnable;
        gameOverSound.mute = !isEnable;
        runnerDieSound.mute = !isEnable;
        coinCollectSound.mute = !isEnable;
    }
}
