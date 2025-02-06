using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> CarObjects;
    [SerializeField] private List<MovementInfo> Locations = new();
    [SerializeField] private float CarSpeed = 1.0f;

    private List<string> Directions = new List<string> { "North", "East", "West", "South" };
    private List<CarInfo> SpawnedCars = new();


    void Start()
    {
        foreach (string Direction in Directions)
        {
            MovementInfo Info = new MovementInfo();
            Info.SpawnPoint = GameObject.Find(Direction).transform;
            Info.StopPoint = GameObject.Find(Direction + "_Stop").transform;
            Info.EndPoint = GameObject.Find(Direction + "_End").transform;
            Info.TrafficController = GameObject.Find("Traffic_" + Direction);

            Locations.Add(Info);
        }

        for(int i = 0; i < 1; i++)
        {
            MovementInfo movementInfo = Locations[i];
            GameObject Car = Instantiate(CarObjects[Random.Range(0, CarObjects.Count)], movementInfo.SpawnPoint.position, movementInfo.SpawnPoint.rotation);
            // Calculate rotation as the direction from the spawn point to the end point
            Vector3 Direction = movementInfo.EndPoint.position - movementInfo.SpawnPoint.position;
            Car.transform.rotation = Quaternion.LookRotation(Direction);
            Car.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            CarInfo carInfo = new CarInfo();
            carInfo.CarMovementInfo = movementInfo;
            carInfo.CarObject = Car;

            SpawnedCars.Add(carInfo);
        }
    }

    private void Update()
    {
        List<CarInfo> carsToProcess = new List<CarInfo>(SpawnedCars);

        foreach (CarInfo spawnedCar in carsToProcess)
        {
            LightController lightController = spawnedCar.CarMovementInfo.TrafficController.GetComponent<LightController>();

            Vector3 startToStop = spawnedCar.CarMovementInfo.StopPoint.position - spawnedCar.CarMovementInfo.SpawnPoint.position;
            Vector3 startToCar = spawnedCar.CarObject.transform.position - spawnedCar.CarMovementInfo.SpawnPoint.position;

            bool isBeforeStopPoint = Vector3.Dot(startToStop, startToCar) < Vector3.Dot(startToStop, startToStop);

            if (isBeforeStopPoint)
            {
                if (lightController.IsRed())
                {
                    if (Vector3.Distance(spawnedCar.CarObject.transform.position, spawnedCar.CarMovementInfo.StopPoint.position) < 0.5f)
                    {
                        spawnedCar.CarObject.transform.position = spawnedCar.CarObject.transform.position;
                    }
                    else
                    {
                        spawnedCar.CarObject.transform.position = Vector3.MoveTowards(spawnedCar.CarObject.transform.position, spawnedCar.CarMovementInfo.StopPoint.position, CarSpeed * 0.1f);
                    }
                }
                else
                {
                    spawnedCar.CarObject.transform.position = Vector3.MoveTowards(spawnedCar.CarObject.transform.position, spawnedCar.CarMovementInfo.EndPoint.position, CarSpeed * 0.1f);
                }
            }
            else
            {
                spawnedCar.CarObject.transform.position = Vector3.MoveTowards(spawnedCar.CarObject.transform.position, spawnedCar.CarMovementInfo.EndPoint.position, CarSpeed * 0.1f);
            }

            if (Vector3.Distance(spawnedCar.CarObject.transform.position, spawnedCar.CarMovementInfo.EndPoint.position) < 0.5f)
            {
                Destroy(spawnedCar.CarObject);
                SpawnedCars.Remove(spawnedCar);
            }
        }
    }
}
