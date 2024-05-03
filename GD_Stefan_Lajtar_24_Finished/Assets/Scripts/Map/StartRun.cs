using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    public GameObject ready;
    public GameObject steady;
    public GameObject getSet;
    public GameObject go;
    public GameObject fadeIn;
    public AudioSource countdownFx;
    public AudioSource goFx;

    void Start()
    {
        StartCoroutine(CountdownSequence());
    }

    IEnumerator CountdownSequence()
    {
        yield return new WaitForSeconds(1);
        ready.SetActive(true);
        countdownFx.Play();
        yield return new WaitForSeconds(1);
        steady.SetActive(true);
        countdownFx.Play();
        yield return new WaitForSeconds(1);
        getSet.SetActive(true);
        countdownFx.Play();
        yield return new WaitForSeconds(1);
        go.SetActive(true);
        goFx.Play();
        SantaMovement.canMove=true; 
    }
}
