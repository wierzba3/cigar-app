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
        }

        public MainVM Main
        {
            get
            {
                MainVM result = ServiceLocator.Current.GetInstance<MainVM>();
                return result;
            }
        }

        public SmokeHistoryVM SmokeHistory
        {
            get
            {
                SmokeHistoryVM result = ServiceLocator.Current.GetInstance<SmokeHistoryVM>();
                return result;
            }
        }

        public AddSmokeVM AddSmoke
        {
            get
            {
                AddSmokeVM result = ServiceLocator.Current.GetInstance<AddSmokeVM>();
                return result;
            }
        }

        public ChooseCigarVM ChooseCigar
        {
            get
            {
                ChooseCigarVM result = ServiceLocator.Current.GetInstance<ChooseCigarVM>();
                return result;
            }
        }

        public HumidorVM Humidor => ServiceLocator.Current.GetInstance<HumidorVM>();
    }
}
