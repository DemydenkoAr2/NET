namespace Homework_8;

    class Program
    {
        private static Semaphore barberSemaphore = new Semaphore(0, 1);
        private static Semaphore customerSemaphore = new Semaphore(0, 3);
        private static int freeSeats = 3;
        private static readonly object seatLock = new object();
        
        public static void Main()
        {
            Task.Run(() => Barber());
            
            Task.Run(() => 
            {
                Random rand = new Random();
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(rand.Next(500, 2000));
                    Customer(i);
                }
            });

            Console.ReadLine();
        }

        private static void Barber()
        {
            while (true)
            {
                Console.WriteLine("Barber is sleeping...");
                barberSemaphore.WaitOne();
            
                lock (seatLock)
                {
                    freeSeats++;
                    customerSemaphore.Release();
                }
            
                Console.WriteLine("Barber is working");
                Thread.Sleep(2000);
                Console.WriteLine("Barber has done");
            }
        }

        private static void Customer(int customerId)
        {
            lock (seatLock)
            {
                if (freeSeats > 0)
                {
                    freeSeats--;
                    Console.WriteLine($"Customer {customerId} is waiting. There are free seats: {freeSeats}");
                
                    barberSemaphore.Release();
                    
                    Monitor.Exit(seatLock);
                    customerSemaphore.WaitOne();
                    Monitor.Enter(seatLock);
                
                    Console.WriteLine($"Customer {customerId} is getting haircut");
                }
                else
                {
                    Console.WriteLine($"Customer {customerId} left - there aren't free seats");
                    return;
                }
            }
        }
    }
