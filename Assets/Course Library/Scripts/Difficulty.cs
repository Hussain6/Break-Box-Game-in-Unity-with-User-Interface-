using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Difficulty : MonoBehaviour
{
    private Button diff;
    public int difficulty;
    private GameMangerscript go;
    // Start is called before the first frame update
    void Start()
    {
        diff = GetComponent<Button>();
        diff.onClick.AddListener(setDifficulty);
        go = GameObject.Find("GameManager").GetComponent<GameMangerscript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setDifficulty()
    {
        go.startGame(difficulty);
    }
}
