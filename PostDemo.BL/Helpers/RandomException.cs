using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.BL.Helpers {
    public static class RandomException {
        public  static void RandomExceptionGenerate(int? value = null) {
            Random rand = new Random();
            int chance = value ?? rand.Next(1, 100);

            if (chance <= 3) {
                throw new ArgumentException("Random ArgumentException");
            }

            else if (chance <= 6) {
                throw new NullReferenceException("Random NullReferenceException");
            }

            else if (chance <= 9) {
                throw new InvalidOperationException("Random InvalidOperationException");
            }
            else {
                Console.WriteLine("No exception thrown.");
            }
        }

    }
}
