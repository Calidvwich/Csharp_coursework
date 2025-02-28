// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

// 定义一个形状接口
public interface IShape
{
    double Area(); // 计算面积
    bool IsValid(); // 判断形状是否合法
}

// 创建一个抽象类，包含共有属性和方法
public abstract class Shape : IShape
{
    public abstract double Area();
    public abstract bool IsValid();
}

// 长方形类
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public override bool IsValid()
    {
        return Width > 0 && Height > 0; // 长方形的边长必须大于0
    }
}

// 正方形类
public class Square : Rectangle
{
    public Square(double side) : base(side, side) { }

    public override bool IsValid()
    {
        return Width > 0; // 正方形的边长必须大于0
    }
}

// 圆形类
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override bool IsValid()
    {
        return Radius > 0; // 圆的半径必须大于0
    }
}

// 梯形类
public class Trapezoid : Shape
{
    public double Base1 { get; set; }
    public double Base2 { get; set; }
    public double Height { get; set; }

    public Trapezoid(double base1, double base2, double height)
    {
        Base1 = base1;
        Base2 = base2;
        Height = height;
    }

    public override double Area()
    {
        return 0.5 * (Base1 + Base2) * Height;
    }

    public override bool IsValid()
    {
        return Base1 > 0 && Base2 > 0 && Height > 0; // 梯形的两底和高必须大于0
    }
}

// 平行四边形类
public class Parallelogram : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Parallelogram(double baseLength, double height)
    {
        Base = baseLength;
        Height = height;
    }

    public override double Area()
    {
        return Base * Height;
    }

    public override bool IsValid()
    {
        return Base > 0 && Height > 0; // 平行四边形的底和高必须大于0
    }
}

public class Program
{
    public static void Main()
    {
        Random rand = new Random();
        List<IShape> shapes = new List<IShape>();

        // 随机生成10个形状
        for (int i = 0; i < 10; i++)
        {
            int shapeType = rand.Next(5); // 生成一个0-4之间的随机数，决定形状类型

            IShape shape = shapeType switch
            {
                0 => new Rectangle(rand.Next(1, 10), rand.Next(1, 10)),
                1 => new Square(rand.Next(1, 10)),
                2 => new Circle(rand.Next(1, 10)),
                3 => new Trapezoid(rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10)),
                4 => new Parallelogram(rand.Next(1, 10), rand.Next(1, 10)),
                _ => throw new InvalidOperationException()
            };

            // 只将合法的形状添加到列表
            if (shape.IsValid())
            {
                shapes.Add(shape);
            }
        }

        // 计算所有合法形状的面积之和
        double totalArea = 0;
        foreach (var shape in shapes)
        {
            totalArea += shape.Area();
        }

        // 输出所有形状的面积之和
        Console.WriteLine($"所有合法形状的面积之和: {totalArea}");
    }
}
