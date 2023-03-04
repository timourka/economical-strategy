using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;


public class OfficeManager : MonoBehaviour
{
    public struct Worker
    {
        public string name;
        public int idwork;
        public Sprite namimage;
    }
    public Sprite image1 = null;
    public List<Worker> workers = new List<Worker>();
    public bool active = false;
    public int numOfWorkers;
    public GameObject workersPanel = null;
    // Start is called before the first frame update
    void Start()
    {
        Worker worker = new Worker();
        worker.name = "Власенко Олег Федосович2";
        worker.idwork = 0;
        worker.namimage = image1;
        workers.Add(worker);
        numOfWorkers = workers.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clicked()
    {
        if (!active)
        {
            active = true;
            workersPanel.SetActive(true);
        }
        else
        {
            active = false;
            workersPanel.SetActive(false);
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
