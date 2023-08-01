using UG22_MultipleChoiceTestApp;

internal class Program
{
    private static void Main(string[] args)
    {
        ITestPaper testPaper1 = CreateTestPapers();
        Console.WriteLine(testPaper1.SubjectName + ", " + testPaper1.TestPaperName + " created!");

        ITestPaper testPaper2 = CreateTestPapers();
        Console.WriteLine(testPaper2.SubjectName + ", " + testPaper2.TestPaperName + " created!");

        IStudent student = CreateStudent();
        student.TestPapers.Add(testPaper1);
        student.TestPapers.Add(testPaper2);

        TestAttempt(testPaper1);
        TestAttempt(testPaper2);

        Console.WriteLine($"\nPoints at {testPaper1.TestPaperName} = {CalculateMarks(testPaper1)}");
        Console.WriteLine($"Points at {testPaper2.TestPaperName} = {CalculateMarks(testPaper2)}");
    }
    static ITestPaper CreateTestPapers()
    {
        ITestPaper testPaper = new TestPaper();

        Console.Write("Add the name of the subject: ");
        testPaper.SubjectName = Console.ReadLine();

        Console.Write("Add the name of the test paper: ");
        testPaper.TestPaperName = Console.ReadLine();

        Console.WriteLine("\nThanks! Now create the questions with options!");
        Console.WriteLine();

        testPaper.Questions = new List<IQuestion>();   
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Enter details for question {i + 1}.");
            testPaper.Questions.Add(CreateQuestions());
        }
        return testPaper;
    }
    static IQuestion CreateQuestions()
    {
        IQuestion question = new Question();
        Console.Write("Question: ");
        string questionText = Console.ReadLine();
        question.QuestionText = questionText;

        question.Options = new List<IOption>();
        for (char c = 'A'; c <= 'D'; c++)
        {
            Console.Write($"Answer for {c} option: ");
            string answer = Console.ReadLine();
            IOption option = new Option() { OptionLetter = c, OptionText = answer };
            question.Options.Add(option);
        }
        string answerLetter = "  ";
        
        while (answerLetter.Length > 1 || answerLetter == null)
        {
            Console.Write("Add the letter of the correct answer: ");
            answerLetter = Console.ReadLine();
        }
        question.CorrectAnswerLetter = Convert.ToChar(answerLetter.ToUpper());
        
        return question;
    }
    static IStudent CreateStudent()
    {
        IStudent student = new Student();
        Console.Write("Add your ID: ");
        student.RollNo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Add your name: ");
        student.StudentName = Console.ReadLine();

        student.TestPapers = new List<ITestPaper>();
        return student;
    }
    static void TestAttempt(ITestPaper testpaper)
    {
        Console.WriteLine("\n**** Test started! ****\n");
        foreach (IQuestion question in testpaper.Questions)
        {
            Console.WriteLine("\nThe question: " + question.QuestionText);
            foreach (IOption option in question.Options)
            {
                Console.WriteLine(option.OptionLetter + " " + option.OptionText);
            }
            Console.Write("Your answer: ");
            question.OptionSelectedByStudent = Console.ReadLine().ToUpper()[0];
        }

    }
    static int CalculateMarks(ITestPaper finalTestResult)
    {
        int score = 0;
        foreach (IQuestion question in finalTestResult.Questions)
        {
            if (question.CorrectAnswerLetter.ToString() == question.OptionSelectedByStudent.ToString())
            {
                score++;
            }
        }
        return score;
    }
}