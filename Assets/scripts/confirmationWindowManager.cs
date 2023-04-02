using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmationWindowManager : MonoBehaviour
{
    public workerClass workerClassFile = null;
    public GameObject tasksMarket;
    public bool active = false;
    int index;
    public void openClose()
    {
        if (active)
        {
            active = false;
            gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0;i < tasksMarket.transform.GetChild(0).childCount;i++)
            {
                if (tasksMarket.transform.GetChild(0).GetChild(i).GetComponent<taskManager>().active)
                {
                    tasksMarket.transform.GetChild(0).GetChild(i).GetComponent<taskManager>().active = false;
                    index = i;
                    break;
                }
            }
            active = true;
            gameObject.SetActive(true);
        }
    }
    public void ok()
    {
        workerClassFile.tasksCurent.Add(workerClassFile.tasks[index]);
        workerClassFile.tasks.RemoveAt(index);
        tasksMarket.SetActive(false);
        openClose();
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
