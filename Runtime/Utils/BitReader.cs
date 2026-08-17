namespace QuadUI
{
    public class BitReader
    {
        private ulong value;
        private int index;

        public BitReader(ulong value)
        {
            this.value = value;
            this.index = 0;
        }

        public bool Next()
        {
            bool result = ((value >> index) & 1UL) != 0;
            this.index++;

            return result;
        }
    }
}