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
    
    public partial class StudentCours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentCours()
        {
            this.Grades = new HashSet<Grade>();
        }
    
        public int StudentID { get; set; }
        public int CourseID { get; set; }
    
        public virtual Attendance Attendance { get; set; }
        public virtual Cours Cours { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual Student Student { get; set; }
    }
}