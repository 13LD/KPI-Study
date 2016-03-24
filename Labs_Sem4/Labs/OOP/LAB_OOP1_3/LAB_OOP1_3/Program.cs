using System;

namespace LAB_OOP1_3
{
	public class Report
	{
		public string ReportType;
		public string Lime;
		public string Sugar;
		public string NameOfProduct;
	}
	// Report Builder - Builder is responsible for defining
	// the construction process for individual parts. Builder
	// has those individual processes to initialize and
	// configure the report.
	public abstract class ReportBuilder
	{
		public Report report;
		public void CreateReport()
		{
			report = new Report();
		}
		public abstract void SetReportType();
		public abstract void SetLime();
		public abstract void SetSugar();
		public abstract void SetName();
		public Report DispatchReport()
		{
			return report;
		}
	}
	// PDF Report class
	public class TeaBuilder : ReportBuilder
	{
		public override void SetReportType()
		{
			report.ReportType = "Tea";
		}
		public override void SetLime()
		{
			Console.WriteLine("Press 1 to make tea with lime or 'Enter' to go next");
			string a = Console.ReadLine ();
			if (a == "1") 
				report.Lime = "with lime";
			else
				report.Lime = "without lime";
		}
		public override void SetSugar()
		{
			Console.WriteLine("Press 1 to make tea with sugar");
			string a = Console.ReadLine ();
			if (a == "1") 
				report.Sugar = "with sugar";
			else 
				report.Sugar = "without sugar";
		}
		public override void SetName()
		{
			report.NameOfProduct = "Tea";
		}
	}

	public class CoffeeBuilder : ReportBuilder
	{
		public override void SetReportType()
		{
			report.ReportType = "Coffee";
		}
		public override void SetLime()
		{
			Console.WriteLine("Press 1 to make Coffee with lime or 'Enter' to go next");
			string a = Console.ReadLine ();
			if (a == "1") 
				report.Lime = "with lime";
			else
				report.Lime = "without lime";
		}
		public override void SetSugar()
		{
			Console.WriteLine("Press 1 to make coffee with sugar");
			string a = Console.ReadLine ();
			if (a == "1") 
				report.Sugar = "with sugar";
			else 
				report.Sugar = "without sugar";
		}
		public override void SetName()
		{
			report.NameOfProduct = "Coffee";
		}
	}
	public class CocoaBuilder : ReportBuilder
	{
		public override void SetReportType()
		{
			report.ReportType = "Cocoa";
		}
		public override void SetLime()
		{
			Console.WriteLine("Press 1 to make cocoa with lime or 'Enter' to go next");
			string a = Console.ReadLine ();
			if (a == "1") 
				report.Lime = "with lime";
			else
				report.Lime = "without lime";
		}
		public override void SetSugar()
		{
			Console.WriteLine("Press 1 to make cocoa with sugar");
			string a = Console.ReadLine ();
			if (a == "1") 
				report.Sugar = "with sugar";
			else 
				report.Sugar = "without sugar";
		}
		public override void SetName()
		{
			report.NameOfProduct = "Cocoa";
		}
	}

	public class Machine
	{

		private static Machine _instance;
		// Constructor is 'protected'
		protected Machine()
		{
		}
		public static Machine Instance()
		{
			// Uses lazy initialization.
			// Note: this is not thread safe.
			if (_instance == null)
			{
				_instance = new Machine();
			}
			return _instance;
		}
		public Report GenerateReport(ReportBuilder reportBuilder)
		{
			reportBuilder.CreateReport();
			reportBuilder.SetName();
			reportBuilder.SetReportType();
			reportBuilder.SetLime();
			reportBuilder.SetSugar();
			return reportBuilder.DispatchReport();
		}
	}


	public abstract class ShoesFactory
	{
		public abstract WomensShoes CreateWomensShoes();
		public abstract MenShoes CreateMenShoes();
		public abstract Sneakers CreateSneakers();
	}

	public abstract class WomensShoes
	{
		protected WomensShoes(){
			Console.Write("Women's shoes : ");
		}
	}

	public abstract class MenShoes
	{
		protected MenShoes(){
			Console.Write("Men's shoes : ");
		}
	}

	public abstract class Sneakers
	{
		protected Sneakers(){
			Console.Write("Sneakers : ");
		}
	}

	public class GeguineLeatherW : WomensShoes
	{
		public GeguineLeatherW(){
			Console.WriteLine("done with genuine leather");
		}
	}
	public class GeguineLeatherM : MenShoes
	{
		public GeguineLeatherM(){
			Console.WriteLine(" done with genuine leather");
		}
	}
	public class GeguineLeatherS : Sneakers
	{
		public GeguineLeatherS(){
			Console.WriteLine("done with genuine leather");
		}
	}
	public class LeatheretteW : WomensShoes
	{
		public LeatheretteW(){
			Console.WriteLine("done with leatherette");
		}
	}
	public class LeatheretteM : MenShoes
	{
		public LeatheretteM(){
			Console.WriteLine("done with leatherette");
		}
	}
	public class LeatheretteS : Sneakers
	{
		public LeatheretteS(){
			Console.WriteLine("done with leatherette");
		}
	}
	public class LeatherAndFurW : WomensShoes
	{
		public LeatherAndFurW(){
			Console.WriteLine("done with leather and fur");
		}
	}
	public class LeatherAndFurM : MenShoes
	{
		public LeatherAndFurM(){
			Console.WriteLine("done with leather and fur");
		}
	}
	public class LeatherAndFurS : Sneakers
	{
		public LeatherAndFurS(){
			Console.WriteLine("done with leather and fur");
		}
	}
	public class FirstShoesFactory : ShoesFactory
	{
		public override MenShoes CreateMenShoes ()
		{
			return new GeguineLeatherM();
		}
		public override WomensShoes CreateWomensShoes ()
		{
			return new GeguineLeatherW();
		}
		public override Sneakers CreateSneakers ()
		{
			return new GeguineLeatherS();
		}
	}
	public class SecondShoesFactory : ShoesFactory
	{
		public override MenShoes CreateMenShoes ()
		{
			return new LeatheretteM ();
		}
		public override WomensShoes CreateWomensShoes ()
		{
			return new LeatheretteW ();
		}
		public override Sneakers CreateSneakers ()
		{
			return new LeatheretteS ();
		}	
	}
	public class ThirdShoesFactory : ShoesFactory
	{
		public override MenShoes CreateMenShoes ()
		{
			return new LeatherAndFurM ();
		}
		public override WomensShoes CreateWomensShoes ()
		{
			return new LeatherAndFurW ();
		}
		public override Sneakers CreateSneakers ()
		{
			return new LeatherAndFurS ();
		}	
	}


	public class PrintingFactory
	{
		public PrintingFactory (ShoesFactory shoes){
			shoes.CreateMenShoes();
			shoes.CreateWomensShoes();
			shoes.CreateSneakers ();
			Console.WriteLine ();
		} 
	}

	class MainClass
	{ 
		public static void Task1(){
			Console.WriteLine ("Task1\n");
			Machine dir = Machine.Instance ();
			Console.WriteLine ("Choose something to Drink :D\n1 - Tea\n2 - Coffee\n3 - Cocoa");
			string a = Console.ReadLine ();
			if (a == "1") {
				ReportBuilder TeaBuilder = new TeaBuilder ();
				Report TeaReport = dir.GenerateReport (TeaBuilder);
				Console.WriteLine ("You buy {0} {1} {2}", TeaReport.NameOfProduct, TeaReport.Lime, TeaReport.Sugar);
			} else if (a == "2") {
				ReportBuilder CoffeeBuilder = new CoffeeBuilder ();
				Report CoffeeReport = dir.GenerateReport (CoffeeBuilder);
				Console.WriteLine ("You buy {0} {1} {2}", CoffeeReport.NameOfProduct, CoffeeReport.Lime, CoffeeReport.Sugar);
			} else if (a == "3") {
				ReportBuilder CocoaBuilder = new CocoaBuilder ();
				Report CocoaReport = dir.GenerateReport (CocoaBuilder);
				Console.WriteLine ("You buy {0} {1} {2}", CocoaReport.NameOfProduct, CocoaReport.Lime, CocoaReport.Sugar);
			}
			Console.ReadKey ();
		}
		public static void Task2(){
			Console.WriteLine ("\nTask2\n");
			FirstShoesFactory s1 = new FirstShoesFactory ();
			SecondShoesFactory s2 = new SecondShoesFactory ();
			ThirdShoesFactory s3 = new ThirdShoesFactory ();
			PrintingFactory pf1 = new PrintingFactory (s1);
			PrintingFactory pf2 = new PrintingFactory (s2);
			PrintingFactory pf3 = new PrintingFactory (s3);
		}
		public static void Main (string[] args)
		{
			Task1 ();
			Task2 ();
		}
	}


}
