/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_6_throwable;

/**
 *
 * @author 09220
 */
public class Java_6_Throwable {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try{
            three();
        }
        catch(Exception e)
        {
            System.out.println("Error: "+e.getMessage());
            //e.printStackTrace();
            StackTraceElement[] arr = e.getStackTrace();
            for(StackTraceElement ste:arr) // свой getStackTrace
            {
                System.err.println("Имя файла : "+ste.getFileName());
                System.err.println("Имя класса : "+ste.getClassName());
                System.err.println("Номер строки  : "+ste.getLineNumber());
                System.err.println("Имя файла : "+ste.getMethodName());
                System.err.println("Имя Метода : "+ste.getFileName());

            }
        }
    }
    
    static void one()throws Exception
    {
        two();
    }
    static void two()throws Exception
    {
        three();
    }
    static void three() throws Exception
    {
       throw new Exception("просто ошибка");
    }
}
