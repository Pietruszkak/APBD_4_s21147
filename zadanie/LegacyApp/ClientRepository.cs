using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class ClientRepository
    {
        /// <summary>
        /// This collection is used to simulate remote database
        /// </summary>
        public static readonly Dictionary<int, Client> database = new Dictionary<int, Client>()
        {
            {1, new Client{clientId = 1, name = "Kowalski", address = "Warszawa, Złota 12", email = "kowalski@wp.pl", type = "NormalClient"}},
            {2, new Client{clientId = 2, name = "Malewski", address = "Warszawa, Koszykowa 86", email = "malewski@gmail.pl", type = "VeryImportantClient"}},
            {3, new Client{clientId = 3, name = "Smith", address = "Warszawa, Kolorowa 22", email = "smith@gmail.pl", type = "ImportantClient"}},
            {4, new Client{clientId = 4, name = "Doe", address = "Warszawa, Koszykowa 32", email = "doe@gmail.pl", type = "ImportantClient"}},
            {5, new Client{clientId = 5, name = "Kwiatkowski", address = "Warszawa, Złota 52", email = "kwiatkowski@wp.pl", type = "NormalClient"}},
            {6, new Client{clientId = 6, name = "Andrzejewicz", address = "Warszawa, Koszykowa 52", email = "andrzejewicz@wp.pl", type = "NormalClient"}}
        };
        
        public ClientRepository()
        {
        }

        /// <summary>
        /// Simulating fetching a client from remote database
        /// </summary>
        /// <returns>Returning client object</returns>
        internal Client GetById(int clientId)
        {
            int randomWaitTime = new Random().Next(2000);
            Thread.Sleep(randomWaitTime);

            if (database.ContainsKey(clientId))
                return database[clientId];

            throw new ArgumentException($"User with id {clientId} does not exist in database");
        }
    }
}