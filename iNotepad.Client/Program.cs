namespace iNotepad.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            new AutocompleteProcessor(args).Start();
        }
    }
}
