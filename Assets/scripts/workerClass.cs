using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OfficeManager;

public class workerClass : MonoBehaviour
{
    public struct Worker
    {
        public string name;
        public int idwork;
        public Sprite namimage;
    }
    public List<Worker> workers = new List<Worker>();
    public Sprite image1 = null;
    public Sprite image2 = null;

    // Start is called before the first frame update
    void Start()
    {
        Worker worker = new Worker();
        worker.name = "Власенко Олег Федосович1";
        worker.idwork = 0;
        worker.namimage = image1;
        workers.Add(worker);
        worker.name = "Власенко Олег Федосович2";
        worker.idwork = 0;
        worker.namimage = image2;
        workers.Add(worker);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
