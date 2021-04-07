using CounterStrike.Models.Guns;

namespace CounterStrike.Models
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount>0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
