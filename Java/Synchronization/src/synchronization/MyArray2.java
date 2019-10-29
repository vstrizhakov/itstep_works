/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package synchronization;

/**
 *
 * @author PC
 */
public class MyArray2 {
    private int[] arr =new int[1000];
    private int index = 0;
    
    public void writeToArray(int value, int count) throws InterruptedException
    {
        synchronized (arr)
        {
            for (int i = 0; i < count; i++)
            {
                arr[this.index++] = i;
                Thread.sleep(10);
            }
        }
    }
    
    public void showArray()
    {
        for (int i = 0; i < arr.length; i++)
        {
            System.out.println(arr[i]);
            if (i % 49 == 0)
            {
                System.out.println();
            }
        }
    }
}
