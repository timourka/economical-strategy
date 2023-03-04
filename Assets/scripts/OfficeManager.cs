using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class OfficeManager : MonoBehaviour
{
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        count++;
        transform.GetChild(0).GetComponent<Image>().color = Color.green;
    }

    void OnMouseExit()
    {
        transform.GetChild(0).GetComponent<Image>().color = Color.red;
    }
}
