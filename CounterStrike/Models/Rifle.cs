using CounterStrike.Models.Guns;

namespace CounterStrike.Models
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount > 0)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }
    }
}
