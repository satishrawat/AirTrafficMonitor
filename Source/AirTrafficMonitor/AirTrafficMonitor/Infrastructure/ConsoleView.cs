using AirTrafficMonitor.Domain;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Threading;
using AirTrafficMonitor.Utilities;

namespace AirTrafficMonitor.Infrastructure
{
    public class ConsoleView : IView
    {
        public void DelayTimer()
        {
            Task.Delay(5000);
        }

        public void Render(FlightTrack track)
        {
            Console.WriteLine(track.ToString());
        }

        public void RenderCollision(Tuple<FlightTrack, FlightTrack> flightsInCollision)
        {
            string flight1 = flightsInCollision.Item1.Tag;
            string flight2 = flightsInCollision.Item2.Tag;
            DateTime timeFlight = flightsInCollision.Item2.LatestTime;
            
            Console.WriteLine("Warning, two planes are currently on collision course! \n Plane Tag: {0}, Plane Tag: {1} and Time: {2}\n", flight1, flight2, timeFlight);
        }

        public void RenderWithGreenTillTimerEnds(string renderstr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(renderstr);

            var timer = new EventTimer(5000);

            Console.ResetColor();

        }

        public void RenderWithRedTillTimerEnds(string renderstr)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(renderstr);
            var timer = new EventTimer(5000);
            //var startTime = System.DateTime.Now;
            //while (startTime < startTime.Add(new TimeSpan(0,0,5)))
            //{

            //}
           // await Task.Delay(5000);
            //timer.WaitTimer();

            //Console.ResetColor();

            //timer.Interval = 5;
            //timer.Start();  

            //Console.ResetColor();
        }
    }
}
