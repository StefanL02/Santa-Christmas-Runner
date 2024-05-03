using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControlScript : MonoBehaviour
{
    public static int coinCount;
    //public GameObject coinCountDisplay;
    public GameObject coinCountEndDisplay;

    void Update()
    {
        //coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
        coinCountEndDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
