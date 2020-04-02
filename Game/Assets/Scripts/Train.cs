using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private Vector3 axis = new Vector3(1, 0, 1);
    public GameObject earth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(earth.transform.position, axis, 30 * Time.deltaTime);
        //transform.
    }
}
