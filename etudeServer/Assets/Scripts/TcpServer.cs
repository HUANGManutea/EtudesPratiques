using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

public class TcpServer : MonoBehaviour {
	private TcpListener tcpListener;  //We use a listener
	private Thread listenThread; //I prefere to use threads
	public GameObject spawn; //Reference point for the prefab to spawn
	public volatile bool okPrefab = false; //If the prefab is received this value is true

	void Start(){
		okPrefab = false;
		tcpListener = new TcpListener(IPAddress.Any,80); //starting the listener
		listenThread = new Thread(new ThreadStart(ListenForClients)); 
		listenThread.IsBackground = true;
		listenThread.Start();
	}

	/*The prefab will we instantiated just after being saved in a file*/
	void Update(){
		if(okPrefab){
			Appear();
			okPrefab = false;
		}
	}

	/*This method waits for clients to connect*/
	public void ListenForClients(){
		this.tcpListener.Start();
		while (true){
			//blocks until client connected
			TcpClient client = this.tcpListener.AcceptTcpClient();
			//create thread to handle com with connected client
			Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
			clientThread.IsBackground = true;
			clientThread.Start(client);
		}
	}


	/*This core method will retrieve the data from the connection
	 * using a NetworkStream for the tunnel
	 * using a MemoryStream to stock the data
	 * using a fileStream to write the data in a file
	 */
	private void HandleClientComm(object client){
		TcpClient tcpClient = (TcpClient)client;
		NetworkStream clientStream = tcpClient.GetStream();
		byte[] message = new byte[1024]; //1Ko buffer
		MemoryStream ms = new MemoryStream(); //will contain the whole object data
		int numBytesRead; //the number of bytes to write
		string localWritePath = "C:/Users/Khayron/Documents/GitHub/EtudesPratiques/etudeServer/Assets/Resources/";
		while((numBytesRead = clientStream.Read(message,0,message.Length))>0){
			//we register the file in a memoryStream progressively
			ms.Write(message,0,numBytesRead);
		}
		
		//file has been received
		byte[] msArray = ms.ToArray();
		FileStream fs = File.Create(localWritePath+"recu.prefab"); //creating the file here if don't exist, else rewriting
		fs.Write(msArray,0,msArray.Length);
		Debug.Log("file written");
		fs.Close(); //important, close the file or an error will occur
		tcpClient.Close(); //closing the client

		FileInfo fi = new FileInfo(localWritePath+"recu.prefab");
		while(IsFileLocked(fi)){
			 //Is the file currently locked? just precaution
		}
		okPrefab = true; //the prefab is ready to be instantiated
	}

	/*Just a method to check if a file is locked*/
	protected virtual bool IsFileLocked(FileInfo file)
	{
		FileStream stream = null;
		
		try
		{
			stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
		}
		catch (IOException)
		{
			//the file is unavailable because it is:
			//still being written to
			//or being processed by another thread
			//or does not exist (has already been processed)
			return true;
		}
		finally
		{
			if (stream != null)
				stream.Close();
		}
		
		//file is not locked
		return false;
	}

	/*This method will instantiate the prefab*/
	private void Appear(){
		GameObject go = Instantiate(Resources.Load("recu",typeof(GameObject)),spawn.transform.position,Quaternion.identity) as GameObject;
		Debug.Log("Object instantiated");
	}
}
