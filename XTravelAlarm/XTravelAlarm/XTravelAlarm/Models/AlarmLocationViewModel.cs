﻿using System;
using System.Windows.Input;
using Prism.Mvvm;
using XTravelAlarm.Features;

namespace XTravelAlarm.Models
{
    public class AlarmLocationViewModel : BindableBase
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Position Position { get; set; }

        public double Distance { get; set; }

        private bool _isRunning;

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                SetProperty(ref _isRunning, value);
                RunningStatusChanged?.Execute(value);
            }
        }

        public ICommand RunningStatusChanged { get; set; }
    }
}
