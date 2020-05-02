using UnityEngine;
using System.Collections;

public class Obstacle {

    void OnTriggerEnter(Collider col)
    {
        //if the player hits one obstacle, it's game over
        if(col.gameObject.tag == Constants.PlayerTag)
        {
            GameManager.Instance.Die();
        }
    }
}
