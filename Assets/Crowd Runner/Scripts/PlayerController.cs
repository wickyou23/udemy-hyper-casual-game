using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slideSpeed;

    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;
    [SerializeField] private float roadWidth;
    [SerializeField] private PlayerAnimator playerAnimator;


    private Vector3 screenPosition;
    private Vector3 playerPosition;
    private bool canMove = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MoveForward();

            ManageSlide();
        }
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageSlide()
    {
        if (Input.GetMouseButtonDown(0))
        {
            screenPosition = Input.mousePosition;
            playerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDiff = Input.mousePosition.x - screenPosition.x;
            xScreenDiff /= Screen.width;
            xScreenDiff *= slideSpeed;

            Vector3 position = transform.position;
            position.x = playerPosition.x + xScreenDiff;
            position.x = Mathf.Clamp(position.x, -((roadWidth / 2) - crowdSystem.GetGroundRadius()), roadWidth / 2 - crowdSystem.GetGroundRadius());

            transform.position = position;
        }
    }

    private void OnGameStateChanged(GameManager.GameState current)
    {
        switch (current)
        {
            case GameManager.GameState.GameOver:
            case GameManager.GameState.LevelCompleted:
                canMove = false;
                playerAnimator.Idle();
                break;
            case GameManager.GameState.Game:
                canMove = true;
                playerAnimator.Run();
                break;
            default:
                break;
        }
    }
}
