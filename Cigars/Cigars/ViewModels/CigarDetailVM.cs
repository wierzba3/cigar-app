using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigars.ViewModels
{
    public class CigarDetailVM : INotifyPropertyChanged
    {
        public CigarDetailVM() { }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _cigarName;

        public string CigarName
        {
            get { return _cigarName; }
            set
            {
                _cigarName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CigarName"));
            }
        }

        private string _cigarBrand;

        public string CigarBrand
        {
            get { return _cigarBrand; }
            set
            {
                _cigarBrand = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CigarBrand"));
            }
        }


        private string _manufacturedIn;

        public string ManufacturedIn
        {
            get { return _manufacturedIn; }
            set
            {
                _manufacturedIn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ManufacturedIn"));
            }
        }

        private string _strength;
        public string Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Strength"));
            }
        }

        private string _length;
        public string Length
        {
            get { return _length; }
            set
            {
                _length = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Length"));
            }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                PropertyChanged(this,  new PropertyChangedEventArgs("Color"));
            }
        }

        private string _shape;
        public string Shape
        {
            get { return _shape; }
            set
            {
                _shape = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Shape"));
            }
        }

        private string _ringGauge;
        public string RingGauge
        {
            get { return _ringGauge; }
            set
            {
                _ringGauge = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RingGauge"));
            }
        }

    }
}
