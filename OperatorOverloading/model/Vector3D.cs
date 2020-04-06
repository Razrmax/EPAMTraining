using OperatorOverloading.exceptions;
using System;

namespace OperatorOverloading.model
{
    class Vector3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Vector3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D(double[] xyz)
        {
            if (xyz.Length == 3)
            {
                X = xyz[0];
                Y = xyz[1];
                Z = xyz[2];
            }
            else
            {
                throw new InsufficientComponentsException(xyz.Length);
            }
        }

        public Vector3D(Vector3D v1)
        {
            X = v1.X;
            Y = v1.Y;
            Z = v1.Z;
        }

        public double Magnitude
        {
            get { return Math.Sqrt(SumComponentsSqrs()); }
        }

        private double SumComponentsSqrs()
        {
            return Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2);
        }

        public static Vector3D SqrComponents(Vector3D v1)
        {
            return
            (
                new Vector3D
                (
                    v1.X * v1.X,
                    v1.Y * v1.Y,
                    v1.Z * v1.Z
                )
            );
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(
                v1.X + v2.X,
                v1.Y + v2.Y,
                v1.Z + v2.Z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(
                v1.X - v2.X,
                v1.Y - v2.Y,
                v1.Z - v2.Z);
        }

        public static Vector3D operator *(Vector3D v1, double scal)
        {
            return new Vector3D(
                v1.X * scal,
                v1.Y * scal,
                v1.Z * scal);
        }

        /// <summary>
        /// Negation of a vector inverts its direction. Achieved by negating each of the components of a vector
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D v1)
        {
            return new Vector3D(
                -v1.X,
                -v1.Y,
                -v1.Z);
        }

        public static bool operator <(Vector3D v1, Vector3D v2)
        {
            return v1.SumComponentsSqrs() < v2.SumComponentsSqrs();
        }

        public static bool operator >(Vector3D v1, Vector3D v2)
        {
            return v1.SumComponentsSqrs() > v2.SumComponentsSqrs();
        }

        public static bool operator <=(Vector3D v1, Vector3D v2)
        {
            return v1.SumComponentsSqrs() < v2.SumComponentsSqrs();
        }

        public static bool operator >=(Vector3D v1, Vector3D v2)
        {
            return v1.SumComponentsSqrs() > v2.SumComponentsSqrs();
        }

        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            if (v2 is null)
            {
                return v1 is null;
            }
            return v1.Equals(v2, 0.0001);
        }

        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object o)
        {
            // Check object o is a Vector3D object
            if (o is Vector3D)
            {
                // Convert object to Vector3D
                Vector3D otherVector = (Vector3D)o;

                // Check for equality
                return otherVector.Equals(this);
            }
            else
            {
                return false;
            }
        }

        //public bool Equals(Vector3D o)
        //{
        //    return
        //        this.X.Equals(o.X, 0.0001) &&
        //        this.Y.Equals(o.Y, 0.0001) &&
        //        this.Z.Equals(o.Z, 0.0001);
        //}

        //public bool Equals(object o, double tolerance)
        //{
        //    if (o is Vector3D)
        //    {
        //        return this.Equals((Vector3D)o, tolerance);
        //    }
        //    return false;
        //}

        public bool Equals(Vector3D o, double tolerance)
        {
            return
                AlmostEqualsWithAbsTolerance(this.X, o.X, tolerance) &&
                AlmostEqualsWithAbsTolerance(this.Y, o.Y, tolerance) &&
                AlmostEqualsWithAbsTolerance(this.Z, o.Z, tolerance);
        }

        public static bool AlmostEqualsWithAbsTolerance(double a, double b, double maxAbsoluteError)
        {
            double difference = Math.Abs(a) - Math.Abs(b);

            if (a.Equals(b))
            {
                // shortcut, handles infinities
                return true;
            }

            return difference <= maxAbsoluteError;
        }

        public override string ToString()
        {
            string s = "( " + X.ToString("0.##") + ", " + Y.ToString("0.##") + ", " + Z.ToString("0.##") + " )";
            return s;
        }
    }
}
