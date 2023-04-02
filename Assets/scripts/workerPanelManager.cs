using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static workerClass;

public class workerPanelManager : MonoBehaviour
{
    public workerClass workerClassFile = null;
    public GameObject workersPanel = null;
    public GameObject map = null;
    public GameObject tasks = null;
    GameObject activeWorker = null;
    GameObject activeOffice = null;
    Worker worker;
    int index = -1;
    bool takeT = false;
    public void ofTakeTask()
    {
        takeT = false;
    }

    public void takeTask()
    {
        tasks.GetComponent<tasksManager>().openClose();
        takeT = !takeT;
    }
    public void fire()
    {
        activeWorker.GetComponent<workerManager>().active = false;
        activeOffice.GetComponent<OfficeManager>().workers.RemoveAt(index);
        workersPanel.transform.GetComponent<workersmanager>().updateInfo();
        close();
    }

    public void open()
    {
        this.gameObject.SetActive(true);
        for (int i = 0; i < workersPanel.transform.GetChild(2).childCount; i++)
        {
            if (workersPanel.transform.GetChild(2).GetChild(i).GetComponent<workerManager>().active)
            {
                activeWorker = workersPanel.transform.GetChild(2).GetChild(i).gameObject;
                index = i;
                for (int j = 1; j < map.transform.childCount; j++)
                {
                    if (map.transform.GetChild(j).GetComponent<OfficeManager>().active)
                    {
                        activeOffice = map.transform.GetChild(j).gameObject;
                        worker = activeOffice.transform.GetComponent<OfficeManager>().workers[index];
                    }
                }
            }
        }
        transform.GetChild(1).GetComponent<Text>().text = worker.name;
        transform.GetChild(3).GetComponent<Text>().text = worker.stage.ToString();
        if (worker.idwork == -1)
            transform.GetChild(5).GetComponent<Text>().text = "без работы";
        else
            transform.GetChild(5).GetComponent<Text>().text = workerClassFile.tasksCurent[worker.idwork].name;
    }
    public void close()
    {
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (takeT)
        {
            for (int i = 0; i < tasks.transform.GetChild(2).GetChild(0).childCount; i++)
            {
                if (tasks.transform.GetChild(2).GetChild(0).GetChild(i).GetComponent<taskManagerOnly4tasks>().active)
                {
                    worker.idwork = i;
                    workerClassFile.workers[index] = worker;
                    transform.GetChild(5).GetComponent<Text>().text = workerClassFile.tasksCurent[worker.idwork].name;
                }
            }
        }
    }
}
