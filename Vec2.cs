using System;
using System.Collections.Generic;
using System.Text;

namespace GunSlinger
{
    public class Vec2
    {
        // Properties
        public double X { get; set; }
        public double Y { get; set; }

        // Constructors
        public Vec2() { this.X = 0.0; this.Y = 0.0; }
        public Vec2(double X, double Y) { this.X = X; this.Y = Y; }
        public Vec2(Vec2 v) { this.X = v.X; this.Y = v.Y; }

        // Operators
        public static Vec2 operator + (Vec2 v) => v;
        public static Vec2 operator + (Vec2 v1, Vec2 v2) => new Vec2(v1.X + v2.X, v1.Y + v2.Y);
        public static Vec2 operator - (Vec2 v) => new Vec2(-v.X, -v.Y);
        public static Vec2 operator - (Vec2 v1, Vec2 v2) => new Vec2(v1.X - v2.X, v1.Y - v2.Y);
        public static Vec2 operator * (Vec2 v, double s) => new Vec2(v.X * s, v.Y * s);
        public static Vec2 operator * (double s, Vec2 v) => new Vec2(s * v.X, s * v.Y);
        public static Vec2 operator / (Vec2 v, double s) => new Vec2(v.X / s, v.Y / s);

        // Methods
        public Vec2 Abs() { return new Vec2(Math.Abs(this.X), Math.Abs(this.Y)); }
        public double AngleFromUnitVector(Vec2 u) { return Math.Atan2(u.Y, u.X); }
        public Vec2 Component(Vec2 v) { return (this.Dot(v) / v.Dot(v)) * v; }
        public Vec2 Dot(double s) { return new Vec2(this.X * s, this.Y * s); }
        public double Dot(Vec2 v) { return this.X * v.X + this.Y * v.Y; }
        public double Length() { return Math.Sqrt(this.LengthSquared()); }
        public double LengthSquared() { return this.Dot(this); }
        public Vec2 Normalised() { return this != new Vec2() ? new Vec2(this / this.Length()) : new Vec2(); }
        public Vec2 PerpCCW() { return new Vec2(-this.Y, this.X); }
        public Vec2 PerpCW() { return new Vec2(this.Y, -this.X); }
        public Vec2 PerpDotCCW(double s) { return this.PerpCCW() * s; }
        public Vec2 PerpDotCW(double s) { return this.PerpCW() * s; }
        public double PerpDotCCW(Vec2 v) { return this.PerpCCW().Dot(v); }
        public double PerpDotCW(Vec2 v) { return this.PerpCW().Dot(v); }
        public Vec2 Project(Vec2 v) { return (v.Dot(this) / this.Dot(this)) * this; }
        public Vec2 RotateCCW(Vec2 v) { return new Vec2(v.Dot(this), v.PerpDotCCW(this)); }
        public Vec2 RotateCW(Vec2 v) { return new Vec2(v.Dot(this), v.PerpDotCW(this)); }
        public override string ToString() { return ("[" + this.X + ", " + this.Y + "]"); }

        public Vec2 UnitVectorFromAngle(double a) { return new Vec2(Math.Cos(a), Math.Sin(a)); }
        public void MakeZero() { this.X = 0.0; this.Y = 0.0; }
    }
}
