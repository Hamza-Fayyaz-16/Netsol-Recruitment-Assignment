using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform currentTarget;
    private GameObject[] allEnemies = new GameObject[10];
    public Transform shootPoint;
    public GameObject bullet;


    public float bulletSpeed=20f;
    private void Start()
    {
        allEnemies = ObjectPooler.SharedInstance.AllActiveEnemies();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    
    void UpdateTarget() 
    {
        int counter = 0;
        
        for(int i=0; i<allEnemies.Length; i++)
        {
            if (allEnemies[i] == null)
            {
                counter++;
            }

        }
        if(counter == allEnemies.Length)
        {
           allEnemies = ObjectPooler.SharedInstance.AllActiveEnemies();
        }
        foreach (GameObject GO in allEnemies)
        {
            if (GO != null)
            {
                
                if (Vector3.Distance(GO.transform.position, shootPoint.position) < 2000) {
                    Vector3 dirFromEnemyToHeli = shootPoint.position - GO.transform.position;
                    float DotResult = Vector3.Dot(GO.transform.forward, dirFromEnemyToHeli);
                    //if (DotResult <0.3)
                    {
                        Shoot(GO.transform);
                        currentTarget = GO.transform;
                    }
                   
            
                }
            } 
        }
    }
    
    void Shoot(Transform target)
    {

        bullet = ObjectPooler.SharedInstance.GetPooledObject("Bullet");
        if (bullet != null)
        {
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;
            bullet.SetActive(true);
        }

        bullet.gameObject.GetComponent<Bullet>().SetTarget(target.gameObject);
        
    }
}


