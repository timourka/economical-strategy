using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static workerClass;

public class workerFHManager : MonoBehaviour
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
        active = !active;
    }
    public void OnMouseEnter()
    {
        transform.GetComponent<Image>().color = Color.green;
    }
    void OnMouseExit()
    {
        transform.GetComponent<Image>().color = Color.white;
    }
}
