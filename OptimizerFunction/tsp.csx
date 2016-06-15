using System;
using System.Collections.Generic;
using System.IO;

    public class TravellingSalesmanProblem
    {
        private List<int> nextOrder = new List<int>();
        private double[,] distances;
        private Random random = new Random();

        public double ShortestDistance { get; set; } = 0;

        public List<int> CitiesOrder { get; set; } = new List<int>();
        
        private void LoadCities()
        {
            distances = new double[15, 15];
            distances[0, 0] = 0.0;
            distances[0, 1] = 5.0;
            distances[0, 2] = 5.0;
            distances[0, 3] = 6.0;
            distances[0, 4] = 7.0;
            distances[0, 5] = 2.0;
            distances[0, 6] = 5.0;
            distances[0, 7] = 2.0;
            distances[0, 8] = 1.0;
            distances[0, 9] = 5.0;
            distances[0, 10] = 5.0;
            distances[0, 11] = 1.0;
            distances[0, 12] = 2.0;
            distances[0, 13] = 7.1;
            distances[0, 14] = 5.0;

            distances[1, 0] = 5.0;
            distances[1, 1] = 0.0;
            distances[1, 2] = 5.0;
            distances[1, 3] = 5.0;
            distances[1, 4] = 5.0;
            distances[1, 5] = 2.0;
            distances[1, 6] = 5.0;
            distances[1, 7] = 1.0;
            distances[1, 8] = 5.0;
            distances[1, 9] = 6.0;
            distances[1, 10] = 6.0;
            distances[1, 11] = 6.0;
            distances[1, 12] = 6.0;
            distances[1, 13] = 1.0;
            distances[1, 14] = 7.1;

            distances[2, 0] = 5.0;
            distances[2, 1] = 5.0;
            distances[2, 2] = 0.0;
            distances[2, 3] = 6.0;
            distances[2, 4] = 1.0;
            distances[2, 5] = 6.0;
            distances[2, 6] = 5.0;
            distances[2, 7] = 5.0;
            distances[2, 8] = 1.0;
            distances[2, 9] = 6.0;
            distances[2, 10] = 5.0;
            distances[2, 11] = 7.0;
            distances[2, 12] = 1.0;
            distances[2, 13] = 5.0;
            distances[2, 14] = 6.0;

            distances[3, 0] = 6.0;
            distances[3, 1] = 5.0;
            distances[3, 2] = 6.0;
            distances[3, 3] = 0.0;
            distances[3, 4] = 5.0;
            distances[3, 5] = 2.0;
            distances[3, 6] = 1.0;
            distances[3, 7] = 6.0;
            distances[3, 8] = 5.0;
            distances[3, 9] = 6.0;
            distances[3, 10] = 2.0;
            distances[3, 11] = 1.0;
            distances[3, 12] = 2.0;
            distances[3, 13] = 1.0;
            distances[3, 14] = 5.0;

            distances[4, 0] = 7.0;
            distances[4, 1] = 5.0;
            distances[4, 2] = 1.0;
            distances[4, 3] = 5.0;
            distances[4, 4] = 0.0;
            distances[4, 5] = 7.0;
            distances[4, 6] = 1.0;
            distances[4, 7] = 1.0;
            distances[4, 8] = 2.0;
            distances[4, 9] = 1.0;
            distances[4, 10] = 5.0;
            distances[4, 11] = 6.0;
            distances[4, 12] = 2.0;
            distances[4, 13] = 2.0;
            distances[4, 14] = 5.0;

            distances[5, 0] = 2.0;
            distances[5, 1] = 2.0;
            distances[5, 2] = 6.0;
            distances[5, 3] = 2.0;
            distances[5, 4] = 7.0;
            distances[5, 5] = 0.0;
            distances[5, 6] = 5.0;
            distances[5, 7] = 5.0;
            distances[5, 8] = 6.0;
            distances[5, 9] = 5.0;
            distances[5, 10] = 2.0;
            distances[5, 11] = 5.0;
            distances[5, 12] = 1.0;
            distances[5, 13] =;
            distances[5, 14] = 2.0;

            distances[6, 0] = 5.0;
            distances[6, 1] = 5.0;
            distances[6, 2] = 5.0;
            distances[6, 3] = 1.0;
            distances[6, 4] = 1.0;
            distances[6, 5] = 5.0;
            distances[6, 6] = 0.0;
            distances[6, 7] = 2.0;
            distances[6, 8] = 6.0;
            distances[6, 9] = 1.0;
            distances[6, 10] = 5.0;
            distances[6, 11] = 7.0;
            distances[6, 12] = 5.0;
            distances[6, 13] = 1.0;
            distances[6, 14] = 6.0;

            distances[7, 0] = 2.0;
            distances[7, 1] = 1.0;
            distances[7, 2] = 5.0;
            distances[7, 3] = 6.0;
            distances[7, 4] = 1.0;
            distances[7, 5] = 5.0;
            distances[7, 6] = 2.0;
            distances[7, 7] = 0.0;
            distances[7, 8] = 7.0;
            distances[7, 9] = 6.0;
            distances[7, 10] = 2.0;
            distances[7, 11] = 1.0;
            distances[7, 12] = 1.0;
            distances[7, 13] = 5.0;
            distances[7, 14] = 2.0;

            distances[8, 0] = 1.0;
            distances[8, 1] = 5.0;
            distances[8, 2] = 1.0;
            distances[8, 3] = 5.0;
            distances[8, 4] = 2.0;
            distances[8, 5] = 6.0;
            distances[8, 6] = 6.0;
            distances[8, 7] = 7.0;
            distances[8, 8] = 0.0;
            distances[8, 9] = 5.0;
            distances[8, 10] = 5.0;
            distances[8, 11] = 5.0;
            distances[8, 12] = 1.0;
            distances[8, 13] = 6.0;
            distances[8, 14] = 6.0;

            distances[9, 0] = 5.0;
            distances[9, 1] = 6.0;
            distances[9, 2] = 6.0;
            distances[9, 3] = 6.0;
            distances[9, 4] = 1.0;
            distances[9, 5] = 5.0;
            distances[9, 6] = 1.0;
            distances[9, 7] = 6.0;
            distances[9, 8] = 5.0;
            distances[9, 9] = 0.0;
            distances[9, 10] = 7.0;
            distances[9, 11] = 1.0;
            distances[9, 12] = 2.0;
            distances[9, 13] = 5.0;
            distances[9, 14] = 2.0;

            distances[10, 0] = 5.0;
            distances[10, 1] = 6.0;
            distances[10, 2] = 5.0;
            distances[10, 3] = 2.0;
            distances[10, 4] = 5.0;
            distances[10, 5] = 2.0;
            distances[10, 6] = 5.0;
            distances[10, 7] = 2.0;
            distances[10, 8] = 5.0;
            distances[10, 9] = 7.0;
            distances[10, 10] = 0.0;
            distances[10, 11] = 2.0;
            distances[10, 12] = 1.0;
            distances[10, 13] = 2.0;
            distances[10, 14] = 1.0;

            distances[11, 0] = 1.0;
            distances[11, 1] = 6.0;
            distances[11, 2] = 7.0;
            distances[11, 3] = 1.0;
            distances[11, 4] = 6.0;
            distances[11, 5] = 5.0;
            distances[11, 6] = 7.0;
            distances[11, 7] = 1.0;
            distances[11, 8] = 5.0;
            distances[11, 9] = 1.0;
            distances[11, 10] = 2.0;
            distances[11, 11] = 0.0;
            distances[11, 12] = 5.0;
            distances[11, 13] = 6.0;
            distances[11, 14] = 5.0;

            distances[12, 0] = 2.0;
            distances[12, 1] = 6.0;
            distances[12, 2] = 1.0;
            distances[12, 3] = 2.0;
            distances[12, 4] = 2.0;
            distances[12, 5] = 1.0;
            distances[12, 6] = 5.0;
            distances[12, 7] = 1.0;
            distances[12, 8] = 1.0;
            distances[12, 9] = 2.0;
            distances[12, 10] = 1.0;
            distances[12, 11] = 5.0;
            distances[12, 12] = 0.0;
            distances[12, 13] = 7.0;
            distances[12, 14] = 6.0;

            distances[13, 0] = 7.0;
            distances[13, 1] = 1.0;
            distances[13, 2] = 5.0;
            distances[13, 3] = 1.0;
            distances[13, 4] = 2.0;
            distances[13, 5] = 2.0;
            distances[13, 6] = 1.0;
            distances[13, 7] = 5.0;
            distances[13, 8] = 6.0;
            distances[13, 9] = 5.0;
            distances[13, 10] = 2.0;
            distances[13, 11] = 6.0;
            distances[13, 12] = 7.0;
            distances[13, 13] = 0.0;
            distances[13, 14] = 5.0;

            distances[14, 0] = 5.0;
            distances[14, 1] = 7.0;
            distances[14, 2] = 6.0;
            distances[14, 3] = 5.0;
            distances[14, 4] = 5.0;
            distances[14, 5] = 5.0;
            distances[14, 6] = 6.0;
            distances[14, 7] = 2.0;
            distances[14, 8] = 6.0;
            distances[14, 9] = 2.0;
            distances[14, 10] = 1.0;
            distances[14, 11] = 5.0;
            distances[14, 12] = 6.0;
            distances[14, 13] = 5.0;
            distances[14, 14] = 0.0;


        }

        private double GetTotalDistance(List<int> order)
        {
            double distance = 0;

            for (int i = 0; i < order.Count - 1; i++)
            {
                distance += distances[order[i], order[i + 1]];
            }

            if (order.Count > 0)
            {
                distance += distances[order[order.Count - 1], 0];
            }

            return distance;
        }

        private List<int> GetNextArrangement(List<int> order)
        {
            List<int> newOrder = new List<int>();

            for (int i = 0; i < order.Count; i++)
                newOrder.Add(order[i]);

            //we will only rearrange two cities by random
            //starting point should be always zero - so zero should not be included

            int firstRandomCityIndex = random.Next(1, newOrder.Count);
            int secondRandomCityIndex = random.Next(1, newOrder.Count);

            int dummy = newOrder[firstRandomCityIndex];
            newOrder[firstRandomCityIndex] = newOrder[secondRandomCityIndex];
            newOrder[secondRandomCityIndex] = dummy;

            return newOrder;
        }

        public void Anneal()
        {
            int iteration = -1;

            double temperature = 10000.0;
            double deltaDistance = 0;
            double coolingRate = 0.9999;
            double absoluteTemperature = 0.00001;

            LoadCities();

            double distance = GetTotalDistance(this.CitiesOrder);

            while (temperature > absoluteTemperature)
            {
                nextOrder = GetNextArrangement(this.CitiesOrder);

                deltaDistance = GetTotalDistance(nextOrder) - distance;

                //if the new order has a smaller distance
                //or if the new order has a larger distance but satisfies Boltzman condition then accept the arrangement
                if ((deltaDistance < 0) || (distance > 0 && Math.Exp(-deltaDistance / temperature) > random.NextDouble()))
                {
                    for (int i = 0; i < nextOrder.Count; i++)
                        this.CitiesOrder[i] = nextOrder[i];

                    distance = deltaDistance + distance;
                }

                //cool down the temperature
                temperature *= coolingRate;

                iteration++;
            }

            this.ShortestDistance = distance;
        }
    }