using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    /// <summary>
    ///  structure to represent the name. 
    /// </summary>
    public struct FullName : IComparable<FullName>
    {
        // Given Name
        public String GivenName { get; set; }

        // Last Name
        public String LastName { get; set; }

        /// <summary>
        ///  Constructor 
        /// </summary>
        /// <param name="name">The value to initialize the instance. Atleast one Given Name ( max 3 ) and one Last Name should be specified ("GivenName LstName"). </param>
        /// <exception cref="ArgumentException"></exception>
        public FullName(string name)
        {


            if (name.Trim().Length == 0)
            {
                // name should have atlest one character, it cannot be empty. throw ArgumentException
                throw new ArgumentException("Invalid input Empty value provided.");
            }

            // name is in format "GivenName LastName"
            // get the last index for ' ' and use it to get the starting pos for the last name.
            int lastDelimPos = name.Trim().LastIndexOf(' ');


            if (lastDelimPos == -1)
            {
                // One of GivenName or LastName is missing. throw ArgumentException.
                throw new ArgumentException($"Invalid format for the entry '{name}'. Format should be 'GivenName LastName'");
            }


            // Given Name is the sequence of characters from 0 to position of last occurance of ' '
            GivenName = name.Substring(0, lastDelimPos);

            // Last Name is the sequence of characters from (position +1) of last occurance of ' ' till end of string.
            LastName = name.Substring(lastDelimPos + 1);

            // validate number of given names
            string[] parts = GivenName.Split(' ');
            if (parts.Length > 3)
            {
                // more than 3 given names found. throw ArgumentException.
                throw new ArgumentException($" Given Names count > 3. Invalid input :  '{name}'");
            }
        }

        /// <summary>
        ///  default construction. Initializes the GivenName and LastName to Empty String.
        /// </summary>
        public FullName()
        {
            GivenName = String.Empty;
            LastName = String.Empty;
        }

        /// <summary>
        ///  Method to provide an CompareTo implementation to the struct Full Name. 
        ///  Needed to support Sort() of Collection classes like List,Array etc. 
        /// </summary>
        /// <param name="obj"> An object to compare with this instance.</param>
        /// <returns> 
        ///     A value that indicates the relative order of the objects being compared. The
        ///     return value has these meanings:
        ///     Value – Meaning
        ///     Less than zero – This instance precedes other in the sort order.
        ///     Zero – This instance occurs in the same position in the sort order as other.
        ///     Greater than zero – This instance follows other in the sort order.
        ///  </returns>
        int IComparable<FullName>.CompareTo(FullName obj)
        {

            int nCompareLastName = String.Compare(LastName, obj.LastName, true);

            if (nCompareLastName == 0)
            {
                return String.Compare(GivenName, obj.GivenName, true);
            }

            return nCompareLastName;

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (String.Compare(this.ToString(), obj.ToString(), true) == 0)
                return true;

            return base.Equals(obj);
        }

        /// <summary>
        ///  String representation of the instance. Returns "GivenName LastName"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GivenName + " " + LastName;
        }

        /// <summary>
        /// Generate the HashCode for the instance.
        /// </summary>
        /// <returns>integer value</returns>
        public override int GetHashCode()
        {
            return GivenName.GetHashCode() + LastName.GetHashCode();
        }
    }
}
