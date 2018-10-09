using System;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var ordered = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            if (ordered[threshold - 1] <= averageGrade)
                return 'A';
            else if (ordered[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (ordered[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (ordered[(threshold * 4) - 1] <= averageGrade)
                return 'D';

            return 'F';
        }
    }
}
