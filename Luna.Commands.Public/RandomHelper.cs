using System;
using System.Collections.Generic;
using System.Text;

namespace Luna.Commands.Public {
    internal static class RandomHelper {

        #region Fields

        private static object _randomLock = new object();
        private static Random _random = new Random();

        #endregion

        #region Public Methods

        /// <summary>
        /// Get a random value from a supplied collection.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="validValues">The collection of values to choose from.</param>
        /// <returns>Returns a random value from the supplied collection.</returns>
        public static T GetRandomValue<T>(params T[] sample) {
            if (sample.Length > 0)
                lock (_randomLock)
                    return sample[_random.Next(0, sample.Length - 1)];

            return default;
        }

        #endregion

    }
}
