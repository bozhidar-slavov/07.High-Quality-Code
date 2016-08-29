namespace ClassSizeInCSharp
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be less or equal to zero!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be less or equal to zero!");
                }

                this.height = value;
            }
        }

        public static Size GetRotatedSize(Size objectToRotate, double rotationAngle)
        {
            double rotationAngleCos = Math.Cos(rotationAngle);
            double rotationAngleSin = Math.Sin(rotationAngle);
            double rotationCosAbs = Math.Abs(rotationAngleCos);
            double rotationSinAbs = Math.Abs(rotationAngleSin);

            double width = (rotationCosAbs * objectToRotate.width) + (rotationSinAbs * objectToRotate.height);
            double height = (rotationSinAbs * objectToRotate.width) + (rotationCosAbs * objectToRotate.height);

            var rotatedFigure = new Size(width, height);

            return rotatedFigure;
        }
    }
}