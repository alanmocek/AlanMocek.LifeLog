using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Client.Application.Services
{
    public class ActivityRecordValueViewModelsFactory
    {
        public ActivityRecordValueViewModel FactorActivityRecordValueViewModelForActivityViewModel(string activityType)
        {
            return activityType switch
            {
                "activity_quantity" => new QuantityActivityRecordValueViewModel(),
                "activity_clock" => new ClockActivityRecordValueViewModel(),
                "activity_time" => new TimeActivityRecordValueViewModel(),
                _ => throw new ArgumentException($"ValueViewModel factoring for activity of type '{activityType}' is not implemented.")
            };
        }
    }


    public abstract class ActivityRecordValueViewModel : ViewModel
    {

    }

    public class QuantityActivityRecordValueViewModel : ActivityRecordValueViewModel
    {
        private int _quantity;
        
        
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                RaisePropertyChanged(nameof(Quantity));
            }
        }


        public QuantityActivityRecordValueViewModel()
        {
            Quantity = 0;
        }
    }

    public class TimeActivityRecordValueViewModel : ActivityRecordValueViewModel
    {
        private int _hours;
        private int _seconds;
        private int _minutes;


        public int Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                RaisePropertyChanged(nameof(Hours));
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                _minutes = value;
                RaisePropertyChanged(nameof(Minutes));
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                _seconds = value;
                RaisePropertyChanged(nameof(Seconds));
            }
        }
        

        public TimeActivityRecordValueViewModel()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }
    }

    public class ClockActivityRecordValueViewModel : ActivityRecordValueViewModel
    {
        private int _hour;
        private int _minute;


        public int Hour
        {
            get => _hour;
            set
            {
                _hour = value;
                RaisePropertyChanged(nameof(Hour));
            }
        }
        public int Minute
        {
            get => _minute;
            set
            {
                _minute = value;
                RaisePropertyChanged(nameof(Minute));
            }
        }


        public ClockActivityRecordValueViewModel()
        {
            Hour = 0;
            Minute = 0;
        }
    }

}
