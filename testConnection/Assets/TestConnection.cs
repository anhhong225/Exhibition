//C#
using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using System.Linq;

public class TestConnection : MonoBehaviour
{
    SerialPort sp;

    void Start()
    {
        sp = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One); //Replace "COM" with whatever port your Arduino is on.
        sp.DtrEnable = false; //Prevent the Arduino from rebooting once we connect to it. 
        sp.ReadTimeout = 1; //Shortest possible read time out.
        sp.WriteTimeout = 1; //Shortest possible write time out.
        sp.Open();
        if (sp.IsOpen)
            sp.Write("Hello World");
        else
            Debug.LogError("Serial port: " + sp.PortName + " is unavailable");
        //Removed the sp.Close line since we're now polling data.
    }

    void Update()
    {
        CheckForRecievedData();
        if (Input.GetKeyDown(KeyCode.Escape) && sp.IsOpen)
            sp.Close();
    }

    public string CheckForRecievedData()
    {
        try //Sometimes malformed serial commands come through. We can ignore these with a try/catch.
        {
            string inData = sp.ReadLine();
            int inSize = inData.Count();
            if (inSize > 0)
            {
                Debug.Log("ARDUINO->|| " + inData + " ||MSG SIZE:" + inSize.ToString());
            }
            //Got the data. Flush the in-buffer to speed reads up.
            inSize = 0;
            sp.BaseStream.Flush();
            sp.DiscardInBuffer();
            return inData;
        }
        catch { return string.Empty; }
    }
}