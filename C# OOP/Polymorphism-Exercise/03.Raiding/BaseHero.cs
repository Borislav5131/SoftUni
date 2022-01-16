namespace _03.Raiding
{
    public abstract class BaseHero
    {
        public string Name { get; set; }
        public  abstract int Power { get; }

        public BaseHero(string name)
        {
            Name = name;
        }

        public virtual string CastAbility()
        {
            return null;
        }
    }
}
