﻿using System.Collections.Generic;
using AirTrafficMonitor.Observer;

namespace AirTrafficMonitor.View
{
    public class FlightObserver : IObserver<FlightRecord> //might be deleted later
    {
        private readonly List<FlightTrack> _tracks;
        private readonly IView _view;
        private readonly ISeperationHandler _handler;

        public FlightObserver(IView view, ISeperationHandler handler)
        {
            _view = view;
            _handler = handler;
            _tracks = new List<FlightTrack>();
        }

        public void Update(FlightRecord update)
        {
            foreach (var track in _tracks)
            {
                if (track.Tag == update.Tag)
                {
                   track._records.Add(update);
                }
            }
            _handler.DetectCollision(_tracks);
            _view.Render(update); //only update updated tracks
        }
    }

    public class FlightTrack
    {
        public string Tag;
        public readonly List<FlightRecord> _records= new List<FlightRecord>();

    }
}