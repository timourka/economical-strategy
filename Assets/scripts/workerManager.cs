using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class workerManager : MonoBehaviour
{
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clicked()
    {
        active = true;
        transform.GetComponentInParent<scriptOnlyForWorkers>().openWorkerPanel();
    }
    public void MouseEnter()
    {
        transform.GetComponent<Image>().color = Color.grey;
    }
    public void MouseExit()
    {
        transform.GetComponent<Image>().color = Color.white;
    }
}
