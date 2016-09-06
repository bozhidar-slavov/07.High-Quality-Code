namespace CohesionAndCoupling
{
    using AbstractionAndEncapsulation; // added for using Validator static class to avoid rewriting class with the same functionalities

    public class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                Validator.ValidateFigure(value, "Width");

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
                Validator.ValidateFigure(value, "Height");

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                Validator.ValidateFigure(value, "Depth");

                this.depth = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = GeometryUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
