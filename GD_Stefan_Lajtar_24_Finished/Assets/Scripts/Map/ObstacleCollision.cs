using Assets.Scripts.Observer;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject theSanta;
    public GameObject charModel;
    public AudioSource crashSound;
    public GameObject mapControl;
    

    void OnTriggerEnter(Collider other) 
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        theSanta.GetComponent<SantaMovement>().enabled = false;
        charModel.GetComponent<Animator>().Play("HumanoidFall");
        mapControl.GetComponent<DistancePassed>().enabled = false;
        crashSound.Play();
        mapControl.GetComponent<EndRun>().enabled = true; 
    }
}
