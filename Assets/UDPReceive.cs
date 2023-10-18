
// [url]http://msdn.microsoft.com/de-de/library/bb979228.aspx#ID0E3BAC[/url]

using UnityEngine;
using System.Collections;
 
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
 
public class UDPReceive : MonoBehaviour {
   
    // receiving Thread
    Thread receiveThread;
 
    // udpclient object
    UdpClient client;
 
    // public
    // public string IP = "127.0.0.1"; default local
    public int port; // define > init
 
    // infos
    public string lastReceivedUDPPacket;
    public string allReceivedUDPPackets; // clean up this from time to time!
   
   
    // start from shell
    private static void Main()
    {
       UDPReceive receiveObj = new UDPReceive();
       receiveObj.init();
 
        
    }
    // start from unity3d
    public void Start()
    {
       init();
    }
   
    // init
    private void init()
    {
       
        // define port
        port = 10000;
 
        
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
 
    }
 
    // receive thread
    public void ReceiveData()
    {
 
        client = new UdpClient(port);
        while (true)
        {
             try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
 
                string text = Encoding.UTF8.GetString(data);
 
                // print(">> " + text);
               
                lastReceivedUDPPacket=text;
               
                // allReceivedUDPPackets=allReceivedUDPPackets+text;
               
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }
}