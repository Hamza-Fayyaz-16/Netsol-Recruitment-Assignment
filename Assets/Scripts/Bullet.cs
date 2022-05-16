using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target=null;

    void Update()
    {
        if (target != null)
        {
            Vector3.MoveTowards(transform.position, target.transform.position, 2f);
        }   
    }

    public void SetTarget(GameObject currTarget)
    {
        target = currTarget;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }
}
