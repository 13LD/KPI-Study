using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OOP_LAB1_2
{
	//Task1

	class Proxy : Abstract_AP
	{
		Library library = new Library();
		public List<string> users = new List<string>();
		public override void Input(Login login){
			if (Find (login.getLogin ()))
				Console.WriteLine ("{0}, choose any book what u want!", login.getLogin());
			else {
				library.Input (login);
				Autorization ();
			}
		}
		private bool Find(string arg){
			foreach(var l in users ){
				if (arg == l)
					return true;
			}
			return false;		
		}

		public void Autorization(){
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine ("Write ur name");
			string name = Console.ReadLine ();
			Console.WriteLine ("Write ur login");
			string l = Console.ReadLine();
			Console.WriteLine ("Write ur password");
			string pass = Console.ReadLine ();
			Console.WriteLine ("{0}, auto successfully with pass {1} ", name, pass);
			users.Add (l);
		}
	}

	class Login
	{
		private string login;

		public Login(string login){
			this.login = login;
		}

		public string getLogin (){
			return this.login;
		}
			
	}

	abstract class Abstract_AP 
	{
		public abstract void Input(Login login);
	}

	class Library : Abstract_AP
	{
		public override void Input(Login login){
			Console.WriteLine ("Not find user '{0}' \nAutorization", login.getLogin ());
		}
	}


	//Task2

	class Target 
	{
		protected int val1;
		protected int val2;
		protected string _result;
		protected string result;
		public Target(int val1, int val2){
			this.val1 = val1;
			this.val2 = val2;
		}

		public virtual void ShowCalculation(){
			Console.WriteLine ("\nDecimals: {0} + {1} = {2}",
				this.val1, this.val2, (this.val1 + this.val2));
		}
	}

	class Adapter : Target
	{
		private Adaptee _calc;
		public Adapter(int v1, int v2) : base(v1, v2){
		
		}

		public override void ShowCalculation(){
			_calc = new Adaptee ();

			_result = _calc.returnCalculation (val1, val2, "hex");
			result = _calc.returnCalculation (val1, val2, "oct");
			 
			base.ShowCalculation ();
			Console.WriteLine (_result);
			Console.WriteLine (result);
		}
	}

	class Adaptee
	{
		public string returnCalculation(int val1, int val2, string num_type){
			if (num_type == "hex" && val1.ToString ("X").Length == 7 
				&& val2.ToString ("X").Length == 7) {
				string result = (val1 + val2).ToString ("X");
				return val1.ToString("X") + " + " + 
					val2.ToString("X") + " = " + result;
			} else if (num_type == "oct" && 
				Convert.ToString (val1, 8).Length == 10 && 
				Convert.ToString (val2, 8).Length == 10) {
				string res = Convert.ToString ((val1 + val2), 8);
				return Convert.ToString (val1, 8) + " + " + 
					Convert.ToString (val2, 8) + " = " + res;
			} else {
				return "Error, not that format of decimal";
			}
		}
		
	}



	class MainClass
	{
		public static void Task1(){
			string a = "";
			Console.WriteLine ("Task1");
			Proxy Ap = new Proxy ();
			Ap.users.Add ("login");
			Ap.users.Add ("admin");
			Login log1 = new Login ("login");
			Ap.Input (log1);
			while (a != "q") {
				Console.WriteLine ("Input ur Login");
				string login = Console.ReadLine ();
				Login log2 = new Login (login);
				Ap.Input (log2);
				Console.WriteLine ("\nList of users\n");
				foreach (string b in Ap.users) {
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.WriteLine (b);
				}
				Console.WriteLine("Press q to exit or 'enter' to continue");
				a = Console.ReadLine();
			}
		}
		public static void Task2(){
			Console.WriteLine ("\nTask2\n");
			Target numb = new Target (777, 88);
			numb.ShowCalculation ();

			Adapter hexValue = new Adapter (123123123, 123123121);
			hexValue.ShowCalculation ();
			Adapter octValue = new Adapter (999999999, 999999998);
			octValue.ShowCalculation ();

		}
		public static void Main (string[] args)
		{
//			Task1 ();
			Task2 ();
		}
	}
}
