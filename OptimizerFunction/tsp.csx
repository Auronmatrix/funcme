using System;
using System.Collections.Generic;
using System.IO;

    public class TravellingSalesmanProblem
    {
        private List<int> nextOrder = new List<int>();
        private double[,] distances;
        private Random random = new Random();

        public double ShortestDistance { get; set; } = 0;

        private string FilePath { get; set; }

        public List<int> CitiesOrder { get; set; } = new List<int>();
        
        private void LoadCities()
        {
            StreamReader reader = new StreamReader(this.FilePath);

            string cities = reader.ReadToEnd();

            reader.Close();

            string[] rows = cities.Split('\n');

            distances = new double[rows.Length, rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                string[] distance = rows[i].Split(' ');
                for (int j = 0; j < distance.Length; j++)
                {
                    distances[i, j] = double.Parse(distance[j]);
                }

                //the number of rows in this matrix represent the number of cities
                //we are representing each city by an index from 0 to N - 1
                //where N is the total number of cities
                this.CitiesOrder.Add(i);
            }

            if (this.CitiesOrder.Count < 1)
                throw new Exception("No cities to order.");
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