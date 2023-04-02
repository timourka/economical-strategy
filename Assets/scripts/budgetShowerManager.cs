using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class budgetShowerManager : MonoBehaviour
{
    public workerClass workerClassFile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = workerClassFile.Budget.ToString();
        if (workerClassFile.Budget > 10000000)
            transform.GetChild(0).GetComponent<Text>().color = Color.green;
        else if (workerClassFile.Budget > 100000)
            transform.GetChild(0).GetComponent<Text>().color = Color.blue;
        else if (workerClassFile.Budget > 100)
            transform.GetChild(0).GetComponent<Text>().color = Color.gray;
        else
            transform.GetChild(0).GetComponent<Text>().color = Color.red;
    }
}
