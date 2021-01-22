using System;
using WooliesX.Core.Infrastructure;

namespace WooliesX.API.Helpers
{
    public class ClassHelpers
    {
        public SortTerm CreateSortTerm(string sortOptions)
        {
            //default sort
            var sortTerm = new SortTerm
            {
                Descending = false,
                Name = "Name"
            };

            if (sortOptions.ToLower() == "high")
            {
                sortTerm.Descending = true;
                sortTerm.Name = "Price";
            }
            if (sortOptions.ToLower() == "low")
            {
                sortTerm.Name = "Price";
            }
            if (sortOptions.ToLower() == "descending")
            {
                sortTerm.Descending = true;
            }
            if (sortOptions == "Recommended")
            {
                sortTerm.Descending = true;
                sortTerm.Name = "Quantity";
            }
            return sortTerm;
        }
    }
}
