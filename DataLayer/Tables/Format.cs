﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Tables
{
    /// <summary>
    /// شكل الدواء 
    /// </summary>
    public class Format
    {
        public delegate void UpdateForm();
        public event UpdateForm onUpdateForm;
        [Key]
        [DisplayName("رقم المعرف")]
        public int Id { get; set; }
        [DisplayName("الشكل")]
        public string Name { get; set; }
    }
}
