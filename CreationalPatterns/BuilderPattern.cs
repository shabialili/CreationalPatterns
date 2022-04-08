using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    public interface ICarBuilder
    {
        ICarBuilder Reset();
        ICarBuilder setSeats(byte count);
        ICarBuilder setEngine();
        ICarBuilder setTripComputer();
        ICarBuilder setGPS();
        Car GetResult();

    }
    public class CarAutoBuilder : ICarBuilder
    {
        private CarAuto Car { get; set; } = new();  

        public ICarBuilder Reset()
        {
            Car = new CarAuto();    
            return this;
        }
        public ICarBuilder setEngine()
        {
            Car.HasEngine = true;
            return this;
        }
        public ICarBuilder setSeats(byte count)
        {
            Car.Seats = count;
            return this;
        }
        public ICarBuilder setGPS()
        {
            Car.HasGPS = true;
            return this;
        }
        public ICarBuilder setTripComputer()
        {
            Car.HasTripComputer = true;
            return this;
        }
        public Car GetResult()
        {
            var item = Car;
            Car = new CarAuto();
            return item;
        }
    }
    public class CarManualBuilder : ICarBuilder   
    {
        private CarManual Car { get; set; } = null; 
        
        public ICarBuilder Reset()
        {
            Car = new CarManual();
            return this;
        }
        public ICarBuilder setEngine()
        {
            Car.HasEngine = true;
            return this;
        }
        public ICarBuilder setSeats(int count)
        {
            Car.Seats = count;
            return this;
        }
        public ICarBuilder setGPS()
        {
            Car.HasGPS = true;
            return this;
        }
        public ICarBuilder setTripComputer()
        {
            Car.HasTripComputer = true;
            return this;
        }

    }
    public abstract class Car
    {
        public int Seats { get; set; }  
        public bool HasEngine { get; set; } 
        public bool HasTripComputer { get; set; }
        public bool HasGPS { get; set; }

        public override string ToString() => string.Format("Seats: {0}, Engine: {1}, Computer: {2} GPS: {3}", Seats, HasEngine, HasGPS, HasTripComputer);
   
    }
    public class CarAuto : Car { }
    class CarManual : Car { }

    public abstract class CarDirector
    {
        protected ICarBuilder Builder { get; set; }

        public CarDirector(ICarBuilder builder) =>Builder = builder;

        public abstract Car Make();
        public void ChangeBuilder(ICarBuilder newBuilder) => Builder = newBuilder  ?? throw new ArgumentNullException(nameof(newBuilder));  
    }
    public class ACategoryCarDirectory : CarDirector
    {
        public ACategoryCarDirectory(ICarBuilder builder):base(builder) { }

        public override Car Make() => Builder.setSeats().setEngine.setGPS.GetResult();
       
    }
    public class BCategoryCarDirectory : CarDirector
    {
        public BCategoryCarDirectory(ICarBuilder builder) : base(builder) { }

        public override Car Make() => Builder.setSeats().setEngine.setTripComputer.setGPS.GetResult();
    }
}
