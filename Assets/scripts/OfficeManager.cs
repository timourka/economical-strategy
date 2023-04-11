using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static workerClass;

public class OfficeManager : MonoBehaviour
{
    public workerClass workerClassFile;
    public GameObject messedgePanel;
    public List<Worker> workers = new List<Worker>();
    public bool active;
    public int numOfWorkers;
    public GameObject workersPanel = null;
    public bool baught;
    public int price;
    // Start is called before the first frame update
    void Start()
    {
        active = false; baught = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HaveBaught()
    {
        active = false;
        transform.GetChild(0).GetComponent<Image>().color = Color.white;
        if (workerClassFile.Budget >= price)
        {
            baught = true;
            workerClassFile.Budget -= price;
        }
        else
        {
            messedgePanel.SetActive(true);
            messedgePanel.transform.GetChild(0).GetComponent<Text>().text = "Вам не хватает денег!";
        }
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void HaveNtBaught()
    {
        active = false;
        transform.GetChild(0).GetComponent<Image>().color = Color.white;
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void clicked()
    {
        if (baught)
        {
            if (!active)
            {
                numOfWorkers = workers.Count;
                active = true;
                workersPanel.SetActive(true);
                workersPanel.transform.GetComponent<workersmanager>().updateInfo();
            }
            else
            {
                active = false;
                workersPanel.SetActive(false);
                transform.GetChild(0).GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            if (!active)
            {
                active = true;
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(1).GetChild(1).GetComponent<Text>().text = price.ToString();
            }
            else
            {
                HaveNtBaught();
            }
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
