/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadsarraysynchronization;

/**
 *
 * @author PC
 */
public class MyArray {
    static public final int COUNT = 100;
    
    private int[] _array = new int[COUNT];
    
    public void insertInt(int index, int num)
    {
        if (index >= 0 && index < COUNT)
        {
            _array[index] = num;
        }
    }
    
    public int getInt(int index)
    {
        if (index >= 0 && index < COUNT)
        {
            return _array[index];
        }
        return -1;
    }
}
