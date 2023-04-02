using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptOnlyForWorkers : MonoBehaviour
{
    public GameObject workerPanel = null;
    // Start is called before the first frame update
    public void openWorkerPanel()
    {
        workerPanel.transform.GetComponent<workerPanelManager>().open();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
