namespace AlgorithmsPractice.StacksAndQueues
{
    public class TowerOfHanoi
    {
        private readonly Stack<int> _disks = new Stack<int>();

        public TowerOfHanoi(int index)
        {
            Index = index;
        }

        public int Index { get; }

        public bool Add(int disk)
        {
            if(!_disks.IsEmpty() && _disks.Peek() <= disk)
            {
                return false;
            }

            _disks.Push(disk);
            return true;
        }

        public void MoveTopTo(TowerOfHanoi tower)
        {
            var top = _disks.Pop();
            tower.Add(top);
        }

        public void MoveDisks(int n, TowerOfHanoi destination, TowerOfHanoi buffer)
        {
            if(n > 0)
            {
                MoveDisks(n - 1, buffer, destination);
                MoveTopTo(destination);
                buffer.MoveDisks(n - 1, destination, this);
            }
        }

        public int Pop()
        {
            return _disks.Pop();
        }
    }
}
