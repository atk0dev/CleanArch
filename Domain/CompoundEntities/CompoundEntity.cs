using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.SimpleEntities;
using CleanArchitecture.Domain.AnotherEntities;

namespace CleanArchitecture.Domain.CompoundEntities
{
    public class CompoundEntity : IEntity
    {
        private decimal _ab;
        private decimal _a;
        private decimal _b;

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public SimpleEntity SimpleEntity { get; set; }

        public AnotherEntity AnotherEntity { get; set; }

        public decimal A
        {
            get { return _a; }
            set
            {
                _a = value;

                UpdateAB();
            }
        }

        public decimal B
        {
            get { return _b; }
            set
            {
                _b = value;
                
                UpdateAB();
            }
        }

        public decimal AB
        {
            get { return _ab; }
            private set { _ab = value; }
        }

        private void UpdateAB()
        {
            _ab = _a * _b;
        }
    }
}
