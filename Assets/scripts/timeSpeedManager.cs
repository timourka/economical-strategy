using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeSpeedManager : MonoBehaviour
{
    public int first_speed = 5000;
    public int second_speed = 10000;
    public int third_speed = 50000;
    public Sprite first_speed_image = null;
    public Sprite second_speed_image = null;
    public Sprite third_speed_image = null;
    public workerClass workerClassFile;

    public void clicked()
    {
        if (workerClassFile.timeSpeed >= third_speed || workerClassFile.timeSpeed < 0)
        {
            workerClassFile.timeSpeed = first_speed;
            this.transform.GetComponent<Image>().sprite = first_speed_image;
            return;
        }

        if (workerClassFile.timeSpeed >= second_speed && workerClassFile.timeSpeed < third_speed)
        {
            workerClassFile.timeSpeed = third_speed;
            this.transform.GetComponent<Image>().sprite = third_speed_image;
            return;
        }

        if (workerClassFile.timeSpeed > 0 && workerClassFile.timeSpeed < second_speed)
        {
            workerClassFile.timeSpeed = second_speed;
            this.transform.GetComponent<Image>().sprite = second_speed_image;
            return;
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
