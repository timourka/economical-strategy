using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OfficeManager;

public class workerClass : MonoBehaviour
{
    public int timeSpeed;
    public GameObject map;
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
    public long payedCredit = 0;
    public long Budget;
    public long credit = 0;
    public long maxCredit = 600000;
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
            worker.stage = 1;
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
            task.payment = 100000;
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
            Budget -= credit / 36 / 30 * hours / 24;
            payedCredit += credit / 36 / 30 * hours / 24;
            credit -= credit / 36 / 30 * hours / 24;
            for (int i = 0; i < tasksCurent.Count; i++)
            {
                Task tempTask = tasksCurent[i];
                tempTask.restTime -= hours / 24;
                if (tempTask.restTime < 0)
                {
                    tasksCurent.RemoveAt(i);
                    int index = i;
                    for (int o = 1; o < map.transform.childCount; o++)
                    {
                        for (int l = 0; l < map.transform.GetChild(o).GetComponent<OfficeManager>().workers.Count; l++)
                        {
                            if (map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l].idwork == index)
                            {
                                Worker tempWorker = map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l];
                                tempWorker.idwork = -1;
                                map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l] = tempWorker;
                            }
                            else if (map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l].idwork > index)
                            {
                                Worker tempWorker = map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l];
                                tempWorker.idwork--;
                                map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l] = tempWorker;
                            }

                        }
                    }
                }
                else
                    tasksCurent[i] = tempTask;
            }
            for (int i = 1; i < map.transform.childCount; i++)
            {
                Debug.Log(map.transform.GetChild(i).GetComponent<OfficeManager>().workers.Count.ToString());
                for (int j = 0; j < map.transform.GetChild(i).GetComponent<OfficeManager>().workers.Count; j++)
                {
                    Debug.Log("id work = ");
                    if (map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].idwork != -1)
                    {
                        Debug.Log(map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].idwork.ToString());
                        Task tempTask = tasksCurent[map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].idwork];
                        tempTask.progress += ((int)(map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].stage/tempTask.difficulty)) * hours / 24;
                        if (tempTask.progress >= 100)
                        {
                            Budget += tempTask.payment;
                            tasksCurent.RemoveAt(map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].idwork);
                            int index = map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].idwork;
                            for (int o = 1; o < map.transform.childCount; o++)
                            {
                                for (int l = 0; l < map.transform.GetChild(o).GetComponent<OfficeManager>().workers.Count; l++)
                                {
                                    if (map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l].idwork == index)
                                    {
                                        Worker tempWorker = map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l];
                                        tempWorker.idwork = -1;
                                        map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l] = tempWorker;
                                    }
                                    else if (map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l].idwork > index)
                                    {
                                        Worker tempWorker = map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l];
                                        tempWorker.idwork--;
                                        map.transform.GetChild(o).GetComponent<OfficeManager>().workers[l] = tempWorker;
                                    }
                                }
                            }
                        }
                        else
                        {
                            tasksCurent[map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].idwork] = tempTask;
                        }
                    }
                }
            }
            if (payedCredit >= 500000)
            {
                maxCredit += 500000;
                payedCredit = 0;
            }
            hours %= 24;
            if (date % 360 == 359)
            {
                Debug.Log("360 day");
                credit += credit / 100 * 20;
            }
            if (date % 7 == 6)
            {
                Debug.Log("7 day");
                for (int i = 1; i < map.transform.childCount; i++)
                {
                    for (int j = 0; j < map.transform.GetChild(i).GetComponent<OfficeManager>().workers.Count; j++)
                    {
                        Budget -= map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].stage * 1000;
                    }
                }
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
}
