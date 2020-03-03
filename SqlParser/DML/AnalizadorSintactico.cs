using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.DML
{
    class AnalizadorSintactico
    {
        //int[] a = new int[] { 1, 2, 3 };
        public String[,] dml = new String[,] {
            { null, "300", "301", "302", "303", "304", "305", "306", "307", "308", "309", "310", "311", "312", "313", "314", "315", "316", "317", "318", "319"},
            { "4", null, "302", "304 303", null, "4 305", null, "308 307", null, "4 309", "4", null, "313 312", null, "304 314", null, null, "304", null, null, null},
            { "8", null, null, null, null, null, "99", null, null, null, null, null, null, null, null, "315 316", "8", null, null, null, null},
            { "10", "10 301 11 306 310", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { "11", null, null, null, "99", null, "99", null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { "12", null, null, null, null, null, null, null, "99", null, "99", "12 311", null, null, null, null, null, null, null, null, null},
            { "13", null, null, null, null, null, "99", null, null, null, null, null, null, null, null, "13 52 300 53", null, null, null, null, null},
            { "14", null, null, null, null, null, "99", null, null, null, null, null, null, "317 311", null, null, null, null, "14", null, null},
            { "15", null, null, null, null, null, "99", null, null, null, null, null, null, "317 311", null, null, null, null, "15", null, null},
            { "50", null, null, null, "50 302", null, "99", null, "50 306", null, "99", null, null, null, null, null, null, null, null, null, null},
            { "51", null, null, null, null, null, "51 4", null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { "53", null, null, null, null, null, "99", null, "99", null, "99", "99", null, "99", null, null, null, null, null, null, null},
            { "54", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "54 318 54", null, null, null},
            { "61", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "319", null, null, "61"},
            { "62", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "62", null},
            { "72", null, "72", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null},
            { "199", null, null, null, "99", null, "99", null, "99", null, "99", "99", null, "99", null, null, null, null, null, null, null}
        };


        public AnalizadorSintactico()
        {

        }

    }
}
