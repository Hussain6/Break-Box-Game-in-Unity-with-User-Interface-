using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMangerscript : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI score_object;
    public GameObject titlescreen;
    public TextMeshProUGUI gameOver;
    public Button restart;
    public bool isgameactive;
    private float time=1.0f;
    int Score;
    // Start is called before the first frame update
    void Start()
    {

    }
    IEnumerator Generate()
    {
        if(isgameactive)
        {
            while (true)
            {
                yield return new WaitForSeconds(time);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        score_object.text = "Score: " + Score;
    }
   public void update_score(int scoretoadd)
    {
        Score += scoretoadd;
    }
    public void gameover()
    {
        isgameactive = false;
        restart.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void startGame(int diff)
    {
        time = time / diff;
        isgameactive = true;
        StartCoroutine(Generate());
        Score = 0;
        titlescreen.gameObject.SetActive(false);
    }
}
