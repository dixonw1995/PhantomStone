using System;

namespace AssemblyCSharp
{
	public static class EnumExtension
	{

		/// <summary>
		/// Convert enum item to bool by comparing with benchmark.
		/// </summary>
		/// <returns><c>true</c>, if int value of item <= benchmark, <c>false</c> otherwise.</returns>
		/// <param name="value">Value.</param>
		/// <param name="benchmark">Benchmark.</param>
		public static bool ToBool (this Enum value, int benchmark = 0) {
			return Convert.ToInt32 (value) < benchmark;
		}

		/// <summary>
		/// Convert enum item to bool by comparing with benchmark.
		/// </summary>
		/// <returns><c>true</c>, if int value of item <= benchmark, <c>false</c> otherwise.</returns>
		/// <param name="value">Value.</param>
		/// <param name="benchmark">Benchmark.</param>
		public static bool ToBool (this Enum value, Enum benchmark) {
			return Convert.ToInt32 (value) < Convert.ToInt32 (benchmark);
		}

		/// <summary>
		/// Return next enum item. Return first item if variable is the last item
		/// </summary>
		/// <param name="variable">Variable.</param>
		public static Enum Next (this Enum variable) {
			Array enumValues = Enum.GetValues (variable.GetType ());
			int index = Array.IndexOf<Enum> ((Enum[])enumValues, (Enum)variable);
			return (Enum)enumValues.GetValue ((index + 1) % enumValues.Length);
		}

		/// <summary>
		/// A FX 3.5 way to mimic the FX4 "HasFlag" method.
		/// </summary>
		/// <param name="variable">The tested enum.</param>
		/// <param name="value">The value to test.</param>
		/// <returns>True if the flag is set. Otherwise false.</returns>
		public static bool HasFlag(this Enum variable, Enum value)
		{
			// check if from the same type.
			if (variable.GetType() != value.GetType())
			{
				throw new ArgumentException("The checked flag is not from the same type as the checked variable.");
			}

			ulong num = Convert.ToUInt64(value);
			ulong num2 = Convert.ToUInt64(variable);

			return (num2 & num) == num;
		}
	}
}

