using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dateManager : MonoBehaviour
{
    public workerClass workerClassFile = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.GetChild(0).GetComponent<Text>().text = "Δενό: " + workerClassFile.date.ToString() + " δ., Βπεμÿ: " + workerClassFile.hours.ToString() + " χ.";
    }
}
