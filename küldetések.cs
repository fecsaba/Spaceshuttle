using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShuttle
{
    class Küldetések
    {
        public string KüldetésKód { get; private set; }
        public DateTime KilövésDátuma { get; private set; }
        public string SiklóNeve { get; private set; }
        public int FennTöltöttNapok { get; private set; }
        public int FennTöltöttÓrák { get; private set; }
        public string Támaszpont { get; private set; }
        public int LegénységSzáma { get; private set; }
        public DateTime Visszatérés
        {
            get
            {
                return KilövésDátuma + new TimeSpan(FennTöltöttNapok, FennTöltöttÓrák, 0, 0);
            }
        }
        public double NapokSzámaAzŰrben
        {
            get
            {
                return FennTöltöttNapok + FennTöltöttÓrák / 24.0;
            }
        }
        public double ÓrákSzámaAzŰrben
        {
            get
            {
                return (Visszatérés - KilövésDátuma).TotalHours;
            }
        }

        public Küldetések(string sor)
        {
            string[] mezők = sor.Split(';');
            KüldetésKód = mezők[0];
            KilövésDátuma = DateTime.Parse(mezők[1]);
            SiklóNeve = mezők[2];
            FennTöltöttNapok = int.Parse(mezők[3]);
            FennTöltöttÓrák = int.Parse(mezők[4]);
            Támaszpont = mezők[5];
            LegénységSzáma = int.Parse(mezők[6]);
        }
        

    }
}
