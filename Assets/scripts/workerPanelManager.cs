using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static workerClass;

public class workerPanelManager : MonoBehaviour
{
    public GameObject workersPanel = null;
    public GameObject map = null;
    GameObject activeWorker = null;
    GameObject activeOffice = null;
    Worker worker;
    int index = -1;
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
        transform.GetChild(5).GetComponent<Text>().text = worker.idwork.ToString();
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
        
    }
}
