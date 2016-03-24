using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace OOP_LAB1_1
{
	interface IStudent{
		bool passTest ();
	}

	class AbstractStudent
	{
		IStudent pass;
		public AbstractStudent(IStudent pass) {
			this.pass = pass;
		}

		public bool passTest() {
			return this.pass.passTest ();
		}
	}	

	class AStudent : IStudent
	{
		public bool passTest(){
			return true;	
		}
	}
	class BCStudent : IStudent
	{
		Random mark = new Random(DateTime.Now.Millisecond);
		public bool passTest(){
			
			if ((mark.Next () % 100) <= 80)
				return true;
			return false;
		}
	}
	class DEStudent : IStudent
	{
		Random mark = new Random(DateTime.Now.Millisecond);
		public bool passTest(){
			if ((mark.Next () % 100) <= 60)
				return true;
			return false;
		}
	}
	class FStudent : IStudent
	{
		Random mark = new Random(DateTime.Now.Millisecond);

		public bool passTest(){
			if ((mark.Next () % 100) <= 40)
				return true;
			return false;		
		}
	}

	//Part 2
	abstract class AObject
	{
		protected String name;
		public AObject(string name) {
			this.name = name;
		}

		public abstract void Add(AObject obj);
		public abstract void ShowPets();
		public abstract int MiddleAge();

	}
		

	class House : AObject
	{
		private List<AObject> entrances = new List<AObject>();

		public House(string name) : base(name) {

		}

		public override void ShowPets() {
			foreach (Entrance ent in entrances) {
				ent.ShowPets();
				Console.Write("Middle age of pets on House {0} : ", this.name);
				Console.WriteLine(MiddleAge ());
			}
		}

		public override int MiddleAge() {
			int sum = 0;
			foreach (Entrance ent in entrances) {
				sum += ent.midAge();
			}
			return sum / entrances.Count;
		}

		public override void Add(AObject obj) {
			entrances.Add(obj);
		}
	}

	class Entrance : AObject
	{
		private List<AObject> flats = new List<AObject>();

		public Entrance(string name)	: base(name) {

		}

		public override void ShowPets() {
			foreach (Flat flat in flats) {
				flat.ShowPets ();
				Console.Write("Middle age of pets on Entrance {0} : ", this.name);
				Console.WriteLine(MiddleAge ());
			}
		}

		public override int MiddleAge() {
			int sum = 0;
			foreach (Flat flat in flats) {
				sum += flat.midAge ();
			}
			return sum/flats.Count;
		}
		public int midAge(){
			return MiddleAge ();
		}

		public override void Add(AObject obj) {

			flats.Add(obj);
		}
	}

	class Flat : AObject
	{
		
		private List<Pet> pets = new List<Pet>();

		public Flat(string name) : base(name) {

		}

		public override void ShowPets() {
			Console.WriteLine ("On flat {0} :", this.name);
			foreach (Pet pet in pets) {
				Console.WriteLine("Pet Name {0} Age {1}", pet.Name(), pet.Age ());
			}
			Console.Write("Middle age of pets on Flat  {0} : ", this.name);
			Console.WriteLine(MiddleAge ());
		}

		public override int MiddleAge() {
			int sum = 0;
			foreach (Pet age in pets) {
				sum += age.Age();
			}
			return sum/pets.Count;
		}
		public int midAge(){
			return MiddleAge ();
		}

		public override void Add(AObject obj) {
			Console.WriteLine("Impossible");
		}

		public void AddPet(Pet obj) {
			pets.Add(obj);
		}
	}
    class Pet
	{
		private List<Pet> pats = new List<Pet>();
		protected int age;
		protected String name;

		public Pet(string name, int age){
			this.name = name;
			this.age = age;
		}

		public virtual void Add(Pet obj){
			pats.Add (obj);
		}


		public int Age(){
			return this.age;
		}

		public string Name(){
			return this.name;
		}

	}

	class Cat : Pet
	{
		public Cat(string name, int age) : base(name , age){

		}

		public override void Add(Pet obj){
			Console.WriteLine ("Can't");
		}

	}	

	class Dog : Pet
	{
		public Dog(string name, int age) : base(name , age){

		}

		public override void Add(Pet obj){
			Console.WriteLine ("Can't");
		}

	}	

	class MainClass
	{
		public static void Task1(){
			Console.WriteLine ("Task1 Started");
			List<AbstractStudent> students = new List<AbstractStudent> {
				new AbstractStudent(new AStudent()),
				new AbstractStudent(new BCStudent()),
				new AbstractStudent(new DEStudent()),
				new AbstractStudent(new FStudent())
			};
			foreach (AbstractStudent i in students)
				if (i.passTest ())
					Console.WriteLine ("Student confirmed the assessment of his mark");
				else
					Console.WriteLine ("Student didn't confirm the assessment of his mark");
				
		}
		public static void Task2(){
			
			House h1 = new House ("1ST House");
			Entrance e1 = new Entrance("1ST Entrance");
			Flat s1 = new Flat("1ST Flat");
			Flat s2 = new Flat("2ND Flat");
			Cat cat1 = new Cat ("Cat1", 6);
			Cat cat2 = new Cat ("Cat2", 4);
			Dog dog1 = new Dog ("Dog1", 10);
			Dog dog2 = new Dog ("Dog2", 8);

			s1.AddPet(cat1);
			s1.AddPet(cat2);
			s2.AddPet(dog1);
			s2.AddPet(dog2);

			e1.Add(s1);
			e1.Add(s2);
			h1.Add(e1);
			Console.WriteLine ("\n\nTask2 Started");
			Console.WriteLine ("Flats");
			s1.ShowPets ();
			s2.ShowPets ();
			Console.WriteLine ("\n\nEntrances");
			e1.ShowPets ();
			Console.WriteLine ("\n\nHouses");
			h1.ShowPets ();
		}
		public static void Main (string[] args)
		{
			Task1 ();
			Task2 ();
		}
		
	}
}
