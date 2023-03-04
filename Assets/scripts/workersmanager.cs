using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class workersmanager : MonoBehaviour
{
    public GameObject workersPanel;
    private List<GameObject> workers = new List<GameObject>();
    public GameObject map;
    public int NOW;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < workersPanel.transform.GetChild(2).childCount; i++)
            workers.Add(workersPanel.transform.GetChild(2).GetChild(i).gameObject);
        for (int i = 1; i < map.transform.childCount; i++)
        {
            if (map.transform.GetChild(i).GetComponent<OfficeManager>().active)
            {
                NOW = map.transform.GetChild(i).GetComponent<OfficeManager>().numOfWorkers;
                for (int j = 0; j < NOW && j < workers.Count; j++)
                {
                    workers[j].SetActive(true);
                    workers[j].transform.GetChild(0).GetComponent<Text>().text = map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].name;
                    workers[j].transform.GetChild(2).GetComponent<Image>().sprite = map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].namimage;
                }
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
