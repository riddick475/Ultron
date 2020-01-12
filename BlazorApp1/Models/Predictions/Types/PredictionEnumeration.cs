using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlazorApp1.Models.Predictions.Types
{
    public class PredictionEnumeration : IComparable
    {
        protected PredictionEnumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; }

        public int Id { get; }

        public int CompareTo(object? obj)
        {
            return Id.CompareTo((obj as PredictionEnumeration).Id);
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : PredictionEnumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object? obj)
        {
            var otherValue = obj as PredictionEnumeration;

            if (otherValue == null) return false;

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        protected bool Equals(PredictionEnumeration other)
        {
            return Name == other.Name && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id);
        }
    }
}