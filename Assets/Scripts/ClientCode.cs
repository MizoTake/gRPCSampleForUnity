using System;
using System.Collections;
using System.Collections.Generic;
using Grpc.Core;
using Helloworld;
using UnityEngine;

namespace GrpcSampleForUnity
{
	public class ClientCode : MonoBehaviour
	{

		// Use this for initialization
		void Start ()
		{
			Channel channel = new Channel ("127.0.0.1:50051", ChannelCredentials.Insecure);

			var client = new Greeter.GreeterClient (channel);
			String user = "you";

			var reply = client.SayHello (new HelloRequest { Name = user });
			Debug.Log ("Greeting: " + reply.Message);

			// channel.ShutdownAsync ().Wait ();
			// Debug.Log ("Press any key to exit...");
			// Console.ReadKey ();
		}
	}
}