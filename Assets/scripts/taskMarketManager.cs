using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static workerClass;

public class taskMarketManager : MonoBehaviour
{
    public GameObject confirmationWindow;
    public workerClass workerClassFile = null;
    public GameObject taskObj;
    private List<GameObject> tasks = new List<GameObject>();
    public bool active = false;
    public void openClose()
    {
        if (active)
        {
            active = false;
            gameObject.SetActive(false);
        }
        else
        {
            active = true;
            gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < workerClassFile.tasks.Count; i++)
        {
            tasks.Add(Instantiate(taskObj, transform.GetChild(0)));
        }
        for (int i = 0; i < workerClassFile.tasks.Count; i++)
        {
            tasks[i].GetComponent<taskManager>().confirmationWindow = confirmationWindow;
            tasks[i].transform.GetChild(0).GetComponent<Text>().text = workerClassFile.tasks[i].name;
            tasks[i].transform.GetChild(1).GetComponent<Text>().text = workerClassFile.tasks[i].payment.ToString();
            tasks[i].transform.GetChild(2).GetComponent<Text>().text = workerClassFile.tasks[i].difficulty.ToString();
            tasks[i].transform.GetChild(3).GetComponent<Text>().text = workerClassFile.tasks[i].restTime.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = tasks.Count; i < workerClassFile.tasks.Count; i++)
        {
            tasks.Add(Instantiate(taskObj, transform.GetChild(0)));
        }
        for (int i = tasks.Count - 1; i >= workerClassFile.tasks.Count; i--)
        {
            tasks[i].SetActive(false);
        }
        for (int i = 0; i < tasks.Count && i < workerClassFile.tasks.Count; i++)
        {
            tasks[i].SetActive(true);
            tasks[i].GetComponent<taskManager>().confirmationWindow = confirmationWindow;
            tasks[i].transform.GetChild(0).GetComponent<Text>().text = workerClassFile.tasks[i].name;
            tasks[i].transform.GetChild(1).GetComponent<Text>().text = workerClassFile.tasks[i].payment.ToString();
            tasks[i].transform.GetChild(2).GetComponent<Text>().text = workerClassFile.tasks[i].difficulty.ToString();
            tasks[i].transform.GetChild(3).GetComponent<Text>().text = workerClassFile.tasks[i].restTime.ToString();
        }
    }
}
