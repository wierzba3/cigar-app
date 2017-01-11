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

    }
}
