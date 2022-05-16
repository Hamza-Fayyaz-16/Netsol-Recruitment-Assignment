using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrld;
using Wrld.Space;
using Wrld.Transport;

public class SpawningController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab = null;

    //37.77109  -122.4684
    private LatLong enemyLocation1 = LatLong.FromDegrees(37.795159, -122.404336);
    private LatLong enemyLocation2 = LatLong.FromDegrees(37.795173, -122.404229);
    //private LatLong enemyLocation3 = LatLong.FromDegrees(37.795159, -122.404336);
    //private LatLong enemyLocation4 = LatLong.FromDegrees(37.795173, -122.404229);
    //private LatLong enemyLocation5 = LatLong.FromDegrees(37.795159, -122.404336);
    //private LatLong enemyLocation6 = LatLong.FromDegrees(37.795173, -122.404229);
    //private LatLong enemyLocation7 = LatLong.FromDegrees(37.795159, -122.404336);
    //private LatLong enemyLocation8 = LatLong.FromDegrees(37.795173, -122.404229);


    private void Start()
    {
        StartCoroutine(EnemySpawning());
       
    }

    IEnumerator EnemySpawning()
    {
        
        {
            yield return new WaitForSeconds(8.0f);

            MakeEnemyOnBuilding(enemyLocation1);
            MakeEnemyOnBuilding(enemyLocation2);
            
        }
    }

    void MakeEnemyOnBuilding(LatLong latLong)
    {
        var ray = Api.Instance.SpacesApi.LatLongToVerticallyDownRay(latLong);
        LatLongAltitude buildingIntersectionPoint;
        var didIntersectBuilding = Api.Instance.BuildingsApi.TryFindIntersectionWithBuilding(ray, out buildingIntersectionPoint);
        if (didIntersectBuilding)
        {
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject("Enemy");
            if (enemy != null)
            {
               enemy.GetComponent<GeographicTransform>().SetPosition(buildingIntersectionPoint.GetLatLong());

               enemy.transform.localPosition = Vector3.up * (float)buildingIntersectionPoint.GetAltitude()+ new Vector3(0,enemy.transform.localScale.y/2,0);
               enemy.SetActive(true);
            }
        }
    }

    void MakeEnemyOnRoads(LatLong latLong)
    {
        var ray = Api.Instance.SpacesApi.LatLongToVerticallyDownRay(latLong);
        LatLongAltitude buildingIntersectionPoint;
        var didIntersectBuilding = Api.Instance.BuildingsApi.TryFindIntersectionWithBuilding(ray, out buildingIntersectionPoint);
        if (didIntersectBuilding)
        {
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject("Enemy");
            if (enemy != null)
            {
                enemy.GetComponent<GeographicTransform>().SetPosition(buildingIntersectionPoint.GetLatLong());

                enemy.transform.localPosition = Vector3.up * (float)buildingIntersectionPoint.GetAltitude() + new Vector3(0, enemy.transform.localScale.y / 2, 0);
                enemy.SetActive(true);
            }
        }
    }


    

}
