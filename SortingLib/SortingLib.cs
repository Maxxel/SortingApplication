using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SortingLib.Model;

namespace SortingLib
{
	public static class SortingLib
	{
		public static bool IsTestMode = false;
		public static List<RouteCard> CardsList => routeList.ToList();
		public static void Shuffle()
		{
			var result = new List<RouteCard>();
			var random = new Random();
			foreach (var s in routeList)
			{
				var j = random.Next(result.Count + 1);
				if (j == result.Count)
				{
					result.Add(s);
				}
				else
				{
					result.Add(result[j]);
					result[j] = s;
				}
			}
			routeList = new HashSet<RouteCard>(result);
		}
		public static void Sort()
		{
			var curentCard = GetFirstPointCard();
			var result = new HashSet<RouteCard>();

			while (curentCard != null)
			{
				result.Add(curentCard);
				curentCard = Next(curentCard);
			}

			routeList = result;
		}

		public static void AddNew(string startPoint, string finishPoint)
		{
			routeList.Add(new RouteCard(startPoint, finishPoint));
		}

		static SortingLib()
		{
			routeList = FillCardDeck();
		}

		private static HashSet<RouteCard> routeList { get; set; }

		private static readonly Func<RouteCard, RouteCard> Next = (x) =>
		{
			if(IsTestMode)
				Thread.Sleep(1000);
			var result =
				routeList.FirstOrDefault(i =>
					string.Equals(i.StartPoint, x.FinishPoint));
			
			return result;
		};

		private static RouteCard GetFirstPointCard()
		{

			var startPointList = routeList.Select(i => i.StartPoint);
			var finishPointList = routeList.Select(i => i.FinishPoint);

			var startPoint = startPointList.Except(finishPointList).FirstOrDefault();
			return routeList.FirstOrDefault(i => i.StartPoint == startPoint);
		}		
		
		private static HashSet<RouteCard> FillCardDeck()
		{
			return new HashSet<RouteCard>
			{
				new RouteCard("Moscow", "Voronezh"),
				new RouteCard("Voronezh", "Volgograd"),
				new RouteCard("Volgograd", "Krasnodar"),
				new RouteCard("Krasnodar", "Astrakhan"),
				new RouteCard("Astrakhan", "Uralsk"),
				new RouteCard("Uralsk", "Orenburg"),
				new RouteCard("Orenburg", "Ufa"),
				new RouteCard("Ufa", "Chelyabinsk"),
				new RouteCard("Chelyabinsk", "Ekaterinburg"),
				new RouteCard("Ekaterinburg", "Tyumen"),
				new RouteCard("Tyumen", "Omsk"),
				new RouteCard("Omsk", "Novosibirsk"),
				new RouteCard("Novosibirsk", "Kemerovo"),
				new RouteCard("Kemerovo", "Tomsk"),
				new RouteCard("Tomsk", "Krasnoyarsk"),
			};
		}
	}
}
