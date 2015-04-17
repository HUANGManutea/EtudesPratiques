using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

public class TcpServer : MonoBehaviour {
	private TcpListener tcpListener;
	public static Thread listenThread;
	public GameObject spawn;
	public volatile bool okPrefab = false;

	void Start(){
		okPrefab = false;
		tcpListener = new TcpListener(IPAddress.Any,3000);
		listenThread = new Thread(new ThreadStart(ListenForClients));
		listenThread.Start();
		Debug.Log("Starting listener");
	}

	void Update(){
		if(okPrefab){
			appear();
			okPrefab = false;
		}
	}
	public void ListenForClients(){
		this.tcpListener.Start();
		Debug.Log("Waiting for client");
		while (true){
			//blocks until client connected
			TcpClient client = this.tcpListener.AcceptTcpClient();
			Debug.Log ("Client connected");
			//create thread to handle com
			//with connected cli
			Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
			clientThread.Start(client);

		}
	}

	private void HandleClientComm(object client){
		TcpClient tcpClient = (TcpClient)client;
		NetworkStream clientStream = tcpClient.GetStream();
		byte[] message = new byte[1024];
		MemoryStream ms = new MemoryStream();
		int numBytesRead;
		string localWritePath = "C:/Users/Khayron/Documents/GitHub/EtudesPratiques/etudeServer/Assets/Resources/";
		while((numBytesRead = clientStream.Read(message,0,message.Length))>0){
			//blocks until a client sends a message
			ms.Write(message,0,numBytesRead);
		}
		
		//message has successfully been received
		Debug.Log ("Stream success");
		byte[] msArray = ms.ToArray();
		FileStream fs = File.Create(localWritePath+"recu.prefab");
		fs.Write(msArray,0,msArray.Length);
		Debug.Log("file written");
		fs.Close();
		tcpClient.Close();
		FileInfo fi = new FileInfo(localWritePath+"recu.prefab");
		while(IsFileLocked(fi)){
			Debug.Log ("waiting for the file");
		}
		Debug.Log("filestream closed");
		okPrefab = true;
	}

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
	
	private void appear(){
		GameObject go = Instantiate(Resources.Load("recu",typeof(GameObject)),spawn.transform.position,Quaternion.identity) as GameObject;
		Debug.Log("Object instantiated");
	}
}
