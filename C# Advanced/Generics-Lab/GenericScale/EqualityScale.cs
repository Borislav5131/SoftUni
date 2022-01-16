namespace GenericScale
{
    public class EqualityScale<T>
    {
        public T Right { get; set; }
        public T Left { get; set; }

        public EqualityScale(T right, T left)
        {
            Right = right;
            Left = left;
        }

        public bool AreEqual()
        {
            return Right.Equals(Left);
        }
    }
}
