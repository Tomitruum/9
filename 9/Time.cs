namespace TimeApp
{
    public class Time
    {
        public byte hours;
        public byte minutes;

        public Time(byte chasov, byte minut)
        {
            if (chasov > 23 || minut > 59)
                throw new ArgumentOutOfRangeException("Некорректное время: часы должны быть 0–23, минуты 0–59.");

            hours = chasov;
            minutes = minut;
        }

        public Time vichestMinuty(uint skolko)
        {
            int vsegoMinut = hours * 60 + minutes - (int)skolko;
            if (vsegoMinut < 0)
            {
                vsegoMinut = 24 * 60 + vsegoMinut % (24 * 60);
            }
            byte novChas = (byte)((vsegoMinut / 60) % 24);
            byte novMin = (byte)(vsegoMinut % 60);
            return new Time(novChas, novMin);
        }

        public static Time operator -(Time vremya, uint skolko)
        {
            return vremya.vichestMinuty(skolko);
        }

        public static Time operator !(Time vremya)
        {
            return new Time(0, 0);
        }

        public static Time operator --(Time vremya)
        {
            return new Time(vremya.hours, 0);
        }

        public static implicit operator byte(Time vremya)
        {
            return vremya.hours;
        }

        public static explicit operator bool(Time vremya)
        {
            return vremya.hours != 0 || vremya.minutes != 0;
        }

        public static bool operator ==(Time a, Time b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.hours == b.hours && a.minutes == b.minutes;
        }


        public static bool operator !=(Time a, Time b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Time drugoe)
                return this == drugoe;
            return false;
        }

        public override int GetHashCode()
        {
            return hours.GetHashCode() ^ minutes.GetHashCode();
        }

        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}";
        }
    }
}
