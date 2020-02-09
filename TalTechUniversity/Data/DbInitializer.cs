using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalTechUniversity.Models;

namespace TalTechUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students
            if (context.Students.Any())
            {
                return;   // DB seeded
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Helen",LastName="Allas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Merili",LastName="Kala",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{FirstMidName="Artur",LastName="Annus",EnrollmentDate=DateTime.Parse("2018-07-01")},
                new Student{FirstMidName="Georg",LastName="Jaup",EnrollmentDate=DateTime.Parse("2017-06-01")},
                new Student{FirstMidName="Liis",LastName="Lill",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Peep",LastName="Pedak",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstMidName="Laura",LastName="Laas",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{FirstMidName="Mari",LastName="Maasikas",EnrollmentDate=DateTime.Parse("2016-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Kaie",     LastName = "Klettenberg",
                    HireDate = DateTime.Parse("2003-03-11") },
                new Instructor { FirstMidName = "Anne",    LastName = "Kuus",
                    HireDate = DateTime.Parse("2005-07-06") },
                new Instructor { FirstMidName = "Katrin",   LastName = "Kroosmann",
                    HireDate = DateTime.Parse("1999-06-01") },
                new Instructor { FirstMidName = "Marge", LastName = "Oopkaup",
                    HireDate = DateTime.Parse("2004-03-16") },
                new Instructor { FirstMidName = "Tatjana",   LastName = "Troost",
                    HireDate = DateTime.Parse("2008-09-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
           {
                new Department { Name = "Languages",     Budget = 400000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Klettenberg").ID },
                new Department { Name = "Economical sciences", Budget = 200000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Troost").ID },
                new Department { Name = "Sports", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kroosmann").ID },
                new Department { Name = "Sciences",   Budget = 500000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kuus").ID }
           };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Chemistry",Credits=3, DepartmentID = departments.Single( s => s.Name == "Sciences").DepartmentID},
                new Course{CourseID=4022,Title="Economics",Credits=3, DepartmentID = departments.Single( s => s.Name == "Economical sciences").DepartmentID},
                new Course{CourseID=4041,Title="Maths",Credits=3, DepartmentID = departments.Single( s => s.Name == "Sciences").DepartmentID},
                new Course{CourseID=1045,Title="Sport",Credits=4, DepartmentID = departments.Single( s => s.Name == "Sports").DepartmentID},
                new Course{CourseID=3141,Title="Russian",Credits=4, DepartmentID = departments.Single( s => s.Name == "Languages").DepartmentID},
                new Course{CourseID=2021,Title="French",Credits=3, DepartmentID = departments.Single( s => s.Name == "Languages").DepartmentID},
                new Course{CourseID=2042,Title="Literature",Credits=4, DepartmentID = departments.Single( s => s.Name == "Languages").DepartmentID}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kuus").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kroosmann").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Troost").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
           {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "French" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Klettenberg").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Russian" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Klettenberg").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Economics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Troost").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Maths" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kuus").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Sports" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kroosmann").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Oopkaup").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Klettenberg").ID
                    },                
           };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();


            var enrollments = new Enrollment[]
           {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Allas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.F
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Allas").ID,
                    CourseID = courses.Single(c => c.Title == "French" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Allas").ID,
                    CourseID = courses.Single(c => c.Title == "Sports" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Kala").ID,
                    CourseID = courses.Single(c => c.Title == "Sports" ).CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Kala").ID,
                    CourseID = courses.Single(c => c.Title == "French" ).CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kala").ID,
                    CourseID = courses.Single(c => c.Title == "Economics" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Annus").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Annus").ID,
                    CourseID = courses.Single(c => c.Title == "Economics").CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Jaup").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Jaup").ID,
                    CourseID = courses.Single(c => c.Title == "Russian").CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Pedak").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.A
                    }
           };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }    
}
