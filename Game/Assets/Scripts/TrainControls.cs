using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainControls : MonoBehaviour
{
    public GameObject train;
    List<GameObject> cars = new List<GameObject>();
    Rigidbody locoRB;
    public float speed = 20.0f;
    public float turn = 40.0f;
    public bool pause = false;

    public GameObject wagonModel;
    public GameObject wagon;
    public GameObject wagon1;
    public GameObject wagon2;
    public GameObject wagon3;
    public Text carsText;

    // Start is called before the first frame update
    void Start()
    {
        cars.Add(wagon);
        cars.Add(wagon1);
        cars.Add(wagon2);
        cars.Add(wagon3);
        locoRB = GetComponent<Rigidbody>();
        carsText.text = "Passenger Cars \n" + cars.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            if (Input.GetKey(KeyCode.W))
            {
                locoRB.AddForce(-GetComponent<Transform>().right * 7 * speed * Time.deltaTime);
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                //GetComponent<Rigidbody>().AddTorque(new Vector3(0, turn, 0));
                locoRB.AddForce(-GetComponent<Transform>().forward * 2 * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                //GetComponent<Rigidbody>().AddTorque(new Vector3(0, -turn, 0));
                locoRB.AddForce(GetComponent<Transform>().forward * 2 * speed * Time.deltaTime);
            }
        }   

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGame();
        }

        if (transform.position.y <= -100)
        {
            RestartLevel();
        }
    }

    void PauseGame()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 1;
        }
        else
        {
            pause = true;
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin collected");
            other.gameObject.SetActive(false);
            CreateWagon();
            UpdateDisplay();
        }

        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("You finished the level!");
            PauseGame();
        }

        if (other.gameObject.tag == "Passable")
        {
            other.gameObject.SetActive(false);

            if (cars.Count > 1)
            {
                DestroyWagon();
            }
            else
            {
                RestartLevel();
            }

            UpdateDisplay();
        }
    }

    void CreateWagon()
    {
        GameObject lastCar = cars[cars.Count - 1];
        Vector3 lastCarPos = lastCar.transform.position;
        Vector3 newCarPos = lastCarPos - new Vector3(-10, 0, 0);
        GameObject newCar = Instantiate(lastCar, newCarPos, Quaternion.identity);
        newCar.transform.parent = lastCar.transform.parent;
        cars.Add(newCar);
    }

    void DestroyWagon()
    {
        GameObject lastCar = cars[cars.Count - 1];
        cars.RemoveAt(cars.Count - 1);
        Destroy(lastCar);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateDisplay()
    {
        carsText.text = "Passenger Cars \n" + cars.Count;

        if (cars.Count < 2)
        {
            carsText.color = Color.red;
        }
    }
}