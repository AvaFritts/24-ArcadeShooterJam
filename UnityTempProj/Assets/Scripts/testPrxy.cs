using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class testPrxy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Process p = new Process();
        p.StartInfo.UseShellExecute = true;
        p.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
        p.EnableRaisingEvents = true;
        p.Exited += new EventHandler(handler);
        p.Start();
    }


    public void handler(object sender, System.EventArgs e){
        UnityEngine.Debug.Log("exited proccess");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
