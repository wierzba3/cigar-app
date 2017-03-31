using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Cigars
{
    public class ViewModelLocator
    {

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainVM>();
            SimpleIoc.Default.Register<SmokeHistoryVM>();
            SimpleIoc.Default.Register<AddSmokeVM>();
            SimpleIoc.Default.Register<ChooseCigarVM>();
            SimpleIoc.Default.Register<HumidorVM>();
            SimpleIoc.Default.Register<AddHumidorEntryVM>();
            SimpleIoc.Default.Register<OverflowVM>();
        }

        public MainVM Main
        {
            get
            {
                MainVM result = ServiceLocator.Current.GetInstance<MainVM>();
                return result;
            }
        }

        public SmokeHistoryVM SmokeHistory => ServiceLocator.Current.GetInstance<SmokeHistoryVM>();

        public AddSmokeVM AddSmoke => ServiceLocator.Current.GetInstance<AddSmokeVM>();

        public ChooseCigarVM ChooseCigar => ServiceLocator.Current.GetInstance<ChooseCigarVM>();

        public AddHumidorEntryVM AddHumidorEntry => ServiceLocator.Current.GetInstance<AddHumidorEntryVM>();

        public HumidorVM Humidor => ServiceLocator.Current.GetInstance<HumidorVM>();

        public OverflowVM Overflow => ServiceLocator.Current.GetInstance<OverflowVM>();
    }
}
