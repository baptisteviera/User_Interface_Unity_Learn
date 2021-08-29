using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    private Button button;
    public int difficulty;
    
    private GameManager myGameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        myGameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log("Niveau " + button.name);
        myGameManagerScript.startGame(difficulty);
    }
    
}
