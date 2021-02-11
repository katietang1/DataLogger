using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataLoggerScript : MonoBehaviour
{
    //File that will be written to
    private string filepath = "datalog.txt";

    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
        OpenMessage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpaceBar();
        }

    }

    // Creating file
    public void CreateFile()
    {
        if (!File.Exists(filepath))
        {
            File.Create(filepath).Close();
        }
    }

    // Reading content
    private void ReadFile()
    {
        using (StreamReader read = new StreamReader(filepath))
        {
            while (!read.EndOfStream)
            {
                Debug.Log(read.ReadLine());
            }
        }
    }

    // Writing content
    private void WriteFile(string content)
    {
        using (StreamWriter write = new StreamWriter(filepath, true))
        {
            write.WriteLine(content);
            Debug.Log(content);
        }
    }


    // Function for starting message
    public void OpenMessage()
    {
        DateTime datetime = DateTime.Now;
        WriteFile(datetime + " Opening Application");
    }
    //Function for button click
    public void ButtonClick()
    {
        DateTime datetime = DateTime.Now;
        WriteFile(datetime + " Button click");
    }

    // Function for space bar pressed
    public void SpaceBar()
    {
        DateTime datetime = DateTime.Now;
        WriteFile(datetime + " Space down");
    }

    // Function for closing message
    void OnApplicationQuit()
    {
        DateTime datetime = DateTime.Now;
        WriteFile(datetime + " Closing Application");
    }
}
