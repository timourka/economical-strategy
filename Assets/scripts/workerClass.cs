using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OfficeManager;

public class workerClass : MonoBehaviour
{
    public int timeSpeed;
    public struct Task
    {
        public string name;
        public int difficulty;
        public int restTime;
        public int payment;
        public int progress;
    }
    public int date = 0;
    public int hours = 0;
    public int minutes = 0;
    public float seconds = 0;
    private float waitTime = 10.0f;
    private float timer = 0.0f;
    public GameObject hirePanel = null;
    public int count10000Frames = 0;
    public long Budget;
    public long credit = 0;
    public long maxCredit = 1000000000;
    public struct Worker
    {
        public string name;
        public int idwork;
        public int stage;
        public Sprite namimage;
    }
    public List<Task> tasksCurent = new List<Task>();
    public List<Task> tasks = new List<Task>();
    private List<Task> tasksStorage = new List<Task>();
    public List<Worker> workers = new List<Worker>();
    private List<Worker> workerStorage = new List<Worker>();
    public Sprite image1 = null;
    public Sprite image2 = null;
    public Sprite image3 = null;
    public Sprite image4 = null;
    // Start is called before the first frame update
    void Start()
    {
        timeSpeed = 5000;
        {
            Worker worker = new Worker();
            worker.name = "Власенко Олег Федосович1";
            worker.idwork = -1;
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
            worker.name = "Воронина";
            worker.stage = 999;
            worker.namimage = image3;
            workerStorage.Add(worker);
        }
        {
            Task task = new Task();
            task.name = "создать сайт";
            task.difficulty = 1;
            task.restTime = 36;
            task.payment = 10000;
            task.progress = 0;
            tasksStorage.Add(task);
            tasks.Add(tasksStorage[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        timer += time;
        seconds += time*timeSpeed;
        if (seconds > 60)
        {
            minutes += (int)seconds / 60;
            seconds %= 60;
        }
        if (minutes > 60)
        {
            hours += minutes / 60;
            minutes %= 60;
        }
        if (hours > 24)
        {
            date += hours / 24;
            hours %= 24;
        }
        if (timer > waitTime)
        {
            Debug.Log("10 seconds");
            timer = 0;
            if (tasks.Count >= 6)
            {
                int index = UnityEngine.Random.Range(0, tasks.Count);
                tasks.RemoveAt(index);
                tasks.Insert(index, tasksStorage[UnityEngine.Random.Range(0, tasksStorage.Count)]);
            }
            else
            {
                tasks.Add(tasksStorage[UnityEngine.Random.Range(0, tasksStorage.Count)]);

            }
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
