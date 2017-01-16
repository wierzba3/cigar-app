using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Cigars.Models
{
    public class Cigar
    {

        [PrimaryKey, AutoIncrement]
        public int CigarId { get; set; }

        [ForeignKey(typeof(Brand))]
        public int BrandId { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public int RingeGauge { get; set; }

        [ForeignKey(typeof(Country))]
        public int ManufactureCountryId { get; set; }

        [ForeignKey(typeof(Country))]
        public int Binder { get; set; }

        [ForeignKey(typeof(CigarColor))]
        public int ColorId { get; set; }

        [ForeignKey(typeof(Strength))]
        public int StrengthId { get; set; }

        [ForeignKey(typeof(Shape))]
        public int ShapeId { get; set; }
    }
}
