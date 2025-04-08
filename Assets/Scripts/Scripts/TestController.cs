using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    // ģ�����ݣ��Ѵ�������ģ��5��ʱ�䲽��5������ÿ������2/3�����㣬ÿ������5����������Ϣ
    // ��������������
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
            return $"�¶ȣ�{this.temperature}\n" +
                   $"��ѹ��{this.pressure}\n" +
                   $"������{this.flowRate}\n" +
                   $"�������ͣ�{this.gasType}\n" +
                   $"����Ũ�ȣ�{this.gasConcentration}";
        }
    }

    // ��������
    List<List<List<SensorData>>> data = new List<List<List<SensorData>>>();
    bool isHighlight = false;

    void Start()  // ����ģ������
    {
        int[] zCountsByY = { 2, 2, 3, 3, 2 }; // ÿ�������������

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
        // ���ݻ�ȡ
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
            // �Ƚ����м���ȡ������

            // �ҵ���Ӧ�����ÿ�����������������
            for (int i = 0; i < 2; i++)
            {
                Transform sensorTrans = detectPointTrans.GetChild(i);
                GameObject sensor = sensorTrans.gameObject;
                ChangeWhole changeWhole = sensor.GetComponent<ChangeWhole>();
                changeWhole.SetAllRed();

                // ÿ�������������ʱ��ʾ��Ϣ���ܿ���
                changeWhole.EnableListening(true);
            }
        } else
        {
            // �ҵ���Ӧ�����ÿ��������������ȡ������
            for (int i = 0; i < 2; i++)
            {
                Transform sensorTrans = detectPointTrans.GetChild(i);
                GameObject sensor = sensorTrans.gameObject;
                ChangeWhole changeWhole = sensor.GetComponent<ChangeWhole>();
                changeWhole.ResetColors();

                // ÿ�������������ʱ��ʾ��Ϣ���ܹرգ����رյ�ǰ��Ϣ��
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
