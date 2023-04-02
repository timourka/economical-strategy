using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour
{
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
            active=true;
            gameObject.SetActive(true);
        }
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
