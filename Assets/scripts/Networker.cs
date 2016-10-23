using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;

public class Networker : MonoBehaviour {

    Button StartServer;
    Button Cancel;
    Button RefreshServers;

	// Use this for initialization
	void Start () {
        StartServer = GameObject.Find("StartServer").GetComponent<Button>();
        Cancel = GameObject.Find("Cancel").GetComponent<Button>();
        RefreshServers = GameObject.Find("RefreshServers").GetComponent<Button>();
    }
	

	void Awake () {
	}

    public void addServer(string s) {
        
    }

    public void removeServer(string name) {

    }

    public void refreshServers() {

    }

    string LocalIPAddress() {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList) {
            if (ip.AddressFamily == AddressFamily.InterNetwork) {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
}
