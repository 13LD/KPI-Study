using System;
using System.Collections.Generic;

namespace OOP_LAB1_5
{
	public interface IHandler{
		HandlerBase Successor { set;}
	}

	abstract public class HandlerBase
	{
		protected HandlerBase _successor;
		public HandlerBase Successor{
			set { _successor = value; } 
		}
		abstract public string ShowUser();
		abstract public void Rights();
	}

	public class ConcreteHandler1 : HandlerBase
	{
		public override string ShowUser(){
			return String.Format("Simple user");
		} 
		public override void Rights(){
			Console.WriteLine("Simple user, nothing to show");
		} 
	}
	public class ConcreteHandler2 : HandlerBase
	{
		public override string ShowUser(){
			return String.Format("\nAdvanced user");
		} 
		public override void Rights() {
			Console.WriteLine("\nChoose method\n1.Show information \n2.Input information to list \n3.Show users");
			Console.ReadLine ();
			Console.WriteLine ("No rights to show something, advanced user");
		} 
	}

	public class ConcreteHandler3 : HandlerBase
	{
		public override string ShowUser(){
			return String.Format("\nadmin ");
		} 
		public override void Rights(){
			List<string> list_info = new List<string> ();
			List<string> list_users = new List<string> ();

			Console.WriteLine("\nChoose method\n1.Show information \n2.Input information to list \n3.Show users");
			string a = Console.ReadLine ();
			if (a == "1")
				Console.WriteLine ("You have just entered admin room");
			else if (a == "2") {
				Console.WriteLine ("\nList of info");
				list_info.Add ("System information");
				list_info.Add ("3rd is your info");
				foreach (string list in list_info)
					Console.WriteLine (list);
				Console.WriteLine ("Enter your info");
				string b = Console.ReadLine ();
				list_info.Add (b);
				Console.WriteLine ("\nList of info");
				foreach (string list in list_info)
					Console.WriteLine (list);
			} else if (a == "3") {
				list_users.Add ("user1");
				list_users.Add ("user2");
				Console.WriteLine ("List of users");
				foreach (string list in list_users)
					Console.WriteLine (list);
			}
			else
				Console.WriteLine ("Wrong input");
		}
	}


	class Pupil
	{
		public void SetExecutor(Task t, Executor e)
		{
			t._Executor = e;
		}
		public void ExecuteTaskByHimself(Task t)
		{
			t.Execute();
		}
	}
	class Task
	{
		protected Executor executor;
		public Executor _Executor
		{
			set
			{
				executor = value;
			}
		}
		public int Execute()
		{
			if (executor != null)
				return executor.DoHomeTask();
			else
				return 2;
		}
	}
	//receiver
	abstract class Executor
	{
		public abstract int DoHomeTask();
	}
	class Father : Executor
	{
		public override int DoHomeTask()
		{
			Console.WriteLine("Father has done task for 3 points");
			return 3;
		}
	}
	class Mother : Executor
	{
		public override int DoHomeTask()
		{
			Console.WriteLine("Mother has done task for 4 points");
			return 4;
		}
	}
	class Granny : Executor
	{
		public override int DoHomeTask()
		{
			Console.WriteLine("Granny has done task for 5 points");
			return 5;
		}
	}

	class MainClass
	{
		public static void Task1(){
			Console.WriteLine ("Task1\n");
			Mother mother = new Mother();
			Father father = new Father();
			Granny granny = new Granny();
			Pupil[] pupil = new Pupil[3];
			pupil[0] = new Pupil();
			pupil[1] = new Pupil();
			pupil[2] = new Pupil();
			Task[] tasks = new Task[3];
			tasks[0] = new Task();
			tasks[1] = new Task();
			tasks[2] = new Task();
			pupil[0].SetExecutor(tasks[0], mother);
			pupil[1].SetExecutor(tasks[1], father);
			pupil[2].SetExecutor(tasks[2], granny);
			for (int i=0;i<3;i++)
				pupil[i].ExecuteTaskByHimself(tasks[i]);
			Console.ReadKey();
		}
		public static void Task2(){
			Console.WriteLine ("\nTask2\n");
			HandlerBase c = new ConcreteHandler1 ();
			Console.WriteLine (c.ShowUser ());
			c.Rights ();

			HandlerBase c1 = new ConcreteHandler2 ();
			Console.WriteLine (c1.ShowUser ());
			c1.Rights ();

			HandlerBase c2 = new ConcreteHandler3 ();
			Console.WriteLine (c2.ShowUser ());
			c2.Rights ();
		} 
		public static void Main (string[] args)
		{
			Task1 ();
			Task2 ();
		}
	}
}
