using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMesh>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        GetComponent<TextMesh>().color = Color.yellow;
    }

    void OnMouseExit()
    {
        GetComponent<TextMesh>().color = Color.white;
    }
}
