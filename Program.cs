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

        Console.WriteLine("Введите значения Beginindex");
        string n1=Console.ReadLine();   
        Console.WriteLine("Введите значения endindex");
        string n2=Console.ReadLine();   
        
         //ArrayHelper<int>.Slice( a3,n1,n2 );
         Console.WriteLine("Массив после выполнения функции Slice()");
         ArrayHelper<int>.getinfo(ArrayHelper<int>.Slice( a4,n1,n2 ));
                                                     
           
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

      public static T[] Slice(T[] a,string beginindex, string endindex)
      {
        T[] a1=new T[a.Length];
        int t=0;
        if(string.IsNullOrWhiteSpace(beginindex)==false && string.IsNullOrWhiteSpace(endindex)==false && Convert.ToInt32(endindex)>0 && Convert.ToInt32(beginindex)>0)
        {
         int n1=Int32.Parse(beginindex);
         int n2=Int32.Parse(endindex);
         
        
         if( n1<n2 && n1<a.Length)   
         {
          Array.Resize(ref a1,n2-n1-1);
          if(n2>=a.Length)
          {
            Array.Resize(ref a1,a.Length-n1-1);
            for(int i=n1;i<a.Length-1;i++)
          {
            a1[t]=a[i];
            t++;
          }
           return a1;

          }
          else{
          for(int i=n1;i<n2-1;i++)
          {
            a1[t]=a[i];
            t++;
          }
           return a1;
        }
         }
        }
        
         
         
        if(string.IsNullOrWhiteSpace(beginindex)==true && Convert.ToInt32(endindex)> 0  )
         {
           
          int n3=Int32.Parse(endindex);
          
          Array.Resize(ref a1,n3);
          if(n3 < a.Length)
          {
           for(int i=0;i<n3;i++)
           {
            a1[t]=a[i];
            t++;
           }
           
          }
           return a1;
         }
         
         if(string.IsNullOrWhiteSpace(endindex)==true && Convert.ToInt32(beginindex)> 0)
         {
           
          int n4=Int32.Parse(beginindex);
          Array.Resize(ref a1,a.Length-n4);
          if(n4 < a.Length)
          {
           for(int i=n4;i<a.Length;i++)
           {
            a1[t]=a[i];
            t++;
           }
          }
          return a1;
         }
         if(Convert.ToInt32(beginindex)>0 && Convert.ToInt32(endindex)< 0 )
         {
           Array.Resize(ref a1,a.Length-Convert.ToInt32(beginindex)+Convert.ToInt32(endindex));       
           for(int i=Convert.ToInt32(beginindex);i<a.Length+Convert.ToInt32(endindex);i++)
           {
               a1[t]=a[i];
               t++;
           }
       
         }
         if(Convert.ToInt32(beginindex)<0)
         {
             Array.Resize(ref a1,-Convert.ToInt32(beginindex));
             for(int i=a.Length+Convert.ToInt32(beginindex);i<a.Length;i++)
             {
                a1[t]=a[i];
                t++;
             }
             
         }
        
        
         return a1;

         }
        
        
      
      
    }
}




