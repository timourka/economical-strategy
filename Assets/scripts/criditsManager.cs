using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class criditsManager : MonoBehaviour
{
    public workerClass workerClassFile;
    public long creditSumm = 0;
    public void open()
    {
        gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<Slider>().maxValue = workerClassFile.maxCredit;
        transform.GetChild(4).GetComponent<Text>().text = workerClassFile.credit.ToString();
        transform.GetChild(6).GetComponent<Text>().text = (workerClassFile.credit/36).ToString();
    }
    public void close()
    {
        gameObject.SetActive(false);
    }
    public void takeCredit()
    {
        workerClassFile.maxCredit -= creditSumm / 100 * 120;
        workerClassFile.maxCredit = (long)Mathf.Max(workerClassFile.maxCredit, 0);
        workerClassFile.Budget += creditSumm;
        workerClassFile.credit += creditSumm / 100 * 120;
        transform.GetChild(0).GetComponent<Slider>().maxValue = workerClassFile.maxCredit;
        transform.GetChild(4).GetComponent<Text>().text = workerClassFile.credit.ToString();
        transform.GetChild(6).GetComponent<Text>().text = (workerClassFile.credit / 36).ToString();
    }

    public void updateSumm()
    {
        creditSumm = (int)transform.GetChild(0).GetComponent<Slider>().value;
        transform.GetChild(1).GetComponent<Text>().text = creditSumm.ToString();
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
