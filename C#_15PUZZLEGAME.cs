using System;
namespace JustForFun
{
using System;
class Program
{
    static void Main() 
    {
        int[,] a=new int[4,4];
        int[] tempa=new int[16];
        int x;
        Random r=new Random();
        for(int i=0;i<15;i++)
        {
            do
            {
                x=r.Next(1,16);
            }while(Array.IndexOf(tempa,x)!=-1);
            tempa[i]=x;
        }
        int pos=0;
        for(int i=0;i<4;i++)
        {
            for(int j=0;j<4;j++)
            {
                if(i==3&&j==3){}
                else
                    a[i,j]=tempa[pos];
                pos++;
            }
        }
        int space_pos=r.Next(0,16);
        int space_x=(space_pos)/4;
        int space_y=(space_pos)%4;
        a[3,3]=a[space_x,space_y];
        a[space_x,space_y]=0;
        int movecnt=0;
        for(int i=0;i<4;i++)
        {
            for(int j=0;j<4;j++)
            {
                if(a[i,j]==0)
                    Console.Write("     ");
                else if(a[i,j]<10)
                    Console.Write(a[i,j]+"    ");
                else
                    Console.Write(a[i,j]+"   ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nGOOD LUCK");
        bool win=false,move;
        ConsoleKey ch;
        while(win==false)
        {
            move=false;
            ch=Console.ReadKey().Key;
            switch(ch)
            {
                case ConsoleKey.LeftArrow : if(space_y==3)
                                            {
                                                Console.WriteLine("\nInvalid Move");
                                            }
                                            else
                                            {
                                                a[space_x,space_y]=a[space_x,space_y+1];
                                                a[space_x,space_y+1]=0;
                                                space_y+=1;
                                                move=true;
                                            }    
                                            break;
                case ConsoleKey.RightArrow :if(space_y==0)
                                            {
                                                Console.WriteLine("\nInvalid Move");
                                            }
                                            else
                                            {
                                                a[space_x,space_y]=a[space_x,space_y-1];
                                                a[space_x,space_y-1]=0;
                                                space_y-=1;
                                                move=true;
                                            }    
                                            break;
                case ConsoleKey.DownArrow : if(space_x==0)
                                            {
                                                Console.WriteLine("\nInvalid Move");
                                            }
                                            else
                                            {
                                                a[space_x,space_y]=a[space_x-1,space_y];
                                                a[space_x-1,space_y]=0;
                                                space_x-=1;
                                                move=true;
                                            }    
                                            break;
                case ConsoleKey.UpArrow   : if(space_x==3)
                                            {
                                                Console.WriteLine("\nInvalid Move");
                                            }
                                            else
                                            {
                                                a[space_x,space_y]=a[space_x+1,space_y];
                                                a[space_x+1,space_y]=0;
                                                space_x+=1;
                                                move=true;
                                            }    
                                            break;
              /*  case ConsoleKey.K         : for(int i=0;i<=3;i++)
                                            {
                                                for(int j=0;j<=3;j++)
                                                {
                                                    if(i==3&&j==3)
                                                    {
                                                        a[i,j]=0;
                                                    }
                                                    else
                                                    {
                                                        a[i,j]=(i*4)+j+1;
                                                    }
                                                }
                                            }
                                            move=true;
                                            break;  */                      
                default                   : Console.WriteLine(" : Invalid key");   
                                            break;

            }
            if(move==true)
            {
                movecnt++;
                Console.Clear();
                for(int i=0;i<4;i++)
                {
                    for(int j=0;j<4;j++)
                    {
                        if(a[i,j]==0)
                            Console.Write("     ");
                        else if(a[i,j]<10)
                            Console.Write(a[i,j]+"    ");
                        else
                            Console.Write(a[i,j]+"   ");
                    }
                    Console.WriteLine();
                }
                pos=1;
                for(int i=0;i<4;i++)
                {
                    bool flag=false;
                    for(int j=0;j<4;j++)
                    {
                        if(i==3&&j==3&&a[i,j]==0)
                        {
                            Console.WriteLine("!!!  WIN  !!!\nYou finished in "+movecnt+" moves...");
                            Console.WriteLine("PRESS ANY KEY TO EXIT");
                            Console.Read();
                            win=true;
                        }
                        else if(a[i,j]==pos)  
                        {
                            pos++;
                        } 
                        else
                        {
                            flag=true;
                            break;
                        }
                    }   
                    if(flag==true)
                        break;
                }    
            }       
        }
    }
}
}


