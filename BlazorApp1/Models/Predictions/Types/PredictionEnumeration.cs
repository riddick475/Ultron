namespace BlazorApp1.Models.Predictions.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class PredictionEnumeration : IComparable
    {
        protected PredictionEnumeration(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static IEnumerable<T> GetAll<T>()
            where T : PredictionEnumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public int CompareTo(object? obj)
        {
            return this.Id.CompareTo((obj as PredictionEnumeration).Id);
        }

        public override bool Equals(object? obj)
        {
            var otherValue = obj as PredictionEnumeration;

            if (otherValue == null) return false;

            var typeMatches = this.GetType() == obj.GetType();
            var valueMatches = this.Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Id);
        }

        public override string ToString()
        {
            return this.Name;
        }

        protected bool Equals(PredictionEnumeration other)
        {
            return this.Name == other.Name && this.Id == other.Id;
        }
    }
}