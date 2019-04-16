/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class HelloWorld {
    static void Main() 
    {
        int[,] mat=new int[4,4];
        for(int i=0;i<4;i++)
            for(int j=0;j<4;j++)
                mat[i,j]=0;
        Random ran=new Random();
        int y,x=ran.Next(0,16);
        do{
            y=ran.Next(0,16);
        }while(x==y);
        mat[x/4,x%4]=mat[y/4,y%4]=2;
        Print(mat);
        bool end=false,move;
        ConsoleKey ch;
        while(end==false)
        {
            move=false;
            ch=Console.ReadKey().Key;
            switch(ch)
            {
                case ConsoleKey.LeftArrow : move=Left(mat);
                                            break;
                case ConsoleKey.RightArrow :move=Right(mat);
                                            break;
                case ConsoleKey.DownArrow : move=Down(mat);
                                            break;
                case ConsoleKey.UpArrow   : move=Up(mat);
                                            break;
                default                   : Console.WriteLine(" : Invalid key");   
                                            break;
            }
            if(move==true)
            {
                for(int i=0;i<4;i++)
                    for(int j=0;j<4;j++)
                        if(mat[i,j]==2048)
                        {
                            end=true;
                            Print(mat);
                            Console.Write("\n!!!Victory!!!");
                            Console.Write("\n Press Any Key To Exit");
                            Console.ReadKey();
                        }
                if(end==false)
                {
                    do{
                        x=ran.Next(0,16);
                    }while(mat[x/4,x%4]!=0);
                    y=ran.Next(2,5);
                    if(y==3)
                        mat[x/4,x%4]=2;
                    else
                        mat[x/4,x%4]=y;
                    Print(mat);
                }
            }
            else
            {
                bool fail=true;
                for(int i=0;i<4;i++)
                {
                    for(int j=0;j<4;j++)
                    {
                        if( mat[i,j]==0||
                            (i-1>=0 && mat[i-1,j]==mat[i,j])||
                            (i+1<=3 && mat[i+1,j]==mat[i,j])||
                            (j-1>=0 && mat[i,j-1]==mat[i,j])||
                            (j+1<=3 && mat[i,j+1]==mat[i,j]))
                        {
                            fail=false;
                        }
                    }
                    if(fail==false)
                        break;
                }
                if(fail==true)
                {
                    Print(mat);
                    end=true;
                    Console.Write("\n GAME OVER!!!");
                    Console.Write("\n Press Any Key To Exit");
                    Console.ReadKey();
                }
            }
        }
    } 
    
    public static bool Left(int[,] mat)
    {
        bool move=false;
        for(int i=0;i<4;i++)
        {
            for(int j=0;j<3;j++)
            {
                if(mat[i,j]==0)
                {
                    for(int k=j+1;k<4;k++)
                    {
                        if(mat[i,k]!=0)
                        {
                            mat[i,j]=mat[i,k];
                            mat[i,k]=0;
                            move=true;
                            break;
                        }
                    }
                    if(mat[i,j]==0)
                        break;
                }
                for(int k=j+1;k<4;k++)
                {
                    if(mat[i,k]!=0)
                    {
                        if(mat[i,j]==mat[i,k])
                        {
                            mat[i,j]*=2;
                            mat[i,k]=0;
                            move=true;
                        }
                        break;
                    }
                }
            }
        }
        return move;
    }
    
    public static bool Right(int[,] mat)
    {
        bool move=false;
        for(int i=0;i<4;i++)
        {
            for(int j=3;j>0;j--)
            {
                if(mat[i,j]==0)
                {
                    for(int k=j-1;k>=0;k--)
                    {
                        if(mat[i,k]!=0)
                        {
                            mat[i,j]=mat[i,k];
                            mat[i,k]=0;
                            move=true;
                            break;
                        }
                    }
                    if(mat[i,j]==0)
                        break;
                }
                for(int k=j-1;k>=0;k--)
                {
                    if(mat[i,k]!=0)
                    {
                        if(mat[i,j]==mat[i,k])
                        {
                            mat[i,j]*=2;
                            mat[i,k]=0;
                            move=true;
                        }
                        break;
                    }
                }
            }
        }
        return move;
    }
    
    public static bool Up(int[,] mat)
    {
        bool move=false;
        for(int j=0;j<4;j++)
        {
            for(int i=0;i<3;i++)
            {
                if(mat[i,j]==0)
                {
                    for(int k=i+1;k<4;k++)
                    {
                        if(mat[k,j]!=0)
                        {
                            mat[i,j]=mat[k,j];
                            mat[k,j]=0;
                            move=true;
                            break;
                        }
                    }
                    if(mat[i,j]==0)
                        break;
                }
                for(int k=i+1;k<4;k++)
                {
                    if(mat[k,j]!=0)
                    {
                        if(mat[i,j]==mat[k,j])
                        {
                            mat[i,j]*=2;
                            mat[k,j]=0;
                            move=true;
                        }
                        break;
                    }
                }
            }
        }
        return move;
    }
    
    public static bool Down(int[,] mat)
    {
        bool move=false;
        for(int j=0;j<4;j++)
        {
            for(int i=3;i>0;i--)
            {
                if(mat[i,j]==0)
                {
                    for(int k=i-1;k>=0;k--)
                    {
                        if(mat[k,j]!=0)
                        {
                            mat[i,j]=mat[k,j];
                            mat[k,j]=0;
                            move=true;
                            break;
                        }
                    }
                    if(mat[i,j]==0)
                        break;
                }
                for(int k=i-1;k>=0;k--)
                {
                    if(mat[k,j]!=0)
                    {
                        if(mat[i,j]==mat[k,j])
                        {
                            mat[i,j]*=2;
                            mat[k,j]=0;
                            move=true;
                        }
                        break;
                    }
                }
            }
        }
        return move;
    }
    
    public static void Print(int[,] mat)
    {
        Console.Clear();
        Console.Write("+------+------+------+------+\n");
        for(int i=0;i<4;i++)
        {
            Console.Write("|      |      |      |      |\n");
            for(int j=0;j<4;j++)
            {
                if(mat[i,j]==0)
                    Console.Write("|      ");
                else if(mat[i,j]<10)
                    Console.Write("| "+mat[i,j]+"    ");
                else if(mat[i,j]<100)
                    Console.Write("| "+mat[i,j]+"   ");
                else if(mat[i,j]<1000)
                    Console.Write("| "+mat[i,j]+"  ");
                else
                    Console.Write("| "+mat[i,j]+" ");
            }
            Console.Write("|\n");
            Console.Write("|      |      |      |      |\n");
            Console.Write("+------+------+------+------+\n");
        }
    }
}
