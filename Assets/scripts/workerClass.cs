using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OfficeManager;

public class workerClass : MonoBehaviour
{
    private float waitTime = 10.0f;
    private float timer = 0.0f;
    public GameObject hirePanel = null;
    public int count10000Frames = 0;
    public struct Worker
    {
        public string name;
        public int idwork;
        public int stage;
        public Sprite namimage;
    }
    public List<Worker> workers = new List<Worker>();
    private List<Worker> workerStorage = new List<Worker>();
    public Sprite image1 = null;
    public Sprite image2 = null;
    // Start is called before the first frame update
    void Start()
    {
        Worker worker = new Worker();
        worker.name = "Власенко Олег Федосович1";
        worker.idwork = 0;
        worker.stage = 0;
        worker.namimage = image1;
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович2";
        worker.namimage = image2;
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович3";
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович4";
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович5";
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович6";
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович7";
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович8";
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович9";
        worker.stage = 999;
        worker.namimage = image1;
        workerStorage.Add(worker);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Debug.Log("10 seconds");
            timer = 0;
            if (workers.Count >= 8)
            {
                int index = UnityEngine.Random.Range(0, workers.Count);
                workers.RemoveAt(index);
                workers.Insert(index, workerStorage[UnityEngine.Random.Range(0, workerStorage.Count)]);
            }
            else
            {
                workers.Add(workerStorage[UnityEngine.Random.Range(0, workerStorage.Count)]);

            }
            hirePanel.transform.GetComponent<hireManager>().updateInfo();
        }
    }
}
