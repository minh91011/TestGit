namespace DemoAPIChuviDientichHinhTron.Data
{
    public class Circle
    {
        public double radius {
            get { return radius; }
            set { 
                if (radius <= 0)
                {
                    Console.WriteLine("Ban kinh phai lon hon 0");
                }
                else
                {
                    radius = value;
                }
            }
        }
        public double perimeter { get; set; }
        public double area { get; set; }
    }
}
