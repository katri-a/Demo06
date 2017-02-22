using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace teht1_tiedosto
{
    class Program
    {
        static void Main(string[] args)
        {
            Chors chor = new Chors();

            
            Stream writeStream = new FileStream(@"C:\Users\Katri\Desktop\chors.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            Console.WriteLine("Give new finished chor: ");
            IFormatter formatter = new BinaryFormatter();
            string line = "";
            line = Console.ReadLine();

            //exit by entering empty line
            while (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(string.Format("Write next or press enter to exit..."));
                line = Console.ReadLine();
            }
            formatter.Serialize(writeStream, chor);
            writeStream.Close();

            Stream readStream = new FileStream(@"C:\Users\Katri\Desktop\chors.txt", FileMode.Open, FileAccess.Read, FileShare.None);

            Chors readChors = (Chors)formatter.Deserialize(readStream);
            // write proof
            Console.WriteLine("Done chors {0}", chor);
       
           }
        }
    }


