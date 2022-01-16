namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int defaultComfort = 1;
        private const decimal defaultPrice = 5;
        public Ornament()
            : base(defaultComfort, defaultPrice)
        {
        }
    }
}
