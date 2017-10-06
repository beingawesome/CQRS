using System;

namespace Cqrs.Versioning
{

    public struct Commit
    {
        public static readonly Commit Any = new Commit(-1);

        private long _major;
        private long _minor;

        private Commit(int any)
        {
            _major = -1;
            _minor = -1;
        }

        public Commit(long major, long minor)
        {
            if (major < 0) throw new Exception($"{nameof(major)} must be greater than or equal to 0.");
            if (minor < 0) throw new Exception($"{nameof(minor)} must be greater than or equal to 0.");

            _major = major;
            _minor = minor;
        }

        public override bool Equals(object obj) => obj is Commit c ? c == this : false;

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + _major.GetHashCode();
                hash = hash * 23 + _minor.GetHashCode();

                return hash;
            }
        }

        public override string ToString() => $"{_major}.{_minor}";

        public static bool operator >(Commit left, Commit right)
        {
            return left._major > right._major || (left._major == right._major && left._minor > right._minor);
        }

        public static bool operator <(Commit left, Commit right)
        {
            return left._major < right._major || (left._major == right._major && left._minor < right._minor);
        }

        public static bool operator >=(Commit left, Commit right)
        {
            return left._major > right._major || (left._major == right._major && left._minor >= right._minor);
        }

        public static bool operator <=(Commit left, Commit right)
        {
            return left._major < right._major || (left._major == right._major && left._minor <= right._minor);
        }

        public static bool operator ==(Commit left, Commit right)
        {
            return left._major == right._major && left._minor == right._minor;
        }

        public static bool operator !=(Commit left, Commit right)
        {
            return left._major != right._major || left._minor != right._minor;
        }
    }
}
