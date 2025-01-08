using Subjects;
using Users;

namespace Programs;

public class Program : AbsProgram
{
    public Program(
            uint id,
            string name,
            AbsUser author,
            Dictionary<Semester, List<AbsSubject>> subjects) : base(
                                                                    id,
                                                                    name,
                                                                    author,
                                                                    subjects) { }
}
