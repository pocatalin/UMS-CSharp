//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PIProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendance
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Nullable<byte> W1 { get; set; }
        public Nullable<byte> W2 { get; set; }
        public Nullable<byte> W3 { get; set; }
        public Nullable<byte> W4 { get; set; }
        public Nullable<byte> W5 { get; set; }
        public Nullable<byte> W6 { get; set; }
        public Nullable<byte> W7 { get; set; }
        public Nullable<byte> W8 { get; set; }
        public Nullable<byte> W9 { get; set; }
        public Nullable<byte> W10 { get; set; }
        public Nullable<byte> W11 { get; set; }
        public Nullable<byte> W12 { get; set; }
        public Nullable<byte> W13 { get; set; }
        public Nullable<byte> W14 { get; set; }
        public Nullable<int> TotalAttendance { get; set; }
    
        public virtual Cours Cours { get; set; }
        public virtual Student Student { get; set; }
        public virtual StudentCours StudentCours { get; set; }
    }
}