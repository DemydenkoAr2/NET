namespace Task_1_Drama;

class Program
{
    static void Main(string[] args)
    {
        using (Play drama = new Play("Romeo and Juliet", "William Shakespeare", "Tragedy", 1597))
        {
            drama.DisplayInfo();
            drama.ChangeTitle("Hamlet");
            drama.ChangeYear(1598);

            using (Play comedy = new ("The Naked Gun", "Jerry Zucker", "Comedy", 1988))
            {
                comedy.DisplayInfo();
            }
        }
    }
}