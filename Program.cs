using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Author: Jacob M Cavish
 Date: 07/02/2018
 Purpose: To generate a random Int32, mask the last 4 bits, and safely store those last 4 bits
     */
namespace Avalara_Test_Project
{
    class Program
    {
        static ArrayList storageR = new ArrayList(); //used to store raw integer
        static ArrayList storageN = new ArrayList(); //used to store new integer
        static ArrayList storageM= new ArrayList(); //used to store masked bits
        static Random generator = new Random(); //using this to generate my random number
        static int it; //used to read how many iterations the use wants to run
        static Int32 myRaw;  //I plan on masking the last 4 bits
        static Int32 newData; //modified raw data
        static Int32 myMask; //mask used to modify data
        static void Main(string[] args)
        {
            System.Windows.Forms.MessageBox.Show("Please enter the number of Int32 numbers you want masked");
            it = int.Parse(Console.ReadLine());
            for(int i = 0; i<it; i++)
            {
                myRaw = RNGenerate();
                storageR.Add(myRaw);
                myMask = Mask(myRaw);
                storageM.Add(myMask);
                newData = NewRaw(myRaw, myMask);
                storageN.Add(newData);
                Console.WriteLine("Raw data: " + myRaw);
                Console.WriteLine("Modified data: " + newData);
                Console.WriteLine("Corresponding mask: " + myMask +"\r\n");
            }
            
            System.Windows.Forms.MessageBox.Show("End of Program");
        }

        public static Int32 RNGenerate()
        { //raw is a random int32 that is between 1 and 1 less than 2,147,483,647 
            Int32 raw;
            raw = generator.Next(1, Int32.MaxValue);
            return raw;
        }

        public static Int32 Mask(Int32 raw)
        {//returns the last 4 bits of the raw
            Int32 masked = raw & 0xF;
            return masked;
        }

        public static Int32 NewRaw(Int32 oldRaw, Int32 masked)
        {//returns modified data
            Int32 newRaw = oldRaw - masked;
            return newRaw;
        }
    }
}
