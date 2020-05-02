using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform train;
    public float distance = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 look = train.position - transform.position;
        transform.forward = look.normalized;

        Vector3 lastTrainPosition = train.position - look.normalized * distance;
        transform.position = lastTrainPosition;   
    }
}
