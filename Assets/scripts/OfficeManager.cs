using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using static workerClass;

public class OfficeManager : MonoBehaviour
{
    public workerClass workerClassFile;
    public List<Worker> workers = new List<Worker>();
    public bool active = false;
    public int numOfWorkers;
    public GameObject workersPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clicked()
    {
        if (!active)
        {
            foreach (Worker iterator in workerClassFile.workers)
                workers.Add(iterator);
            numOfWorkers = workers.Count;
            active = true;
            workersPanel.SetActive(true);
        }
        else
        {
            active = false;
            workersPanel.SetActive(false);
            transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
    }
    public void OnMouseEnter()
    {
        transform.GetChild(0).GetComponent<Image>().color = Color.green;
    }
    void OnMouseExit()
    {
        if (!active)
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
    }
}
