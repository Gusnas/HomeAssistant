using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace AirConditioner
{
    class TempSensor
    {
        public double InitTemp {get; private set;}
        private Random rand = new Random();

        public TempSensor(double initial_temperature)
        {
            InitTemp = initial_temperature;
        }

        public void TempVar(){
            while(true){
                InitTemp = InitTemp - rand.NextDouble();
                Thread.Sleep(3000);
            }
            
        }


    }
}
