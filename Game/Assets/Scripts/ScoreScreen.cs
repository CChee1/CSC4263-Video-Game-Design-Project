using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    public GameObject train;
    public Vector3 endpoint = new Vector3(0, 0, 0);
    public Text scoreText;
    private int score;
    private int count;
    public GameObject nextButton;
    public bool isNextButton;
    private bool move = true;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        scoreText.text = "Score:\n" + score * 1000;
        count = score * 1000;
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + PlayerPrefs.GetInt("cars"));
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (train.transform.position.x != 0 && move)
        {
            train.transform.position = Vector3.MoveTowards(train.transform.position, endpoint, 15*Time.deltaTime);
        }
        else
        {
            move = false;
            
            if (count != PlayerPrefs.GetInt("score") * 1000)
            {
                count += 10;
                scoreText.text = "Score:\n" + count;
            } 
        }
    }

    void OnMouseUp()
    {
        if (isNextButton)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
