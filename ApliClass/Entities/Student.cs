﻿namespace Entities;

public class Student
{
    public int Id { get; set; }
    public int Student1 { get; set; }
    public int Class { get; set; }

    public virtual Class ClassNavigation { get; set; }
    public virtual User Student1Navigation { get; set; }
}