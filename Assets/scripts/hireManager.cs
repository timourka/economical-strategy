using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static workerClass;

public class hireManager : MonoBehaviour
{
    public workerClass workerClassFile;
    private List<GameObject> workerFHs = new List<GameObject>();
    public GameObject messedgeBox = null;
    public GameObject map = null;
    public bool active = false;

    public void hired()
    {
        for (int i = 0; i< transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<workerFHManager>().active)
            {
                for (int j = 1; j < map.transform.childCount; j++)
                {
                    if (map.transform.GetChild(j).GetComponent<OfficeManager>().active)
                    {
                        if (map.transform.GetChild(j).GetComponent<OfficeManager>().workers.Count < 7)
                        {
                            map.transform.GetChild(j).GetComponent<OfficeManager>().workers.Add(workerClassFile.workers[i]);
                            workerClassFile.workers.RemoveAt(i);
                            transform.GetChild(i).GetComponent<workerFHManager>().active = false;
                            transform.GetComponentInParent<workersmanager>().updateInfo();
                            OnOff();
                        }
                        else
                        {
                            messedgeBox.GetComponent<messedgeManager>().open("нельзя нанимать больше сотрудников");
                        }
                        break;
                    }
                }
                break;
            }
        }
    }
    public void OnOff()
    {
        if (active) 
        {
            active = false;
            for (int i = 0; i < transform.childCount; i++)
            {
                workerFHs[i].SetActive(false);
            }
            this.gameObject.SetActive(false);
        }
        else
        {
            active = true;
            this.gameObject.SetActive(true);
            updateInfo();
        }
    }

    public void updateInfo()
    {
        //if (active)
        Debug.Log("updateInfo");
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i < workerClassFile.workers.Count)
                {
                    workerFHs[i].SetActive(true);
                    workerFHs[i].transform.GetChild(0).GetComponent<Text>().text = workerClassFile.workers[i].name;
                    workerFHs[i].transform.GetChild(2).GetComponent<Text>().text = workerClassFile.workers[i].stage.ToString();
                    workerFHs[i].transform.GetChild(4).GetComponent<Text>().text = (workerClassFile.workers[i].stage * 1000).ToString();
                    workerFHs[i].transform.GetChild(5).GetComponent<Image>().sprite = workerClassFile.workers[i].namimage;
                }
                else
                {
                    workerFHs[i].SetActive(false);
                }
            }
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            workerFHs.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
