namespace SortingLib.Model
{
	public class RouteCard
	{
		public RouteCard(string startPoint, string finishPoint)
		{
			StartPoint = startPoint;
			FinishPoint = finishPoint;
		}

		public string StartPoint { get; set; }
		public string FinishPoint { get; set; }
	}
}
