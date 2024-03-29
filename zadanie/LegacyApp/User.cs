using System;

namespace LegacyApp
{
    public class User
    {
        public object client { get; internal set; }
        public DateTime dateOfBirth { get; internal set; }
        public string emailAddress { get; internal set; }
        public string firstName { get; internal set; }
        public string lastName { get; internal set; }
        public bool hasCreditLimit { get; internal set; }
        public int creditLimit { get; internal set; }
    }
}