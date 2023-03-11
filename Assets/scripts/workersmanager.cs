using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class workersmanager : MonoBehaviour
{
    private List<GameObject> workers = new List<GameObject>();
    public GameObject map;
    public int NOW;

    public void close()
    {
        for (int i = 1; i < map.transform.childCount; i++)
        {
            if (map.transform.GetChild(i).GetComponent<OfficeManager>().active)
            {
                map.transform.GetChild(i).GetComponent<OfficeManager>().clicked();
            }
        }
    }

    public void updateInfo()
    {
        for (int i = 1; i < map.transform.childCount; i++)
        {
            if (map.transform.GetChild(i).GetComponent<OfficeManager>().active)
            {
                NOW = map.transform.GetChild(i).GetComponent<OfficeManager>().workers.Count;
                for (int j = 0; j < workers.Count; j++)
                {
                    if (j < NOW)
                    {
                        workers[j].SetActive(true);
                        workers[j].transform.GetChild(0).GetComponent<Text>().text = map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].name;
                        workers[j].transform.GetChild(2).GetComponent<Image>().sprite = map.transform.GetChild(i).GetComponent<OfficeManager>().workers[j].namimage;
                    }
                    else
                    {
                        workers[j].SetActive(false);
                    }
                }
                break;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.GetChild(2).childCount; i++)
            workers.Add(transform.GetChild(2).GetChild(i).gameObject);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
