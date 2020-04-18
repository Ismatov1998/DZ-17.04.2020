using System;


namespace Fg
{
    class Program
    {
      static void Main(string[] args)
      {
    
        string[] a=new string[10]{"1","2","3","4","5","6","7","8","9","10"};
          ArrayHelper<string>.Pop(ref a);
          Console.WriteLine("Массив после удаления последного элемента");
          ArrayHelper<string>.getinfo(a);  
          
        int[] a1=new int[10]{1,2,3,4,5,6,7,8,9,10};    
         ArrayHelper<int>.Push(ref a1, 11);
          Console.WriteLine("Массив после добавления элемента 11");
         ArrayHelper<int>.getinfo(a1);

        int[] a2=new int[10]{1,2,3,4,5,6,7,8,9,10};    
         ArrayHelper<int>.Shift(ref a2);
         Console.WriteLine("Массив после удаления первого элемента ");
         ArrayHelper<int>.getinfo(a2);
         
         
        int[] a3=new int[10]{1,2,3,4,5,6,7,8,9,10};    
         ArrayHelper<int>.UnShift(ref a3, 12);
          Console.WriteLine("Массив после добавления элемента 12 в начале массива");
         ArrayHelper<int>.getinfo(a3);
       
        int[] a4=new int[10]{1,2,3,4,5,6,7,8,9,10}; 
        int n3,n4;
        Console.WriteLine("Введите значения Beginindex");
        string n1=Console.ReadLine();
        if(string.IsNullOrWhiteSpace(n1))
        {
         n3=0;
        }
        else 
        {
          n3=Convert.ToInt32(n1);
        }
        Console.WriteLine("Введите значения endindex");
        string  n2=(Console.ReadLine());   
        if(string.IsNullOrWhiteSpace(n2))
        {
          n4=0;
        }
        else 
        {
          n4=Convert.ToInt32(n2);
        }
        // Console.WriteLine($"{n3} {n4}");
        //ArrayHelper<int>.Slice( a3,n1,n2 );
        Console.WriteLine("Массив после выполнения функции Slice()");

         ArrayHelper<int>.getinfo(ArrayHelper<int>.Slice( a4,n3,n4 ));
                                                     
           
      }
    }
    static class ArrayHelper<T>
    {
       public static void getinfo(T[] a)
       {
         for(int i=0;i<a.Length;i++)
         {
            Console.Write($"{a[i]} ");
             
         }
         Console.WriteLine();
       }
        
       
      public static T Pop(ref T [] a)
      {
       
       T[] a1=new T[a.Length-1];
       for(int i=0;i<a.Length-1;i++)
       {
        a1[i]=a[i];
       }
       T b=a[a.Length-1];
       a=a1;
       return b ;
      }
       
    public static int Push (ref T [] a, T b)
      {
       T[] a1=new T[a.Length+1];
       for(int i=0;i<a.Length;i++)
       {
        a1[i]=a[i];
       }
       a1[a.Length]=b;
       a=a1;
       return a.Length ;
               
      }

      public static T Shift (ref T [] a)
      {
        T b=a[a.Length-1];
        Array.Reverse(a);

        Array.Resize(ref a, a.Length-1);
        Array.Reverse(a);
        return b;
      
      }
      public static int UnShift (ref T [] a, T b)
      {
        Array.Reverse(a);
        Array.Resize(ref a, a.Length+1);
        a[a.Length-1]=b;
        Array.Reverse(a);
        return a.Length;
      }

      public static T[] Slice(T[] a, int beginindex, int endindex)
      {

        int t=0;
        T[] a1=new T[a.Length];

        if(beginindex > a.Length)
        {
          return a1;
        }

        if(beginindex<0 && endindex==0)
        {
          Array.Resize(ref a1,-beginindex);
          for(int i=a.Length+beginindex;i<a.Length;i++)
          {
            a1[t]=a[i];
            t++;
          }
          return a1;
        }
        if(beginindex==0 && endindex>0)
        {
          Array.Resize(ref a1,endindex-1);
          for(int i=0;i<endindex-1;i++)
          {
            a1[t]=a[i];
            t++;
          }
          return a1;
        }
        if(beginindex>=0 && endindex==0)
        {
          Array.Resize(ref a1,a.Length-beginindex);
          for(int i=beginindex;i<a.Length;i++)
          {
            a1[t]=a[i];
            t++;
          }
          return a1;
        }


        if(beginindex>=0 && endindex>=0 && beginindex<endindex)
        {
         Array.Resize(ref a1,endindex-beginindex);
          for(int i=beginindex;i<endindex;i++)
          {
            a1[t]=a[i];
            t++;
          }
          return a1;/////1 2 3 4 5 6 7 8 9 10
        }
        
        if(beginindex>=0 && endindex<0)
        {
          Array.Resize(ref a1,a.Length-beginindex+endindex);
          for(int i=beginindex;i<a.Length+endindex;i++)
          {
            a1[t]=a[i];
            t++;
          }
          return a1;
          
        }
        return a1;
      }
        
        
      
      
    }
}




