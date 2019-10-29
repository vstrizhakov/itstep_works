/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javafirsthomework;

/**
 *
 * @author PC
 */
public class DynamicArray {
    private int[] numbers;
    private int size = 0;
    
    public void add(int value)
    {
        int[] newNumbers = new int[++size];
        for (int i = 0; i < size - 1; i++)
        {
            newNumbers[i] = numbers[i];
        }
        newNumbers[size - 1] = value;
        numbers = newNumbers;
    }
    
    public boolean insert(int value, int position)
    {
        if (position < 0 || position > size)
        {
            return false;
        }
        int[] newNumbers = new int[++size];
        for (int i = 0, j = 0; i < size; i++)
        {
            if (i == position)
            {
                newNumbers[i] = value;
                continue;
            }
            newNumbers[i] = numbers[j++];
        }
        numbers = newNumbers;
        return true;
    }
    
    public void remove(int position)
    {
        int[] newNumbers = new int[--size];
        for (int i = 0, j = 0; i < size + 1; i++)
        {
            if (i == position)
            {
                continue;
            }
            newNumbers[j++] = numbers[i];
        }
        numbers = newNumbers;
    }
    
    public int find(int value)
    {
        for (int i = 0; i < size; i++)
        {
            if (numbers[i] == value)
            {
                return i;
            }
        }
        return -1;
    }
    
    public int getSize()
    {
        return size;
    }
    
    public int getValue(int position)
    {
        return numbers[position];
    }
    
    public void print()
    {
        for (int i = 0; i < size; i++)
        {
            System.out.print(numbers[i] + " ");
        }
    }
}
