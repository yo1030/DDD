﻿namespace DDD.Domain.ValueObjects
{
    public abstract class ValueObject<T> where T: ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            T vo = obj as T;
            if (vo == null)
            {
                return false;
            }
            return EqualsCore(vo);
        }

        public static bool operator ==(ValueObject<T> x,ValueObject<T> y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !Equals(x, y);
        }
        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
