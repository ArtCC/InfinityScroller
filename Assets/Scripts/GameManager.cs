using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    
    private int score;
    private bool isGameOver;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    void Update() {
        ResetGame();
    }

    public void AddScore(int points) {
        score += points;

        if (score < 0) {
            score = 0;
        }

        scoreText.text = "Score: " + score;
    }

    public void StartGame() {
        gameOverPanel.SetActive(false);
    }

    public void StopGame() {
        isGameOver = true;
        
        StopScroll();
        StopSpawn();
        ShowGameOverPanel();
    }

    private void StopScroll() {
        Scroll[] scrollingObjects = FindObjectsOfType<Scroll>();

        foreach (Scroll scroll in scrollingObjects) {
            scroll.StopScroll();
        }
    }

    private void StopSpawn() {
        Spawner[] spwaners = FindObjectsOfType<Spawner>();
        
        foreach (Spawner spawner in spwaners) {
            spawner.StopSpawner();
        }
    }

    private void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    private void ResetGame() {
        if (isGameOver && Input.anyKeyDown) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}