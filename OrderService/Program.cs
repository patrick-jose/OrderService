// See https://aka.ms/new-console-template for more information
using OrderServce.CrossCutting;

Console.WriteLine("Hello, World!");

var send = new Receive();

send.ReceiveMessage();
Console.WriteLine("recebido");

Console.ReadLine();