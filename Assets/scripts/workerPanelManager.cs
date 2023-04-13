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
        tasks.GetComponent<tasksManager>().openClose(true);
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
        transform.GetChild(7).GetComponent<Text>().text = (worker.stage * 1000).ToString();
    }
    public void close()
    {
        activeWorker.GetComponent<workerManager>().active = false;
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
                    tasks.transform.GetChild(2).GetChild(0).GetChild(i).GetComponent<taskManagerOnly4tasks>().active = false;
                    ofTakeTask();
                    tasks.GetComponent<tasksManager>().openClose();
                    worker.idwork = i;
                    activeOffice.transform.GetComponent<OfficeManager>().workers[index] = worker;
                    transform.GetChild(5).GetComponent<Text>().text = workerClassFile.tasksCurent[worker.idwork].name;
                    workersPanel.GetComponent<workersmanager>().updateInfo();
                }
            }
        }
    }
}
