for (int i = 0; i < 10; i++)
{
    Main sem = new Main(i);
}

class Main
{
    static Semaphore sem = new Semaphore(3, 3);
    Thread thread;

    private int count = 1;
    public Main(int i)
    {
        thread = new Thread(Generator);
        thread.Name = $"Поток {i}";
        thread.Start();
    }

    Random rnd = new Random();
    public void Generator()
    {
        while (count > 0)
        {
            sem.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " " + rnd.Next(0, 100));
            }
            sem.Release();
            count--;
        }
    }
}