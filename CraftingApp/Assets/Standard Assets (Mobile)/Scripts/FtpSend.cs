using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Text;

public class FtpSend : MonoBehaviour {
		
	void Start (){
			// Get the object used to communicate with the server.
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.9.2.32");
			request.Method = WebRequestMethods.Ftp.UploadFile;
			
			// This example assumes the FTP site uses anonymous logon.
			request.Credentials = new NetworkCredential ("manu","=k1r0nn4g4");
			
			// Copy the contents of the file to the request stream.
			StreamReader sourceStream = new StreamReader("Assets/ActualDraw/sphere.prefab");
			byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
			sourceStream.Close();
			request.ContentLength = fileContents.Length;
			
			Stream requestStream = request.GetRequestStream();
			requestStream.Write(fileContents, 0, fileContents.Length);
			requestStream.Close();
			
			FtpWebResponse response = (FtpWebResponse)request.GetResponse();
			
			Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
			
			response.Close();
		}
}