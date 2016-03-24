using System;

namespace OOP_LAB1_4
{
	abstract class State
	{
		protected string strStatename;
		abstract public void ShowState();
	}

	class OpenedState : State
	{
		public OpenedState()
		{
			strStatename = "On";
		}
		override public void ShowState()
		{
			Console.WriteLine (strStatename);
		}
	}
	class ClosedState : State
	{
		public ClosedState()
		{
			strStatename = "Off";
		}
		override public void ShowState()
		{
			Console.WriteLine(strStatename);
		}
	}

	class TV
	{
		public enum TV_StateSetting
		{
			Off,
			On
		};
		OpenedState onState = new OpenedState();
		ClosedState offState = new ClosedState();
		public TV()
		{
			// Initialize to closed
			CurrentState = offState;
		}
		private State CurrentState;
		public void SetState(TV_StateSetting newState)
		{
			if (newState == TV_StateSetting.Off)
			{
				CurrentState = offState;
			}
			else
			{
				CurrentState = onState;
			}
		}
		public void ShowState()
		{
			CurrentState.ShowState();
		}
	}


	public interface IPurchase{
		void ComeToShop();
		void ChooseProduct();
		void Payment();
		void Delivery();
	}

	public class Purchasing
	{
		public void Purchase(IPurchase purchase){
			purchase.ComeToShop();
			purchase.ChooseProduct ();
			purchase.Payment ();
			purchase.Delivery ();
		}
	}

	public class RealShop : IPurchase
	{
		public void ComeToShop(){
			Console.WriteLine ("Магазин находится на ул Пушкина 23");
		}
		public void ChooseProduct() {
			Console.WriteLine ("Консультант вам поможет выбрать товар");
		}
		public void Payment(){
			Console.WriteLine("Нажмите 1 чтобы оплатить наличными");
			string a = Console.ReadLine ();
			if (a == "1")
				Console.WriteLine ("Оплата наличными");
			else
				Console.WriteLine ("Оплата карточкой");
		}
		public void Delivery(){
			Console.WriteLine("Нажмите 1 чтобы доставить курьером");
			string a = Console.ReadLine ();
			if (a == "1")
				Console.WriteLine ("Доставка курьером");
			else
				Console.WriteLine ("Самовывоз");
		}
	}
	public class OnlinelShop : IPurchase
	{
		public void ComeToShop(){
			Console.WriteLine ("onlineshop.com");
		}
		public void ChooseProduct() {
			Console.WriteLine("Нажмите 1 чтобы воспользоваться службой поддержки\nНажмите 2 чтобы воспользоваться телефоном");
			string a = Console.ReadLine ();
			if (a == "1")
				Console.WriteLine ("Служба поддержки выбора товара");
			else if (a == "2")
				Console.WriteLine ("Выбор товара по телефону");
			else
				Console.WriteLine ("Выбрать товар на сайте самостоятельно");
		}
		public void Payment(){
			Console.WriteLine("Нажмите 1 чтобы оплатить наличными");
			string a = Console.ReadLine ();
			if (a == "1")
				Console.WriteLine ("Оплата наличными");
			else
				Console.WriteLine ("Оплата карточкой");
		}
		public void Delivery(){
			Console.WriteLine("Нажмите 1 чтобы доставить курьером");
			string a = Console.ReadLine ();
			if (a == "1")
				Console.WriteLine ("Доставка курьером");
			else
				Console.WriteLine ("Самовывоз");
		}
	}

	class MainClass
	{
		public static void Task1(){
			Console.WriteLine ("Task1");
			TV testTV = new TV();
			testTV.ShowState();
			testTV.SetState (TV.TV_StateSetting.On);
			testTV.ShowState ();
			Console.ReadKey ();
			testTV.SetState (TV.TV_StateSetting.Off);
			testTV.ShowState ();
			Console.ReadKey ();			
			testTV.SetState (TV.TV_StateSetting.On);
			testTV.ShowState ();
			Console.ReadKey ();
			testTV.SetState (TV.TV_StateSetting.Off);
			testTV.ShowState ();
			Console.ReadKey ();
		}
		public static void Task2(){
			Console.WriteLine ("\nTask2\n");
			Purchasing p = new Purchasing ();
			Console.WriteLine ("Реальный магазин");
			p.Purchase (new RealShop());
			Console.WriteLine ("\nОнлайн магазин");
			p.Purchase (new OnlinelShop ());
		}
		public static void Main (string[] args)
		{
			Task1 ();
			Task2 ();
		}
	}
}
