using System;

namespace UAS_119
{
    class Node
    {
        public int NIM;
        public string Nama;
        public string JenisKelamin;
        public string Kelas;
        public string Asal;

        public Node next;
        public Node prev;
    }

    class Aplikasi
    {
        Node START;

        public void addNode()
        {
            int nim;
            string nm;
            string jk;
            string kls;
            string asl;

            Console.WriteLine("\nMasukan NIM : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukan Nama : ");
            nm = Console.ReadLine();
            Console.WriteLine("\nMasukan jenis kelamin : ");
            jk = Console.ReadLine();
            Console.WriteLine("\nMasukan nama kelas : ");
            kls = Console.ReadLine();
            Console.WriteLine("\nMasukan kota asal : ");
            asl = Console.ReadLine();
            Node newNode = new Node();
            newNode.NIM = nim;
            newNode.Nama = nm;
            newNode.JenisKelamin = jk;
            newNode.Asal = asl;

            if (START == null || nim <= START.NIM)
            {
                if ((START != null) && (nim == START.NIM))
                {
                    Console.WriteLine("\nData doble tidak diperbolehkan");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.next = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for(current = previous = START;
                current != null && nim >= current.NIM;
                previous = current, current = current.next)
            {
                if (nim == current.NIM)
                {
                    Console.WriteLine("\nData dobel tidak diperbolehkan");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if(current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool Search(string noUrut, ref Node previous, ref Node current)
        {
            previous = current = START;
            while(current != null &&
                noUrut != current.Asal)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }
        public bool dellNode(string noUrut)
        {
            Node previous, current;
            previous = current = null;
            if (Search(noUrut, ref previous, ref current) == false)
                return false;
            if(current.next == null)
            {
                previous.next = null;
                return true;
            }
            if(current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool DataKosong()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (DataKosong())
                Console.WriteLine("\ndata kosong");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "Roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NIM +" "+ currentNode.Nama +" "+ currentNode.JenisKelamin +" "
                        + currentNode.Kelas +" "+ currentNode.Asal + "\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Aplikasi obj = new Aplikasi();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Input no mahasiswa");
                    Console.WriteLine("2. hapus data");
                    Console.WriteLine("3. tampilkan seluruh data");
                    Console.WriteLine("4. cari asal kota");
                    Console.WriteLine("5. Exit\n");
                    Console.Write("Enter your choice (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.DataKosong())
                                {
                                    Console.WriteLine("\nData kosong");
                                    break;
                                }
                                Console.Write("\nPilih nim mahasiswa yang ingin di hapus: ");
                                string rollNo = Console.ReadLine();
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Nim tidak ditemukan");
                                else
                                    Console.WriteLine("mahasiswa dengan nim" + " " + rollNo + " " + "dihapus \n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;

                        case '4':
                            {
                                if (obj.DataKosong() == true)
                                {
                                    Console.WriteLine("\nData kososng");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\npilih kota yang di cari: ");
                                string num = Console.ReadLine();
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nkota tidak ditemukan");
                                else
                                {

                                    Console.WriteLine("\nnim mahasiswa " + curr.NIM);
                                    Console.WriteLine("\nNama: " + curr.Nama);
                                    Console.WriteLine("\nJenis kelamin: " + curr.JenisKelamin);
                                    Console.WriteLine("\nkelas: " + curr.Kelas);
                                    Console.WriteLine("\nKota asal: " + curr.Asal);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan Salah");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
        }



        /* 2. Algoritma yang saya gunakan adalah Double link list. memilih algoritma 
         * tersebut karena Doubly Linked List merupakan suatu linked list yang 
         * memiliki dua variabel pointer yaitu pointer yang menunjuk ke node 
         * selanjutnya dan pointer yang menunjuk ke node sebelumnya. */
           
        /* 3. Algoritma Queue merupakan struktur data dimana satu data dapat 
         * ditambakan diakhir disebut enqueue dan data dihapus dari yang paling 
         * terkahir disebut dequeue*/

        /*4. Perbedaan array dan linklist adalah 
        Array adalah tipe data yang digunakan untuk menyimpan sekumpulan data dengan tipe yang sama dalam satu lokasi memori yang sama
        sedangkan linklist memerlukan akses data yang lebih lambat namun hanya membutuhkan sedikit memori*/

        /* 5. postorder traversal
         * parent : 10, 15, 30, 25
         * children : 5, 32, 20, 28*/



    }
}
