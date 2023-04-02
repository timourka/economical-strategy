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
    public void OnMouseEnter()
    {
        transform.GetComponent<Image>().color = Color.black;
    }
    void OnMouseExit()
    {
        transform.GetComponent<Image>().color = Color.white;
    }
}
