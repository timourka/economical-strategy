using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class criditsManager : MonoBehaviour
{
    public workerClass workerClassFile;
    public long creditSumm = 0;
    public long creditPaySumm = 0;
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
        transform.GetChild(9).GetComponent<Slider>().maxValue = (long)Mathf.Min(workerClassFile.credit, workerClassFile.Budget);
    }

    public void updateSumm()
    {
        creditSumm = (int)transform.GetChild(0).GetComponent<Slider>().value;
        transform.GetChild(1).GetComponent<Text>().text = creditSumm.ToString();
    }

    public void updatePaySumm()
    {
        creditPaySumm = (int)transform.GetChild(9).GetComponent<Slider>().value;
        transform.GetChild(10).GetComponent<Text>().text = creditPaySumm.ToString();
    }
    public void payCredit()
    {
        workerClassFile.payedCredit += creditPaySumm;
        workerClassFile.Budget -= creditPaySumm;
        workerClassFile.credit -= creditPaySumm;
        if (workerClassFile.payedCredit >= 500000)
        {
            workerClassFile.maxCredit += 500000;
            workerClassFile.payedCredit = 0;
        }
        transform.GetChild(0).GetComponent<Slider>().maxValue = workerClassFile.maxCredit;
        transform.GetChild(4).GetComponent<Text>().text = workerClassFile.credit.ToString();
        transform.GetChild(6).GetComponent<Text>().text = (workerClassFile.credit / 36).ToString();
        transform.GetChild(9).GetComponent<Slider>().maxValue = (long)Mathf.Min(workerClassFile.credit, workerClassFile.Budget);
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Slider>().maxValue = workerClassFile.maxCredit;
        transform.GetChild(4).GetComponent<Text>().text = workerClassFile.credit.ToString();
        transform.GetChild(6).GetComponent<Text>().text = (workerClassFile.credit / 36).ToString();
        transform.GetChild(9).GetComponent<Slider>().maxValue = (long)Mathf.Min(workerClassFile.credit, workerClassFile.Budget);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
