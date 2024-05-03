using System.Collections;
using UnityEngine;

public class SectionDestroyer : MonoBehaviour
{
    public string parentName;

    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(100);
        if(parentName == "Section(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
