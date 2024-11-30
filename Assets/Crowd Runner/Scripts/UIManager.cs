using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mainGame;
    [SerializeField] private Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainGame.SetActive(false);
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

    private void UpdateSlider()
    {
        slider.value = PlayerController.Instance.transform.position.z / ChunkManager.Instance.GetFinhisLineZ();
    }
}
