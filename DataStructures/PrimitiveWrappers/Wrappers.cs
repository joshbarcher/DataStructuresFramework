using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;

namespace DataStructures.PrimitiveWrappers
{
    /// <summary>
    /// Wrapper class for the integer primitive.
    /// </summary>
    public class DSInteger : GenericWrapper<int>, Comparable<DSInteger>, Cloneable
    {
        /// <summary>
        /// Sets up the integer with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSInteger(int the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this integer to another integer.
        /// </summary>
        /// <param name="the_other">the other integer.</param>
        /// <returns>a negative number if this integer is smaller, 0 if they are the same,
        /// otherwise a positive number because this integer is larger.</returns>
        public int compareTo(DSInteger the_other)
        {
            return value - the_other.value;
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an integer clone.</returns>
        public object clone()
        {
            return new DSInteger(value);
        }

        /// <summary>
        /// Shows whether this integer and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSInteger))
            {
                return false;
            }
            else
            {
                return value == ((DSInteger)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the integer.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the inner integer.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Wrapper class for the long primitive.
    /// </summary>
    public class DSLong : GenericWrapper<long>, Comparable<DSLong>, Cloneable
    {
        /// <summary>
        /// Sets up the long with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSLong(long the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this long to another long.
        /// </summary>
        /// <param name="the_other">the other long.</param>
        /// <returns>a negative number if this long is smaller, 0 if they are the same,
        /// otherwise a positive number because this long is larger.</returns>
        public int compareTo(DSLong the_other)
        {
            return (int)(value - the_other.value);
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an long clone.</returns>
        public object clone()
        {
            return new DSLong(value);
        }

        /// <summary>
        /// Shows whether this long and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSLong))
            {
                return false;
            }
            else
            {
                return value == ((DSLong)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the long.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the inner long.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Wrapper class for the short primitive.
    /// </summary>
    public class DSShort : GenericWrapper<short>, Comparable<DSShort>, Cloneable
    {
        /// <summary>
        /// Sets up the short with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSShort(short the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this short to another short.
        /// </summary>
        /// <param name="the_other">the other short.</param>
        /// <returns>a negative number if this short is smaller, 0 if they are the same,
        /// otherwise a positive number because this short is larger.</returns>
        public int compareTo(DSShort the_other)
        {
            return value - the_other.value;
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an short clone.</returns>
        public object clone()
        {
            return new DSShort(value);
        }

        /// <summary>
        /// Shows whether this short and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSShort))
            {
                return false;
            }
            else
            {
                return value == ((DSShort)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the short.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the inner short.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Wrapper class for the byte primitive.
    /// </summary>
    public class DSByte : GenericWrapper<byte>, Comparable<DSByte>, Cloneable
    {
        /// <summary>
        /// Sets up the byte with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSByte(byte the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this byte to another byte.
        /// </summary>
        /// <param name="the_other">the other byte.</param>
        /// <returns>a negative number if this byte is smaller, 0 if they are the same,
        /// otherwise a positive number because this byte is larger.</returns>
        public int compareTo(DSByte the_other)
        {
            return value - the_other.value;
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an byte clone.</returns>
        public object clone()
        {
            return new DSByte(value);
        }

        /// <summary>
        /// Shows whether this byte and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSByte))
            {
                return false;
            }
            else
            {
                return value == ((DSByte)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the byte.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the inner byte.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Wrapper class for the boolean primitive.
    /// </summary>
    public class DSBoolean : GenericWrapper<bool>, Comparable<DSBoolean>, Cloneable
    {
        /// <summary>
        /// Sets up the boolean with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSBoolean(bool the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this boolean to another boolean.
        /// </summary>
        /// <param name="the_other">the other boolean.</param>
        /// <returns>a negative number if this boolean is smaller, 0 if they are the same,
        /// otherwise a positive number because this boolean is larger.</returns>
        public int compareTo(DSBoolean the_other)
        {
            if (!value && the_other.value)
            {
                return -1;
            }
            else if (!value && the_other.value)
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an boolean clone.</returns>
        public object clone()
        {
            return new DSBoolean(value);
        }

        /// <summary>
        /// Shows whether this boolean and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSBoolean))
            {
                return false;
            }
            else
            {
                return value == ((DSBoolean)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the boolean.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the inner boolean.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Wrapper class for the character primitive.
    /// </summary>
    public class DSCharacter : GenericWrapper<char>, Comparable<DSCharacter>, Cloneable
    {
        /// <summary>
        /// Sets up the character with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSCharacter(char the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this character to another character.
        /// </summary>
        /// <param name="the_other">the other character.</param>
        /// <returns>a negative number if this character is smaller, 0 if they are the same,
        /// otherwise a positive number because this character is larger.</returns>
        public int compareTo(DSCharacter the_other)
        {
            return value - the_other.value;
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an character clone.</returns>
        public object clone()
        {
            return new DSCharacter(value);
        }

        /// <summary>
        /// Shows whether this character and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSCharacter))
            {
                return false;
            }
            else
            {
                return value == ((DSCharacter)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the character.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the inner character.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Wrapper class for the string primitive/class.
    /// </summary>
    public class DSString : GenericWrapper<string>, Comparable<DSString>, Cloneable
    {
        /// <summary>
        /// Sets up the string with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSString(string the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this string to another string.
        /// </summary>
        /// <param name="the_other">the other string.</param>
        /// <returns>a negative number if this string is smaller, 0 if they are the same,
        /// otherwise a positive number because this string is larger.</returns>
        public int compareTo(DSString the_other)
        {
            return value.CompareTo(the_other.value);
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an string clone.</returns>
        public object clone()
        {
            return new DSString(value);
        }

        /// <summary>
        /// Shows whether this string and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSString))
            {
                return false;
            }
            else
            {
                return value == ((DSString)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the string.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the string integer.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Wrapper class for the double primitive.
    /// </summary>
    public class DSDouble : GenericWrapper<double>, Comparable<DSDouble>, Cloneable
    {
        /// <summary>
        /// Sets up the double with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSDouble(double the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this double to another double.
        /// </summary>
        /// <param name="the_other">the other double.</param>
        /// <returns>a negative number if this double is smaller, 0 if they are the same,
        /// otherwise a positive number because this double is larger.</returns>
        public int compareTo(DSDouble the_other)
        {
            return value.CompareTo(the_other);
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an double clone.</returns>
        public object clone()
        {
            return new DSDouble(value);
        }

        /// <summary>
        /// Shows whether this double and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSDouble))
            {
                return false;
            }
            else
            {
                return value == ((DSDouble)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the double.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the inner double.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Wrapper class for the float primitive.
    /// </summary>
    public class DSFloat : GenericWrapper<float>, Comparable<DSFloat>, Cloneable
    {
        /// <summary>
        /// Sets up the float with an initial value.
        /// </summary>
        /// <param name="the_value">the new value.</param>
        public DSFloat(float the_value)
            : base(the_value)
        {
        }

        /// <summary>
        /// Compares this float to another float.
        /// </summary>
        /// <param name="the_other">the other float.</param>
        /// <returns>a negative number if this float is smaller, 0 if they are the same,
        /// otherwise a positive number because this float is larger.</returns>
        public int compareTo(DSFloat the_other)
        {
            return value.CompareTo(the_other);
        }

        /// <summary>
        /// Provides a clone of this class.
        /// </summary>
        /// <returns>an float clone.</returns>
        public object clone()
        {
            return new DSFloat(value);
        }

        /// <summary>
        /// Shows whether this float and another object are equal.
        /// </summary>
        /// <param name="the_other">the other object.</param>
        /// <returns>true if they are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is DSFloat))
            {
                return false;
            }
            else
            {
                return value == ((DSFloat)the_other).value;
            }
        }

        /// <summary>
        /// Gets a hash code for the float.
        /// </summary>
        /// <returns>a hash code.</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of this class.
        /// </summary>
        /// <returns>a string representation of the inner float.</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }
}
