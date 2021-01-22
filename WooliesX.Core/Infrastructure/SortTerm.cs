using System;
namespace WooliesX.Core.Infrastructure
{
    public class SortTerm
    {
        private string sortOptions;

        public SortTerm(string sortOptions)
        {
            this.sortOptions = sortOptions;
        }

        public string Name { get; set; }
        public bool Descending { get; set; }

        public void GetSortTerm()
        {
            //default sort
            Descending = false;
            Name = "Name";

            if (!string.IsNullOrEmpty(sortOptions))
            {
                if (sortOptions.ToLower() == "high")
                {
                    Descending = true;
                    Name = "Price";
                }
                if (sortOptions.ToLower() == "low")
                {
                    Name = "Price";
                }
                if (sortOptions.ToLower() == "descending")
                {
                    Descending = true;
                }
                if (sortOptions.ToLower() == "recommended")
                {
                    Descending = true;
                    Name = "Quantity";
                }
            }
        }
    }
}
