﻿using System;
using System.Collections.Generic;

namespace CCharpNetOop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var ea = new EaClass();
			var kyo = new Employee("Kyo");
			ea.Attach(kyo);
			ea.OnUpdate += kyo.Update;
			var amanda = new Employee("Amanda");
			ea.Attach(amanda);
			ea.OnUpdate += amanda.Update;
			ea.SetStatus("DM is back, ready to work!!");
		}
	}

	internal class Employee : IObserver
	{
		private readonly string _name;

		public Employee(string name)
		{
			_name = name;
		}

		public void Update(string situation)
		{
			Console.WriteLine($"{_name}!! {situation}!!");
		}
	}

	internal class EaClass : ISubject
	{
		private readonly List<IObserver> _observers = new List<IObserver>();
		private string _situation;
		public delegate void Update(string str);
		public Update OnUpdate;

		public void Attach(IObserver employee)
		{
			_observers.Add(employee);
		}

		public void Notify(string situation)
		{
			OnUpdate.Invoke(situation);
		}

		public void SetStatus(string situation)
		{
			if (_situation != situation)
			{
				_situation = situation;
				Notify(situation);
			}
		}
	}
}