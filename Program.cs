internal class CoordinateConversion
{
    private interface ICoordinateConversionStrategy
    {
        string Convert(double[] parameters, int precision);
    }

    private class CartesianToSphericalStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var x = parameters[0];
            var y = parameters[1];
            var z = parameters[2];

            var r = Math.Sqrt(x * x + y * y + z * z);
            var theta = Math.Acos(z / r);
            var phi = Math.Atan2(y, x);

            return $"Сферические (r: {Math.Round(r, precision)}, theta: {Math.Round(theta, precision)}, phi: {Math.Round(phi, precision)})";
        }
    }

    private class CartesianToPolarStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var x = parameters[0];
            var y = parameters[1];

            var r = Math.Sqrt(x * x + y * y);
            var theta = Math.Atan2(y, x);

            return $"Полярные (r: {Math.Round(r, precision)}, theta: {Math.Round(theta, precision)})";
        }
    }

    private class CartesianToCylindricalStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var x = parameters[0];
            var y = parameters[1];
            var z = parameters[2];

            var r = Math.Sqrt(x * x + y * y);
            var phi = Math.Atan2(y, x);

            return $"Цилиндрические (r: {Math.Round(r, precision)}, phi: {Math.Round(phi, precision)}, z: {Math.Round(z, precision)})";
        }
    }

    private class SphericalToCartesianStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var r = parameters[0];
            var theta = parameters[1];
            var phi = parameters[2];

            var x = r * Math.Sin(theta) * Math.Cos(phi);
            var y = r * Math.Sin(theta) * Math.Sin(phi);
            var z = r * Math.Cos(theta);

            return $"Декартовы (x: {Math.Round(x, precision)}, y: {Math.Round(y, precision)}, z: {Math.Round(z, precision)})";
        }
    }

    private class SphericalToPolarStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var r = parameters[0];
            var theta = parameters[1];
            var z = r * Math.Cos(theta);
            var rCyl = r * Math.Sin(theta);

            return $"Полярные (r: {Math.Round(rCyl, precision)}, theta: {Math.Round(parameters[2], precision)})";
        }
    }

    private class SphericalToCylindricalStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var r = parameters[0];
            var theta = parameters[1];
            var phi = parameters[2];

            var z = r * Math.Cos(theta);
            var rCyl = r * Math.Sin(theta);

            return $"Цилиндрические (r: {Math.Round(rCyl, precision)}, phi: {Math.Round(phi, precision)}, z: {Math.Round(z, precision)})";
        }
    }

    private class PolarToCartesianStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var r = parameters[0];
            var theta = parameters[1];

            var x = r * Math.Cos(theta);
            var y = r * Math.Sin(theta);

            return $"Декартовы (x: {Math.Round(x, precision)}, y: {Math.Round(y, precision)})";
        }
    }

    private class PolarToSphericalStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var r = parameters[0];
            var theta = parameters[1];

            return $"Сферические (r: {Math.Round(r, precision)}, theta: {Math.Round(theta, precision)}, phi: 0)"; // phi = 0 для полярных координат
        }
    }

    private class PolarToCylindricalStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var r = parameters[0];
            var theta = parameters[1];

            return $"Цилиндрические (r: {Math.Round(r, precision)}, phi: {Math.Round(theta, precision)}, z: 0)";
        }
    }

    private class CylindricalToCartesianStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var r = parameters[0];
            var phi = parameters[1];
            var z = parameters[2];

            var x = r * Math.Cos(phi);
            var y = r * Math.Sin(phi);

            return $"Декартовы (x: {Math.Round(x, precision)}, y: {Math.Round(y, precision)}, z: {Math.Round(z, precision)})";
        }
    }

    private class CylindricalToSphericalStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var rCyl = parameters[0];
            var phi = parameters[1];
            var z = parameters[2];

            var r = Math.Sqrt(rCyl * rCyl + z * z);
            var theta = Math.Atan2(rCyl, z);

            return $"Сферические (r: {Math.Round(r, precision)}, theta: {Math.Round(theta, precision)}, phi: {Math.Round(phi, precision)})";
        }
    }

    private class CylindricalToPolarStrategy : ICoordinateConversionStrategy
    {
        public string Convert(double[] parameters, int precision)
        {
            var r = parameters[0];
            var phi = parameters[1];

            return $"Полярные (r: {Math.Round(r, precision)}, theta: {Math.Round(phi, precision)})";
        }
    }

    private class CoordinateConverter
    {
        private ICoordinateConversionStrategy _strategy;

        public void SetStrategy(ICoordinateConversionStrategy strategy)
        {
            _strategy = strategy;
        }

        public string ConvertCoordinates(double[] parameters, int precision)
        {
            if (_strategy == null)
            {
                throw new InvalidOperationException("Не установлена стратегия преобразования.");
            }

            return _strategy.Convert(parameters, precision);
        }
    }

    private class Program
    {
        private static void Main()
        {
            Console.Write("Введите тип начальной системы координат: (Декартовы - 1, Сферические - 2, Полярные - 3, Цилиндрические - 4): ");
            var initialType = Console.ReadLine();

            Console.Write("Введите координаты через запятую: ");
            var parameters = Array.ConvertAll(Console.ReadLine().Split(','), double.Parse);

            Console.Write("Введите количество знаков после запятой для точности: ");
            var precision = int.Parse(Console.ReadLine());

            var converter = new CoordinateConverter();
            
            if (initialType == "1")
            {
                Console.Write("Выберите целевую систему координат: (Сферические - 1, Полярные - 2, Цилиндрические - 3): ");
                var targetType = Console.ReadLine();

                if (targetType == "1")
                    converter.SetStrategy(new CartesianToSphericalStrategy());
                else if (targetType == "2")
                    converter.SetStrategy(new CartesianToPolarStrategy());
                else if (targetType == "3")
                    converter.SetStrategy(new CartesianToCylindricalStrategy());
                else
                {
                    Console.WriteLine("Неверный тип целевой системы координат.");
                    return;
                }
            }
            else if (initialType == "2")
            {
                Console.Write("Выберите целевую систему координат: (Декартовы - 1, Полярные - 2, Цилиндрические - 3): ");
                var targetType = Console.ReadLine();

                if (targetType == "1")
                    converter.SetStrategy(new SphericalToCartesianStrategy());
                else if (targetType == "2")
                    converter.SetStrategy(new SphericalToPolarStrategy());
                else if (targetType == "3")
                    converter.SetStrategy(new SphericalToCylindricalStrategy());
                else
                {
                    Console.WriteLine("Неверный тип целевой системы координат.");
                    return;
                }
            }
            else if (initialType == "3")
            {
                Console.Write("Выберите целевую систему координат: (Декартовы - 1, Сферические - 2, Цилиндрические - 3): ");
                var targetType = Console.ReadLine();

                if (targetType == "1")
                    converter.SetStrategy(new PolarToCartesianStrategy());
                else if (targetType == "2")
                    converter.SetStrategy(new PolarToSphericalStrategy());
                else if (targetType == "3")
                    converter.SetStrategy(new PolarToCylindricalStrategy());
                else
                {
                    Console.WriteLine("Неверный тип целевой системы координат.");
                    return;
                }
            }
            else if (initialType == "4")
            {
                Console.Write("Выберите целевую систему координат: (Декартовы - 1, Сферические - 2, Полярные - 3): ");
                var targetType = Console.ReadLine();

                if (targetType == "1")
                    converter.SetStrategy(new CylindricalToCartesianStrategy());
                else if (targetType == "2")
                    converter.SetStrategy(new CylindricalToSphericalStrategy());
                else if (targetType == "3")
                    converter.SetStrategy(new CylindricalToPolarStrategy());
                else
                {
                    Console.WriteLine("Неверный тип целевой системы координат.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Выбрана неверная система координат.");
                return;
            }

            var result = converter.ConvertCoordinates(parameters, precision);
            Console.WriteLine("Результат перевода: " + result);
        }
    }
}