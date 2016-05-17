using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{

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


    public class Program
    {
        public static void Main(string[] args)
        {
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
        }
    }
}
