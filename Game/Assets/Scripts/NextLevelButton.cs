using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public GameObject train;
    private Vector3 next = new Vector3(55, 0, 0);
    private bool move = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (train.transform.position.x == 55 && move)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (move)
        {
            Debug.Log("X Pos: " + train.transform.position.x);
            train.transform.position = Vector3.MoveTowards(train.transform.position, next, 15 * Time.deltaTime);
        }
        
    }

    public void NextLevel()
    {
        move = true;
    }
}
