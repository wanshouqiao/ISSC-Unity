using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    // 模拟数据（已处理），共模拟5个时间步，5个区域，每个区域2/3个监测点，每个监测点5个传感器信息
    // 传感器数据类型
    public class SensorData
    {
        float temperature;
        float pressure;
        float flowRate;
        string gasType;
        float gasConcentration;

        public SensorData(float a, float b, float c, string d, float e)
        {
            this.temperature = a;
            this.pressure = b;
            this.flowRate = c;
            this.gasType = d;
            this.gasConcentration = e;
        }

        public override string ToString()
        {
            return $"温度：{this.temperature}\n" +
                   $"气压：{this.pressure}\n" +
                   $"流量：{this.flowRate}\n" +
                   $"气体类型：{this.gasType}\n" +
                   $"气体浓度：{this.gasConcentration}";
        }
    }

    // 监测点数据
    List<List<List<SensorData>>> data = new List<List<List<SensorData>>>();
    bool isHighlight = false;

    void Start()  // 生成模拟数据
    {
        int[] zCountsByY = { 2, 2, 3, 3, 2 }; // 每个区域监测点数量

        for (int x = 0; x < 5; x++)
        {
            List<List<SensorData>> xList = new List<List<SensorData>>();

            for (int y = 0; y < 5; y++)
            {
                int zCount = zCountsByY[y];
                List<SensorData> yList = new List<SensorData>();

                for (int z = 0; z < zCount; z++)
                {
                    float a = Random.Range(0f, 1f);
                    float b = Random.Range(0f, 1f);
                    float c = Random.Range(0f, 1f);
                    string d = $"x{x}_y{y}_z{z}";
                    float e = Random.Range(0f, 1f);

                    yList.Add(new SensorData(a, b, c, d, e));
                }

                xList.Add(yList);
            }

            data.Add(xList);
        }
        return;
    }

    void Process1(int timestep, int areaId, int detectPointId) {
        // 数据获取
        SensorData sensorData = this.data
        int[] data = new int[dataLength];
        for (int i =0; i < dataLength; i++)
        {
            data[i] = this.data[timestep, areaId, detectPointId, i];
        }

        string areaName = "area" + areaId.ToString();
        GameObject area = GameObject.Find(areaName);
        Transform detectPointTrans = area.transform.GetChild(detectPointId);
        if (isHighlight == false)
        {
            // 先将所有监测点取消高亮

            // 找到对应监测点的每个传感器并将其高亮
            for (int i = 0; i < 2; i++)
            {
                Transform sensorTrans = detectPointTrans.GetChild(i);
                GameObject sensor = sensorTrans.gameObject;
                ChangeWhole changeWhole = sensor.GetComponent<ChangeWhole>();
                changeWhole.SetAllRed();

                // 每个传感器被点击时显示信息框功能开启
                changeWhole.EnableListening(true);
            }
        } else
        {
            // 找到对应监测点的每个传感器并将其取消高亮
            for (int i = 0; i < 2; i++)
            {
                Transform sensorTrans = detectPointTrans.GetChild(i);
                GameObject sensor = sensorTrans.gameObject;
                ChangeWhole changeWhole = sensor.GetComponent<ChangeWhole>();
                changeWhole.ResetColors();

                // 每个传感器被点击时显示信息框功能关闭，并关闭当前信息框
                changeWhole.EnableListening(false);
            }
        }
    }

    void Process2(int areaId, int timestep)
    {

    }

    void Process3(int areaId, int timestep)
    {

    }

    void Process4(int areaId, int timestep)
    {

    }

    void Process5(int timestep)
    {

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
