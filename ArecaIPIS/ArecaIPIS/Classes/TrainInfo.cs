using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArecaIPIS.Classes
{
    class TrainInfo
    {
        public string TrainNumber { get; set; }
        public string TrainNameEN { get; set; }
        public string TrainNameHI { get; set; }
        public string TrainNameL { get; set; } // Local language
        public string STA { get; set; } // Scheduled Time of Arrival
        public string STD { get; set; } // Scheduled Time of Departure
        public string PF { get; set; } // Platform
        public string Coaches { get; set; } // Comma-separated
        public string StatUpDown { get; set; } // Comma-separated
        public string Days { get; set; } // Comma-separated
       

        public override string ToString()
        {
            //return $"{TrainNumber}|{TrainNameEN}|{TrainNameHI}|{TrainNameL}|{STA}|{STD}|{PF}|{Coaches}|{StatUpDown}|{Days}";
            return $"{TrainNumber}|{TrainNameEN}|{TrainNameHI}|{TrainNameL}";
        }

        public static TrainInfo FromString(string line)
        {
            var parts = line.Split('|');
            if(parts.Length<10)
            {
                Array.Resize(ref parts, 10); // Note: ref keyword is required
            }
            return new TrainInfo
            {
                TrainNumber = parts[0],
                TrainNameEN = parts[1],
                TrainNameHI = parts[2],
                TrainNameL = parts[3],
                //STA = parts[4],
                //STD = parts[5],
                //PF=parts[6],
                //Coaches = parts[7]
                //StatUpDown=parts[8],
                //Days=parts[9]

            };
        }
    }
}
