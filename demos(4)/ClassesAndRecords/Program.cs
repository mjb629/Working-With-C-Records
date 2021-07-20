using System;
using System.Text;

namespace ClassesAndRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseRecord classroomCourse = new TimedCourseRecord(
                "Working with C# Records",
                "Roland Guijt",
                Duration: 90
                );

            CourseRecord videoCourse = new TimedCourseRecord(
                "Working with C# Records",
                "John Doe",
                Duration: 90
                );

            Console.WriteLine(classroomCourse == videoCourse);
        }
    }

    public record CourseRecord(string Name, string Author)
    {
        
    }
    public record TimedCourseRecord(string Name, string Author, int Duration) :
        CourseRecord(Name, Author)
    {
        public string Venue { get; init; }

        public virtual bool Equals(TimedCourseRecord other)
        {
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        protected override bool PrintMembers(StringBuilder builder)
        {
            if (base.PrintMembers(builder))
                builder.Append(", ");
            builder.Append("Duration");
            builder.Append(" = ");
            builder.Append(Duration.ToString());
            builder.Append(", ");
            builder.Append("Venue");
            builder.Append(" = ");
            builder.Append(Venue);
            builder.Append(", ");
            builder.Append("Title");
            builder.Append(" = ");
            builder.Append($"{Name} - {Author}");
            return true;
        }
    }

    public record AnotherTimedCourseRecord(string Name, string Author, int Duration):
        TimedCourseRecord(Name, Author, Duration);
}
