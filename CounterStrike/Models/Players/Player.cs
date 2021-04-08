
using CounterStrike.Models.Guns.Contracts;
using System;
using System.Text;

namespace CounterStrike.Models.Players.Contracts
{
    public class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        public string Username
        {
            get
            {
                return username;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                username = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player health cannot be below or equal to 0.");
                }
                health = value;
            }
        }


        public int Armor
        {
            get
            {
                return armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player armor cannot be below 0.");
                }
                armor = value;
            }
        }

        public bool IsAlive => this.Health > 0;



        public IGun Gun
        {
            get
            {
                return gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Gun cannot be null or empty.");
                }
                gun = value;
            }
        }

        public void TakeDamage(int points)
        {
            int leftPoints = 0;
            if (this.Armor - points >= 0)
            {
                this.Armor -= points;
            }
            else
            {
                leftPoints = Math.Abs(this.Armor - points);
                this.Armor = 0;
                this.Health -= leftPoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");
            return sb.ToString().TrimEnd();
        }
    }
}