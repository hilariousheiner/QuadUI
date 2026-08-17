using System.Text;

namespace QuadUI
{
    public class HashUtility
    {
        public static ulong Hash(string s)
        {
            return HashUtility.FMix64(HashUtility.FNV64(s));
        }

        // MurmuHash finalizer, written by Austin Appleby:
        // https://github.com/aappleby/smhasher/blob/master/src/MurmurHash3.cpp
        public static ulong FMix64(ulong h)
        {
            h ^= h >> 33;
            h *= 0xff51afd7ed558ccdUL;
            h ^= h >> 33;
            h *= 0xc4ceb9fe1a85ec53UL;
            h ^= h >> 33;

            return h;
        }

        // FNV-1a hash function:
        // https://en.wikipedia.org/wiki/Fowler-Noll-Vo_hash_function
        public static ulong FNV64(string s)
        {
            const ulong offsetBasis = 14695981039346656037UL;
            const ulong prime = 1099511628211UL;

            ulong h = offsetBasis;

            foreach (byte b in Encoding.UTF8.GetBytes(s))
            {
                h ^= b;
                h *= prime;
            }
            return h;
        }
    }
}
