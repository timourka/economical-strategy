using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskManager : MonoBehaviour
{
    public GameObject confirmationWindow;
    public bool active = false;
    public void clicked()
    {
        active = true;
        confirmationWindow.GetComponent<confirmationWindowManager>().openClose();
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
