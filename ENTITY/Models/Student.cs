using System;
using System.Collections.Generic;

namespace ENTITY.Models
{
    /// <summary>
    /// ѧ������
    /// </summary>
    public partial class Student
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int age { get; set; }
    }
}
