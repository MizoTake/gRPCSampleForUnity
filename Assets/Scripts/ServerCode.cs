using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using GreeterServer;
using Grpc.Core;
using Helloworld;
using UnityEngine;

namespace GrpcSampleForUnity
{
	public class ServerCode : MonoBehaviour
	{
		const int Port = 50051;

		void Start ()
		{
			Server server = new Server
			{
				Services = { Greeter.BindService (new GreeterImpl ()) },
					Ports = { new ServerPort ("localhost", Port, ServerCredentials.Insecure) }
			};
			server.Start ();

			Debug.Log ("Greeter server listening on port " + Port);
			Debug.Log ("Press any key to stop the server...");
			Console.ReadKey ();

			server.ShutdownAsync ().Wait ();
		}
	}
}