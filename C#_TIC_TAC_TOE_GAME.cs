using System;
class HelloWorld 
{
    static void Main() 
    {
        char[] x=new char[9];
        for(int i=0;i<9;i++)
        {
            x[i]=' ';
        }
        print(x);
        Console.WriteLine("\n\nUSE NumPad(or numbers) for opearation\nThe game starts with 'X' followed by 'O'");
        bool win=false,move;
        int chance=1;
        int ch;
        while(win==false)
        {
            move=false;
            ch=Convert.ToInt32(Console.Read())-48;
            int key=9;
            switch(ch)
            {
                case 7 :    key=0;
                            break;
                case 8 :    key=1;
                            break;
                case 9 :    key=2;
                            break;
                case 4 :    key=3;
                            break;
                case 5 :    key=4;
                            break;
                case 6 :    key=5;
                            break;
                case 1 :    key=6;
                            break;
                case 2 :    key=7;
                            break;
                case 3 :    key=8;
                            break;
               default :    key=9;
                            break;
            }
            if(key==9||x[key]!=' ')
            {
                Console.WriteLine("\nInvalid move");
            }
            else if(chance==0)
            {
                chance=1;
                x[key]='O';
                move=true;
            }
            else
            {
                chance=0;
                x[key]='X';
                move=true;
            }    
            if(move==true)
            {
                print(x);
                if(((x[0]==x[1]&&x[1]==x[2])||
                   (x[0]==x[3]&&x[3]==x[6]))&&
                   x[0]!=' ')
                {
                    win=true;
                    Console.Write("\n\n player '"+x[0]+"' wins\n\nPress any key to exit");
                    Console.Read();
                    break;
                }
                else if(((x[8]==x[5]&&x[5]==x[2])||
                        (x[8]==x[7]&&x[7]==x[6]))&&
                        x[8]!=' ')
                {
                    win=true;
                    Console.Write("\n\n player '"+x[8]+"' wins\n\nPress any key to exit");
                    Console.Read();
                    break;
                }
                else if(((x[0]==x[4]&&x[4]==x[8])||
                        (x[2]==x[4]&&x[4]==x[6])||
                        (x[1]==x[4]&&x[4]==x[7])||
                        (x[3]==x[4]&&x[4]==x[5]))&&
                        x[4]!=' ')
                {
                    win=true;
                    Console.Write("\n\n player '"+x[4]+"' wins\n\nPress any key to exit");
                    Console.Read();
                    break;
                }
                for(int i=0;i<9;i++)
                {
                    if(x[i]==' ')
                        break;
                    if(x[i]!=' '&&i==8)
                    {
                        Console.WriteLine("\n\nTIE!!! Press any key to exit");
                        Console.Read();
                        win=true;
                    }
                }
                move=false;
            }    
        }
    }
    public static void print(char[] x)
    {
        Console.Clear();
        for(int i=0;i<9;i++)
        {
            Console.Write(" "+x[i]+" ");
            if((i+1)%3!=0)
                Console.Write("|");
            if((i+1)%3==0)
            {
                Console.WriteLine();
                if(i+1!=9)
                Console.WriteLine("---+---+---");
            }
        }
    }
}

