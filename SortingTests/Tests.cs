using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTests
{
	[TestClass]
	public class Tests
	{
		[TestMethod, Timeout(100)]
		public void ShuffleDeckTest()
		{
			var beforeShuffle = SortingLib.SortingLib.CardsList;
			SortingLib.SortingLib.Shuffle();
			var afterShuffle = SortingLib.SortingLib.CardsList;

			var isShuffled = false;
			for (var i = 0; i < beforeShuffle.Count; i++)
			{
				if (beforeShuffle[i].StartPoint == afterShuffle[i].StartPoint) continue;
				isShuffled = true;
				return;
			}
			Assert.IsTrue(isShuffled, "The deck is not mixed");
		}

		[TestMethod, Timeout(100)]
		public void SortDeckTest()
		{
			SortingLib.SortingLib.Shuffle();

			SortingLib.SortingLib.Sort();

			var sortedList = SortingLib.SortingLib.CardsList;

			for (var i = 0; i < sortedList.Count; i++)
			{
				if ((i + 1) < sortedList.Count)
				{
					Assert.IsTrue(sortedList[i].FinishPoint == sortedList[i + 1].StartPoint, "Error in sorting the deck");
				}
			}
		}

		[TestMethod, Timeout(120000)]
		public void LinearAlgorithmTest()
		{
			SortingLib.SortingLib.IsTestMode = true;
			const string errorStr = "Error.The algorithm is not linear";

			var time1 = GetAlgorithmRuntimeSec();
			SortingLib.SortingLib.AddNew("Krasnoyarsk", "Abakan");
			var time2 = GetAlgorithmRuntimeSec();

			Assert.IsTrue((time2 - time1) == 1, errorStr);

			SortingLib.SortingLib.AddNew("Abakan", "Irkutsk");
			var time3 = GetAlgorithmRuntimeSec();

			Assert.IsTrue((time3 - time2) == 1, errorStr);
		}

		private int GetAlgorithmRuntimeSec()
		{
			SortingLib.SortingLib.Shuffle();

			var watch = Stopwatch.StartNew();
			SortingLib.SortingLib.Sort();
			watch.Stop();

			return watch.Elapsed.Seconds;
		}
	}
}
