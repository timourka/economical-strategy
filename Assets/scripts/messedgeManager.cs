using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class messedgeManager : MonoBehaviour
{
    public void open(string text)
    {
        this.gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<Text>().text = text;
    }
    public void close()
    {
        this.gameObject.SetActive(false);
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
