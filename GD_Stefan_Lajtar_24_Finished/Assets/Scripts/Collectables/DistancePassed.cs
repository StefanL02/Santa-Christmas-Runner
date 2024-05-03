
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistancePassed : MonoBehaviour
{
    public GameObject distanceDiplay;
    public GameObject distanceEndDisplay;
    public int distanceRun;
    public bool addingDistance = false;
    public float distanceDelay = 0.3f;

    void Update()
    {
        if (addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
    }

    IEnumerator AddingDistance()
    {
        distanceRun += 1;
        distanceDiplay.GetComponent<Text>().text = "" + distanceRun;
        distanceEndDisplay.GetComponent<Text>().text = "" + distanceRun;
        yield return new WaitForSeconds(distanceDelay);
        addingDistance = false;  
        if(distanceRun % 150 == 0)
        {
            SantaMovement.movementSpeed += .2f;
        }
    }
}
