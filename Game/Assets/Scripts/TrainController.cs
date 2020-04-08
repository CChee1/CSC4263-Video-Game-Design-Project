using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{

    public float sensitivity = 10f;

    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
           GetComponent<Rigidbody>().AddRelativeForce(-10, 0, 0);

        if (Input.GetKey(moveLeftKey)) {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, sensitivity, 0));
            print("left!");
        }
        
        if (Input.GetKey(moveRightKey)) {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, -sensitivity, 0));
            print("right!");
        }
    }
}