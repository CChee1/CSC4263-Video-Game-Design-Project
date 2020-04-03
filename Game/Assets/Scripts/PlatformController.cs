using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static Transform PullingIntoStation;
    public static Transform Empty;
    public static Transform CoinMid;
    public static Transform StartPlat;
    public static Transform PassableAndLethal;
    public static Transform TwoLethal;


    public Transform[] platformPieces = { Empty, CoinMid, TwoLethal, PassableAndLethal };
    public int zScenePos = 2;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(StartPlat, new Vector3(0, 0, 0), StartPlat.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        int i = Random.Range(0, platformPieces.Length);
        if (zScenePos < 100)
        {
            Instantiate(platformPieces[i], new Vector3(0, 0, zScenePos), platformPieces[i].rotation);
        }
        else{
            Instantiate(PullingIntoStation, new Vector3(0, 0, zScenePos), PullingIntoStation.rotation);
        }
    }
}
