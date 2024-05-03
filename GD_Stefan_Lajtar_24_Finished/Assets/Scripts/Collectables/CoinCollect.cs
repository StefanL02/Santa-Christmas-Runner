//using Assets.Scripts.Collectables;
using Assets.Scripts.Observer;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public AudioSource coinFX;

    void OnTriggerEnter(Collider other) 
    {
        coinFX.Play();
        CollectableControlScript.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
