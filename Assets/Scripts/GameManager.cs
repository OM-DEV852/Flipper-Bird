using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject gameOver;
    public static GameManager gameManager;
    [SerializeField]
    private Player player;

    private void Start()
    {
        gameManager = this;
    }

    private void Awake()
    {
        gameManager = this;

        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play() 
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1;
        player.enabled = true;

        //Si le damos al play depsues de haber estado jugando, nos aseguramos
        //al 100% que todos los pipes han sido destruidos.
        // Usar el FindObject con precuación y esta nueva version permite ordenarlo
        Pillars[] pillars = FindObjectsByType<Pillars>(FindObjectsSortMode.None);

        for (int i = 0; i < pillars.Length; i++) 
        {
            Destroy(pillars[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    public void GameOver() 
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore() 
    {
        score++;
        Debug.Log("1 punto añadido");
        scoreText.text = score.ToString();
    }
}