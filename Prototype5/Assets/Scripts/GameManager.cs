using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    private int score;
    public float spawnrate = 2.0f;
    public TextMeshProUGUI gameoverText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;
    void Start()
    {
       
    }

    public void startGame(int difficulty)
    {
        isGameActive = true;
        spawnrate /= difficulty;
        StartCoroutine(Spawntarget());
        score = 0;
        scoreText.text = "Score: " + score;
        updateScore(0);
        titleScreen.gameObject.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawntarget()
    {
        while (isGameActive) // utile
        {
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

    }

    public void gameOver()
    {
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
// importance de public
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
