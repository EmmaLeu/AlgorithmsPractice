namespace AlgorithmsPractice.StacksAndQueues
{
    /// <summary>
    /// Implement 3 stacks using only one array (assuming we have fixed size stacks)
    /// </summary>
    public class ThreeStackService
    {
        private readonly int _stackSize;
        private readonly int[] _buffer;
        private readonly int[] _topElementPointers = { 0, 0, 0 };

        public ThreeStackService(int stackSize)
        {
            _stackSize = stackSize;
            _buffer = new int[stackSize * 3];
        }

        public void Push(int stackNo, int value)
        {
            var index = GetTopIndex(stackNo) + 1;
            _topElementPointers[stackNo]++;
            _buffer[index] = value;
        }

        public int Pop(int stackNo)
        {
            var index = GetTopIndex(stackNo);
            _topElementPointers[stackNo]--;
            int value = _buffer[index];
            _buffer[index] = 0;
            return value;
        }

        public int Peek(int stackNo)
        {
            var index = GetTopIndex(stackNo);
            return _buffer[index];
        }

        public bool IsEmpty(int stackNumber)
        {
            return _topElementPointers[stackNumber] == _stackSize * stackNumber;
        }

        private int GetTopIndex(int stackNo)
        {
            return stackNo * _stackSize + _topElementPointers[stackNo];
        }
    }
}
