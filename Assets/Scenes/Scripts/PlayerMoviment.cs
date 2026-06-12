using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoviment : MonoBehaviour
{
    public float jump_force;

    [Header("UI")]
    public GameObject GameOver_obj;
    public TMP_Text text_score, text_max_score, text_score_gameover;

    private int score;
    private int max_score;
    private bool is_alive;

    private Rigidbody2D rb;

    void Start()
    {
        Time.timeScale = 1f;
        is_alive = true;
        rb = gameObject.GetComponent<Rigidbody2D>();

        text_score.text = score.ToString();
        text_max_score.text = max_score.ToString();

        LoadGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jump_force;
        }
        if (Input.GetKeyDown(KeyCode.X) && is_alive == false)
        {
            PlayerPrefs.DeleteAll();
        }

        if (score > max_score)
        {
            max_score = score;
        }

        text_max_score.text = max_score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            is_alive = false;
            SaveGame();
            Time.timeScale = 0;
            GameOver_obj.SetActive(true);
            text_score_gameover.text = $"Your Score: {score}\nMaximum Score: {max_score}";
        }

        if (collision.gameObject.tag == "Finish")
        {
            score++;
            text_score.text = score.ToString();;
            SaveGame();
        }
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("max_score", max_score);
    }

    void LoadGame()
    {
        max_score = PlayerPrefs.GetInt("max_score");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
