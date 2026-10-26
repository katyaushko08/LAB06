using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB06
{
    internal class Box
    {
        private double length;
        private double width;
        private double depth;

        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Длина должна быть строго больше 0.");
                length = value;
            }
        }
        
        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Ширина должна быть строго больше 0.");
                width = value;
            }
        }
        public double Depth
        {
            get { return depth; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Высота должна быть строго больше 0.");
                depth = value;
            }
        }

        public Box(double length, double width, double depth)
        {
            Length = length;
            Width = width;
            Depth = depth;
        }

        public Box(double size)
        {
            Length = size;
            Width = size;
            Depth = size;
        }

        public double Volume()
        {
            return length * width * depth;
        }

        public static Box operator +(Box a, Box b)
        {
            if (a is null || b is null)
                throw new ArgumentNullException("Коробка не существует.");
            return new Box(
                Math.Max(a.Length, b.Length),
                Math.Max(a.Width, b.Width),
                Math.Max(a.Depth, b.Depth)
                );
        }

        public static Box operator -(Box a, Box b)
        {
            if (a is null || b is null)
                throw new ArgumentNullException("Коробка не существует.");

            Box big, small;
            if (a.Volume() >= b.Volume())
            {
                big = a;
                small = b;
            }
            else
            {
                big = b;
                small = a;
            }
            double newLength = big.Length - small.Length;
            double newWidth = big.Width - small.Width;
            double newDepth = big.Depth - small.Depth;

            if (newLength <= 0 || newWidth <= 0 || newDepth <= 0)
            {
                throw new ArgumentException("Невозможно разместить коробку.");
            }
            
            return new Box(newLength, newWidth, newDepth);
        }

        public override string ToString()
        {
            return $"Box [{length}, {width}, {depth}]";
        }

        public static bool operator ==(Box a, Box b)
        {
            if (ReferenceEquals(a, b))
            {
                return true ;
            }
            if (a is null || b is null)
            {
                return false ;
            }
            return a.Volume() == b.Volume();
        }

        public static bool operator !=(Box a, Box b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Box otherBox)
            {
                return this == otherBox;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Volume().GetHashCode();
        }
    }
}
