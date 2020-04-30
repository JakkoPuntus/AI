using System;

namespace AI
{

    class Program
    {
        static void Main(string[] args)
        {
            int[,] input = new int[,] {{1, 1, 1}, {1,1,0}, {0, 0, 0}} ;
            int[] outputs = {0, 1, 1};

            Random r = new Random();

            double[] weights = { r.NextDouble(), r.NextDouble(), r.NextDouble(), r.NextDouble(), };

            double learningRate = 1;
            double totalError = 1;

            while (totalError > 0.2)
            {
                totalError = 0;
                for (int i = 0; i < 3; i++)
                {
                    int output = calculateOutput(input[i, 0], input[i, 1], input[i, 2], weights);

                    int error = outputs[i] - output;

                    weights[0] += learningRate * error * input[i, 0];
                    weights[1] += learningRate * error * input[i, 1];
                    weights[2] += learningRate * error * input[i, 1];
                    weights[3] += learningRate * error * 1;

                    totalError += Math.Abs(error);
                }

            } 

            Console.WriteLine("Results:");
            for (int i = 0; i < 3; i++)
                Console.WriteLine(calculateOutput(input[i, 0], input[i, 1], input[i, 2] weights));

            Console.ReadLine();

        }

        private static int calculateOutput(double input1, double input2, double input3, double[] weights)
        {
            double sum = input1 * weights[0] + input2 * weights[1] + input3 * weights[2] + 1*weights[3];
            return (sum >= 0) ? 1 : 0;
        }
    }

}
